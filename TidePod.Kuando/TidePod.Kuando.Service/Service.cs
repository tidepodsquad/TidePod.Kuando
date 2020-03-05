using System;
using System.Collections.Concurrent;
using System.IO;
using System.IO.Pipes;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TidePod.Kuando.Shared;

namespace TidePod.Kuando.Service
{
    public class Service : ServiceBase
    {
        private readonly CancellationTokenSource tokenSource;
        private Task executionHandle;

        public Service()
        {
            this.tokenSource = new CancellationTokenSource();

            this.executionHandle = Task.FromException(
                new InvalidOperationException("Can't stop service if it hasn't started."));
        }

        public async Task RunAsync(CancellationToken cancellationToken)
        {
            using (Server server = await Server.Create(cancellationToken).ConfigureAwait(false))
            {
                server.OnColorMessage += (obj, e) => { };
                server.OnException += (obj, e) => { throw e; };

                try
                {
                    await Task.Delay(-1, cancellationToken);
                }
                catch (TaskCanceledException)
                {
                    // Do nothing; the caller ends execution by calling the token.
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.tokenSource.Dispose();
            }
        }

        protected override void OnStart(string[] args)
        {
            this.executionHandle = this
                .RunAsync(this.tokenSource.Token)
                .ContinueWith(
                    x =>
                    {
                        // Need to call Stop() on another thread, because Stop() is going to wait for the
                        // executionHandle to complete.
                        Thread thread = new Thread(() => this.Stop());
                        thread.Start();

                        // Now that OnStop() is waiting for our result, if we throw an exception, it'll be emitted in
                        // the OnStop() method.
                        if (x.IsFaulted)
                        {
#pragma warning disable CS8597 // Thrown value may be null.
                            throw x.Exception;
#pragma warning restore CS8597 // Thrown value may be null.
                        }
                        else if (x.IsCanceled && !this.tokenSource.IsCancellationRequested)
                        {
                            throw new TaskCanceledException();
                        }
                    },
                    default,
                    TaskContinuationOptions.ExecuteSynchronously,
                    TaskScheduler.Current);

            base.OnStart(args);
        }

        protected override void OnStop()
        {
            this.tokenSource.Cancel();
            this.executionHandle.Wait();
            base.OnStop();
        }
    }
}

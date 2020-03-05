using System;
using System.Collections.Concurrent;
using System.IO.Pipes;
using System.Threading;
using System.Threading.Tasks;

namespace TidePod.Kuando.Shared
{
    public sealed class Server : IDisposable
    {
        private readonly ConcurrentDictionary<ThreadServer, Thread> threads;

        private Server()
        {
            CreateThread();
        }

        public event EventHandler<ColorMessage> OnColorMessage;

        public event EventHandler<Exception> OnException;

        protected override void Dispose()
        {
            this.thread.Join();
        }

        private void RaiseException(ThreadServer server, Exception e)
        {
            this.OnException?.Invoke(server, e);
        }

        private (ThreadServer, Thread) CreateThread()
        {
            using (ManualResetEventSlim resetEvent = new ManualResetEventSlim())
            {
                ThreadServer server = null;
                Thread thread = new Thread(
                    async () =>
                    {
                        NamedPipeServerStream pipe = new NamedPipeServerStream(
                            Constants.PipeNamePrefix,
                            PipeDirection.InOut,
                            1,
                            PipeTransmissionMode.Message,
                            PipeOptions.WriteThrough);

                        await pipe.WaitForConnectionAsync();

                        server = new ThreadServer(pipe);

                        resetEvent.Set();

                        await server.Run(this);

                        this.CreateThread();
                    });
                thread.Start();

                resetEvent.Wait();
                return (server, thread);
            }
        }

        private class Box<T>
        {
            public Box(T value)
            {
                this.Value = value;
            }

            public T Value { get; set; }
        }

        private class ThreadServer : Connection
        {
            private readonly PipeStream stream;
            private readonly Box<bool> threadRunning;

            public ThreadServer(PipeStream stream)
                : base(stream)
            {
                this.threadRunning = new Box<bool>(true);
                this.stream = stream;
            }

            public async Task Run(Server parentServer)
            {
                bool GetRunningState()
                {
                    lock (this.threadRunning)
                    {
                        return this.threadRunning.Value;
                    }
                }

                while (GetRunningState())
                {
                    try
                    {
                        if (this.stream.IsConnected)
                        {

                        }

                        string value = await this.ReceiveAsync();
                        if (value is null || value.Length == 0)
                        {
                            continue;
                        }
                        else
                        {
                            Console.WriteLine(value);
                        }
                    }
                    catch (Exception e)
                    {
                        parentServer.RaiseException(this, e);
                    }
                }
            }
        }
    }
}

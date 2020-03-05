using System.IO;
using System.IO.Pipes;
using System.Threading;
using System.Threading.Tasks;

namespace TidePod.Kuando.Shared
{
    public sealed class Server : Connection
    {
        private Server(Stream stream)
            : base(stream)
        {
        }

        public static async Task<Server> Create(CancellationToken cancellationToken)
        {
            NamedPipeServerStream pipe = new NamedPipeServerStream(
                Constants.PipeNamePrefix,
                PipeDirection.InOut,
                1,
                PipeTransmissionMode.Message,
                PipeOptions.WriteThrough);

            try
            {
                await pipe.WaitForConnectionAsync(cancellationToken);
                Server server = new Server(pipe);

                return server;
            }
            catch
            {
                pipe.Dispose();
                throw;
            }
        }
    }
}

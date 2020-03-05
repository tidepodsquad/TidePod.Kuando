using System.IO;
using System.IO.Pipes;
using System.Threading;
using System.Threading.Tasks;

namespace TidePod.Kuando.Shared
{
    public sealed class Client : Connection
    {
        private Client(Stream stream)
            : base(stream)
        {
        }

        public static async Task<Client> Create(CancellationToken cancellationToken)
        {
            NamedPipeClientStream pipe = new NamedPipeClientStream(
                ".",
                Constants.PipeNamePrefix,
                PipeDirection.InOut,
                PipeOptions.WriteThrough);
            try
            {
                await pipe.ConnectAsync(cancellationToken);

                Client client = new Client(pipe);
                return client;
            }
            catch
            {
                pipe.Dispose();
                throw;
            }
        }

        public async Task SendAsync(ColorMessage colorMessage)
        {
            await this
                .SendAsync($"0,{colorMessage.Red},{colorMessage.Green},{colorMessage.Blue}")
                .ConfigureAwait(false);
        }
    }
}

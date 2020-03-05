using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace TidePod.Kuando.Shared
{
    public abstract class Connection : IDisposable
    {
        private readonly Stream stream;
        private readonly StreamReader reader;
        private readonly StreamWriter writer;

        private protected Connection(Stream stream)
        {
            this.stream = stream;
            this.reader = new StreamReader(stream, Encoding.UTF8, false, 1024, true);
            this.writer = new StreamWriter(stream, Encoding.UTF8, 1024, true);
        }

        private protected async Task Send(string message)
        {
            await this.writer.WriteLineAsync(message).ConfigureAwait(false);
            await this.writer.FlushAsync().ConfigureAwait(false);
        }

        private protected async Task<string> Receive()
        {
            return await this.reader.ReadLineAsync();
        }

        public void Dispose()
        {
            this.reader.Dispose();
            this.writer.Dispose();
            this.stream.Dispose();
        }
    }
}

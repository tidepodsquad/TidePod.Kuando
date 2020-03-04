using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TidePod.Kuando.Winforms
{
    public static class Program
    {
        [STAThread]
        public static async Task<int> Main(string[] args)
        {
            using (NamedPipeClientStream client = new NamedPipeClientStream(
                ".",
                "foo",
                PipeDirection.InOut,
                PipeOptions.WriteThrough))
            {
                await client.ConnectAsync();

                using (StreamReader reader = new StreamReader(client, Encoding.UTF8, true, 1024, leaveOpen: true))
                using (StreamWriter writer = new StreamWriter(client, Encoding.UTF8, 1024, leaveOpen: true))
                {
                    await writer.WriteLineAsync("Test message");
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                MainWindow mainWindow = new MainWindow();
                Application.Run(mainWindow);

                return await mainWindow.ExitTask.ConfigureAwait(true);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.GetType()}: {e.Message}");
                return 1;
            }
        }
    }
}

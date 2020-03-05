using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TidePod.Kuando.Shared;

namespace TidePod.Kuando.Winforms
{
    public static class Program
    {
        [STAThread]
        public static async Task<int> Main(string[] args)
        {
            using (Client client = await Client.Create(default).ConfigureAwait(false))
            {

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

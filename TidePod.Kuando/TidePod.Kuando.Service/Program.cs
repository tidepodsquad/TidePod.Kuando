using System;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace TidePod.Kuando.Service
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            using (Service service = new Service())
            {
                if (Environment.UserInteractive)
                {
                    await service.RunAsync(default);
                }
                else
                {
                    ServiceBase.Run(new[] { service });
                }
            }
        }
    }
}

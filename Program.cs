using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using CsharpStudyPro.HostedServices;

namespace CsharpStudyPro
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            CreateHostBuilder(args).Build().Start();
            using var host = Host.CreateDefaultBuilder().ConfigureServices((hostContext, services) =>
            {
                // HostedService
                services.AddHostedService<ConsoleLogSyncService>();

            }).Build();

            await host.StartAsync();
            await host.WaitForShutdownAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

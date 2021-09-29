using Fleck;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using LogLevel = Fleck.LogLevel;

namespace CsharpStudyPro.HostedServices
{
    public class ConsoleLogSyncService : BackgroundService
    {
        private List<IWebSocketConnection> allSockets = new List<IWebSocketConnection>();
        private int MaxCount = 10;

        public ConsoleLogSyncService()
        {

        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            FleckLog.Level = LogLevel.Debug;
            var server = new WebSocketServer("ws://192.168.4.193:50000");
            //server.Certificate = new X509Certificate2(@"E:\\temp\\cert.pfx", "singlesword");
            server.Start(socket =>
            {
                socket.OnOpen = () =>
                {
                    Console.WriteLine("Open!");
                    allSockets.Add(socket);
                };
                socket.OnClose = () =>
                {
                    Console.WriteLine("Close!");
                    allSockets.Remove(socket);
                };
                socket.OnMessage = message =>
                {
                    Console.WriteLine(message);
                    allSockets.ToList().ForEach(s => s.Send("Echo: " + message));
                };
            });

            await Task.Delay(1000);
            await SendToWebPage();
        }

        private async Task SendToWebPage()
        {
            Console.WriteLine("Start to Send...");
            while (--MaxCount > 0 )
            {
                var now = "log:" + DateTime.Now;
                Console.WriteLine("Send:" + now);
                foreach (var socket in allSockets.ToList())
                {
                    await socket.Send(now);
                    await Task.Delay(1000);
                }
            }
        }

    }
}

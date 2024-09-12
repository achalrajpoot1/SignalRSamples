
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;
namespace ACVS.OSP.NotificationHub.Client
{
    public class NotificationHubClientDemo
    {
        public async Task StartDemoAsync()
        {

            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            string hostName = configBuilder["HostName"];

            var connectionBulber = new HubConnectionBuilder()
                .WithUrl(hostName).WithAutomaticReconnect().WithStatefulReconnect()
                .Build();

            connectionBulber.Reconnected += async (connectionId) =>
            {
                Console.WriteLine($"Reconnected with new connectionId {connectionId}");
                await connectionBulber.InvokeAsync("SendMessage", "Reconnected");
            };
            connectionBulber.Closed += async (error) =>
            {
                Console.WriteLine("Closed");
                await connectionBulber.InvokeAsync("SendMessage", "Closed");
            };
            connectionBulber.Reconnecting += async (error) =>
            {
                Console.WriteLine("Reconnecting");
                await connectionBulber.InvokeAsync("SendMessage", "Reconnecting");
            };


            connectionBulber.On<byte[]>("ReceiveMessage", (message) =>
            {

                try
                {

                   // var notificationPackage = ProcessNotificationRequestExtensions.GetDecompressedPackage(message);
                    Console.WriteLine("NotificationPackage: " + message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine(DateTime.Now);
                Console.WriteLine("******************* New Message Received  *****************");
                Console.WriteLine(message);

                Console.WriteLine("******************* Message END *****************");

                Console.WriteLine();
            });

            await connectionBulber.StartAsync();

            var connectionId = connectionBulber.ConnectionId;

            Console.WriteLine("ConnectionId: " + connectionBulber.ConnectionId);
        }
    }
}

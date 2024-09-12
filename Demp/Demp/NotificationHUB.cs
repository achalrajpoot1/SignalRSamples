using Microsoft.AspNetCore.SignalR;

namespace Demp
{
    public class NotificationHUB : Hub
    {

        public override Task OnConnectedAsync()
        {
            var connectionId = Context.ConnectionId.ToString();
            Console.WriteLine($"Connection ID: {connectionId}");

            //Do Subscrition for changes
            return base.OnConnectedAsync();
        }


        public override Task OnDisconnectedAsync(Exception? ex)
        {
            return base.OnDisconnectedAsync(ex);
        }
    }
}

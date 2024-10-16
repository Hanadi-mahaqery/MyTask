using Microsoft.AspNetCore.SignalR;

namespace MyTask.Hubs
{
    public class NotificationHub : Hub
    {
        public async Task SendReminder(string patientId, string message)
        {
            await Clients.User(patientId).SendAsync("ReceiveReminder", message);
        }
    }
}

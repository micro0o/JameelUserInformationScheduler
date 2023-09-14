using JUIS.Domain.Entities;
using Microsoft.AspNetCore.SignalR;

namespace JUIS.Presentation.SignalR
{
    public class NotificationHub : Hub
    {
        public async Task SendUserSavedNotification(User user)
        {
            await Clients.All.SendAsync("UserSaved", user);
        }
    }
}

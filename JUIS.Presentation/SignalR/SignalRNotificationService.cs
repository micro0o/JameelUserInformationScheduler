using JUIS.Application.Interfaces;
using JUIS.Domain.Entities;
using Microsoft.AspNetCore.SignalR;

namespace JUIS.Presentation.SignalR
{
    public class SignalRNotificationService : INotificationService
    {
        private readonly IHubContext<NotificationHub> _hubContext;

        public SignalRNotificationService(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendNotification(string message)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveNotification", message);
        }
    }
}

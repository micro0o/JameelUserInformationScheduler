using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JUIS.Application.Interfaces
{
    public interface INotificationService
    {
        Task SendNotification(string message);
    }
}

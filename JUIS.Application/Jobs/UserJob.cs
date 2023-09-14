using JUIS.Domain.Entities;
using JUIS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JUIS.Application.Jobs
{
    public class UserJob : IUserJob
    {
        private readonly IUserRepository _userRepository;
        private readonly INotificationService _notificationService;

        public UserJob(IUserRepository userRepository, INotificationService notificationService)
        {
            _userRepository = userRepository;
            _notificationService = notificationService;
        }

        public async Task SaveUserAndSendNotification(User user)
        {
            await _userRepository.AddUser(user);
            await _notificationService.SendNotification($"User {user.FirstName} {user.LastName} was added.");
        }
    }
}

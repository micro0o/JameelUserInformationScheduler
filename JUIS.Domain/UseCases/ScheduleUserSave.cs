using JUIS.Domain.Entities;
using JUIS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JUIS.Domain.UseCases
{
    public class ScheduleUserSave
    {
        //private readonly IUserRepository _userRepository;
        //private readonly INotificationService _notificationService;
        //private readonly IJobScheduler _jobScheduler;

        //public ScheduleUserSave(IUserRepository userRepository, INotificationService notificationService, IJobScheduler jobScheduler)
        //{
        //    _userRepository = userRepository;
        //    _notificationService = notificationService;
        //    _jobScheduler = jobScheduler;
        //}

        //public void Execute(User user, TimeSpan delay)
        //{
        //    _jobScheduler.Schedule(async () =>
        //    {
        //        await _userRepository.Save(user);
        //        await _notificationService.SendNotification($"User {user.FirstName} {user.LastName} was added.");
        //    }, delay);
        //}
    }
}

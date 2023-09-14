using JUIS.Application.Jobs;
using JUIS.Domain.Entities;
using JUIS.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JUIS.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IJobScheduler _jobScheduler;
        private readonly INotificationService _notificationService;
        private readonly UserJob _userJob;

        public UserController(IUserRepository userRepository,
            IJobScheduler jobScheduler,
            INotificationService notificationService,
            UserJob userJob)
        {
            _userRepository = userRepository;
            _jobScheduler = jobScheduler;
            _notificationService = notificationService;
            _userJob = userJob;
        }

        [HttpPost]
        public IActionResult SaveUser([FromBody] User user)
        {
            _jobScheduler.ScheduleUserSave(() => _userJob.SaveUserAndSendNotification(user).Wait(), TimeSpan.FromMinutes(5));
            //_jobScheduler.ScheduleUserSave(async () =>
            //{
            //    await _userRepository.AddUser(user);
            //    await _notificationService.SendNotification($"User {user.FirstName} {user.LastName} was added.");
            //}, TimeSpan.FromMinutes(5));

            return Accepted("Record being scheduled.");
            //_jobScheduler.ScheduleUserSave(user, TimeSpan.FromMinutes(5));
            //return Ok("Record Saved");
        }
    }
}

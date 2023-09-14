using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hangfire;
using JUIS.Domain.Entities;
using JUIS.Domain.Interfaces;
using System.Linq.Expressions;

namespace JUIS.Application.HangfireJobs
{
    public class JobScheduler : IJobScheduler
    {
        public void ScheduleUserSave(Expression<Action> action, TimeSpan delay)
        {
            BackgroundJob.Schedule(action, delay);

        }
    }

}

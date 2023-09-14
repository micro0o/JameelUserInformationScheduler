﻿using JUIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JUIS.Domain.Interfaces
{
    public interface IUserJob
    {
        Task SaveUserAndSendNotification(User user);
        //void ScheduleUserSave(Expression<Action> action, TimeSpan delay);
    }
}

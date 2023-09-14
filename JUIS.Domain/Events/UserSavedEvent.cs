using JUIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JUIS.Domain.Events
{
    public class UserSavedEvent
    {
        public User User { get; }

        public UserSavedEvent(User user)
        {
            User = user;
        }
    }
}

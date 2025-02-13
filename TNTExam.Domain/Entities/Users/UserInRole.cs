﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNTExam.Domain.Entities.Users
{
    public class UserInRole : BaseEntity
    {
        public virtual User User { get; set; }
        public long UserId { get; set; }
        public virtual Role Role { get; set; }
        public long RoleId { get; set; }
    }
}

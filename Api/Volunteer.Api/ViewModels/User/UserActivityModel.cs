using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Volunteer.Api.ViewModels.User
{
    public class UserActivityModel
    {
        public Guid ActivityUid { get; set; }

        public Guid UserUid { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scheduling.Models
{
    public class MyUsersIdentity: IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TelNumber { get; set; }
        public string Gender { get; set; }
        public string DateOfBirth { get; set; }
        public string Specialization { get; set; }
        
    }
}

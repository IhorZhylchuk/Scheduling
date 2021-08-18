using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scheduling.Models
{
    public class MyDoctorsIdentity: MyUsersIdentity
    {
        public string Specialisation { get; set; }
    }
}

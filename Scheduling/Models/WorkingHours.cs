using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scheduling.Models
{
    public static class WorkingHours
    {
        public static List<string> GetHours()
        {
            List<string> hours = new List<string>();
            for (var i = 8; i < 17; i++)
            {
                for (var j = 0; j < 60; j += 30)
                {
                    if (j == 0)
                    {
                        hours.Add(i.ToString() + ":" + j.ToString() + "0");
                    }
                    else
                    {
                        hours.Add(i.ToString() + ":" + j.ToString());
                    }
                }
            }
            return hours;
        }

        public static MyUsersIdentity DoctorReturned(ApplicationDBContext dBContext, string specialization)
        {
            MyUsersIdentity doctor = new MyUsersIdentity();
            var doctorsList = dBContext.Users.Where(s => s.Specialization != null).Select(d => d).ToArray();
            for(int i = 0; i <= dBContext.UserRoles.Where(r => r.RoleId == "a12be9c5-aa65-4af6-bd97-00bd9344e575").Count(); i++)
            {
                if((doctorsList[i].Specialization + " ( " + doctorsList[i].Name + " " + doctorsList[i].Surname + " )" == specialization)) 
                {
                    doctor = doctorsList[i];
                }
            }
            return doctor;
        }
        
    }
}

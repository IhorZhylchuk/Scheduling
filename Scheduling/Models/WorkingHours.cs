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
    }
}

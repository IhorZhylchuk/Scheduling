﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Scheduling.Models
{
    public class ReservationModel_Orig
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Time { get; set; }
        [Required]
        public string Specialist { get; set; }
        [Required]
        public string Email { get; set; }
        [Phone]
        [Required]
        [MinLength(12), MaxLength(12)]
        public string TelNumber { get; set; }
        [Required]
        public string Gender { get; set; }
        
        public MyUsersIdentity User { get; set; }

    }
}
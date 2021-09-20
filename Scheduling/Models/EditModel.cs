using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Scheduling.Models
{
    public class EditModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }

        [Required]
        [Display(Name = "Tel.number")]
        public string TelNumber { get; set; }


        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        public string DateOfBirth { get; set; }
    }
}

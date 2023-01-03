using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Domain.Models
{
    public class User
    {
        [Required(ErrorMessage = "The field {0} is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public string Address { get; set; }
        public string UserType { get; set; }
        public decimal Money { get; set; }
    }
}

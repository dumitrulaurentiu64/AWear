using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AWear_API.Dtos
{
    public class MedicToRegister
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "You must specify a password between 4 and 8 characters")]
        public string Password { get; set; }

        [Required]
        public string CNP { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string FieldOfPractice { get; set; }

        [Required]
        public string ProffesionalGrades { get; set; }

        [Required]
        public DateTime Created { get; set; }

        public string CabinetHours { get; set; }
        public string Email { get; set; }

        public MedicToRegister()
        {
            Created = DateTime.Now;
        }

    }
}

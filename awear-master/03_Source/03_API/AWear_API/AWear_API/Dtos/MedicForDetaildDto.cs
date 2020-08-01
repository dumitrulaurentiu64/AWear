using AWear_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWear_API.Dtos
{
    public class MedicForDetaildDto
    {
        public Guid id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime Created { get; set; }
        public string CNP { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string ProffesionalGrades { get; set; }
        public string CabinetHours { get; set; }
        public string FieldOfPractice { get; set; }

        public ICollection<Recommandation> Recommandations { get; set; }
        public ICollection<Pacient> Pacients { get; set; }
    }
}

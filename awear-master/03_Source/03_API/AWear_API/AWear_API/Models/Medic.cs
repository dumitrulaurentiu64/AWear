using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWear_API.Models
{
    public class Medic : ApplicationUser
    {
        public string ProffesionalGrades { get; set; }
        public string CabinetHours { get; set; }
        public string FieldOfPractice { get; set; }

        public ICollection<Pacient> Pacients { get; set; }
        public ICollection<Recommandation> Recommandations { get; set; }
    }
}

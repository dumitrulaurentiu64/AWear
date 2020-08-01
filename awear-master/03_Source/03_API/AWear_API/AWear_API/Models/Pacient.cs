using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWear_API.Models
{
    public class Pacient : ApplicationUser
    {
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string TelephoneNumber { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public string Gender { get; set; }

        public Guid MedicId { get; set; }
        public Medic Medic { get; set; }

        public ICollection<SensorData> SensorDataList { get; set; }
        public ICollection<Warning> Warnings { get; set; }
        public ICollection<Recommandation> Recommandations { get; set; }
    }
}

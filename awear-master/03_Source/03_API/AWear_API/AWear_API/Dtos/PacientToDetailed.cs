using AWear_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWear_API.Dtos
{
    public class PacientToDetailed
    {
        public Guid id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime Created { get; set; }
        public string CNP { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string TelephoneNumber { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public string Gender { get; set; }

        public Medic Medic { get; set; }

        public Guid MedicId { get; set; }

        public ICollection<SensorData> SensorDataList { get; set; }
        public ICollection<Warning> Warnings { get; set; }
        public ICollection<Recommandation> Recommandations { get; set; }
    }
}

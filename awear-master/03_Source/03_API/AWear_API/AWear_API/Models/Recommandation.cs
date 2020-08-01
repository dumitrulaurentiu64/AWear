using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWear_API.Models
{
    public class Recommandation
    {
        public Guid Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public string RecMessage { get; set; }

        public Guid MedicId { get; set; }
        public Medic IssuedByMedic { get; set; }

        public Guid PacientId { get; set; }
        public Pacient IssuedToPacient { get; set; }
    }
}

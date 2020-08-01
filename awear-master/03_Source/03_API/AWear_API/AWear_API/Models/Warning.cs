using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWear_API.Models
{
    public class Warning
    {
        public Guid Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public string WarningMessage { get; set; }

        public Guid PacientId { get; set; }
        public Pacient IssuedToPacient { get; set; }
    }
}

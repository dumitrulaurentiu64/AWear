using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWear_API.Models
{
    public class SensorData
    {
        public Guid Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public double Pulse { get; set; }
        public double EKGValue { get; set; }

        public Guid PacientId { get; set; }
        public Pacient SensorDataOfPacient { get; set; }
     
    }
}

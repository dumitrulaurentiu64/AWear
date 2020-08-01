using AWear_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWear_API.Dtos
{
    public class SensorDataToAddDto
    {
        public DateTime TimeStamp { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public double Pulse { get; set; }
        public double EKGValue { get; set; }

        public SensorDataToAddDto()
        {
            TimeStamp = DateTime.Now;
        }
    }
}

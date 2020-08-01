using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWear_API.Dtos
{
    public class WarningToAdd
    {
        public DateTime TimeStamp { get; set; }
        public string WarningMessage { get; set; }

        public WarningToAdd()
        {
            TimeStamp = DateTime.Now;
        }
    }
}

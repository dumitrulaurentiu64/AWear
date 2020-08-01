using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWear_API.Dtos
{
    public class RecommandationToAdd
    {
        public DateTime TimeStamp { get; set; }
        public string RecMessage { get; set; }

        public RecommandationToAdd()
        {
            TimeStamp = DateTime.Now;
        }
    }
}

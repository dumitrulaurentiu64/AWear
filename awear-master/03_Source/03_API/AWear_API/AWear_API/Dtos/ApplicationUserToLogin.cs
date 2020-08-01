using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWear_API.Dtos
{
    public class ApplicationUserToLogin
    {
        public string email { get; set; }
        public string password { get; set; }
    }
}

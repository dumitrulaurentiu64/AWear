using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWear_API.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string CNP { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime Created { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}

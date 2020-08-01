using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWear_API.Models
{
    public class UserRole : IdentityUserRole<Guid>
    {
        public ApplicationUser ApplicationUser { get; set; }
        public Role Role { get; set; }
    }
}

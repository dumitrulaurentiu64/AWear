using AWear_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWear_API.Data
{
    interface IAuthRepository
    {
        Task<ApplicationUser> RegisterGenericUser(ApplicationUser applicationUser, string password);
        Task<Medic> RegisterMedic(Medic medic, string password);
        Task<Pacient> RegisterPacient(Pacient pacient, string password);

        Task<ApplicationUser> LoginGenericUser(string username,string password);

        Task<bool> UserExists(string username);
    }
}

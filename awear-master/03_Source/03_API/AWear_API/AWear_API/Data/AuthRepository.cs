using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AWear_API.Models;
using Microsoft.EntityFrameworkCore;

namespace AWear_API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<ApplicationUser> LoginGenericUser(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);

            if (user == null)
                return null;

            return user;
        }

        public async Task<ApplicationUser> RegisterGenericUser(ApplicationUser applicationUser, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            await _context.Users.AddAsync(applicationUser);

            await _context.SaveChangesAsync();

            return applicationUser;

        }

        public async Task<Medic> RegisterMedic(Medic medic, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            await _context.Users.AddAsync(medic);

            await _context.SaveChangesAsync();

            return medic;
        }

        public async Task<Pacient> RegisterPacient(Pacient pacient, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            await _context.Users.AddAsync(pacient);

            await _context.SaveChangesAsync();

            return pacient;
        }

        public async Task<bool> UserExists(string username)
        {
            if (await _context.Users.AnyAsync(x => x.UserName == username))
                return true;

            return false;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}

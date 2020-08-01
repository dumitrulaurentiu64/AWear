using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AWear_API.Models;
using Microsoft.EntityFrameworkCore;

namespace AWear_API.Data
{
    public class ClinicRepository : IClinicRepository
    {
        private readonly DataContext _context;

        public ClinicRepository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<ApplicationUser> GetGenericUser(Guid id, bool isCurrentUser)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            return user;
        }

        public async Task<Medic> GetMedic(Guid id, bool isCurrentUser)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            return (Medic)user;
        }

        public async Task<Pacient> GetPacient(Guid id, bool idCurrentUser)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            return (Pacient)user;
        }

        public async Task<IEnumerable<ApplicationUser>> GetMedics()
        {
            var medics = await _context.Users.ToListAsync();

            return medics;
        }

        public async Task<IEnumerable<Pacient>> GetPacientsForMedic(Guid MedicId)
        {
            var users = _context.Users.AsQueryable();
            var pacients = from user in users where user is Pacient select (Pacient)user;
            var pacientsOfMedic = pacients.Where(u => u.MedicId == MedicId);
            return await pacientsOfMedic.ToListAsync();
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<SensorData>> GetSensorDataOfPacientAsync(Guid PacientId)
        {
            var sensorDatas = _context.SensorData.AsQueryable();

            sensorDatas = sensorDatas.Where(u => u.PacientId == PacientId);

            return await sensorDatas.ToListAsync();
        }

        public async Task<IEnumerable<Warning>> GetWarningsOfPacient(Guid PacientId)
        {
            var warnings = _context.Warnings.AsQueryable();

            warnings = warnings.Where(u => u.PacientId == PacientId);

            return await warnings.ToListAsync();
        }

        public async Task<IEnumerable<Recommandation>> GetRecommandationsOfPacientByMedic(Guid PacientId, Guid MedicId)
        {
            var recommandations = _context.Recommandations.AsQueryable();

            recommandations = recommandations.Where(u => u.PacientId == PacientId );
            recommandations = recommandations.Where(u => u.MedicId == MedicId);

            return await recommandations.ToListAsync();
        }
    }
}

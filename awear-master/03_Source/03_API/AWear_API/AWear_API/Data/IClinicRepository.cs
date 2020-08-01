using AWear_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWear_API.Data
{
    public interface IClinicRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<ApplicationUser> GetGenericUser(Guid id, bool isCurrentUser);
        Task<Medic> GetMedic(Guid id, bool isCurrentUser);
        Task<Pacient> GetPacient(Guid id, bool idCurrentUser);
        Task<IEnumerable<Pacient>> GetPacientsForMedic(Guid MedicId);
        Task<IEnumerable<ApplicationUser>> GetMedics();
        Task<IEnumerable<SensorData>> GetSensorDataOfPacientAsync(Guid PacientId);
        Task<IEnumerable<Warning>> GetWarningsOfPacient(Guid PacientId);
        Task<IEnumerable<Recommandation>> GetRecommandationsOfPacientByMedic(Guid PacientId, Guid MedicId);
    }
}

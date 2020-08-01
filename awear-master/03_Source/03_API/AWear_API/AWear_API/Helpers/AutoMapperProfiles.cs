using AutoMapper;
using AWear_API.Dtos;
using AWear_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWear_API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<MedicToRegister, Medic>();
            CreateMap<Medic, MedicForDetaildDto>();
            CreateMap<PacientToRegisterDto, Pacient>();
            CreateMap<Pacient, PacientToDetailed>();
            CreateMap<SensorDataToAddDto, SensorData>();
            CreateMap<RecommandationToAdd, Recommandation>();
            CreateMap<WarningToAdd, Warning>();
        }
       
    }
}

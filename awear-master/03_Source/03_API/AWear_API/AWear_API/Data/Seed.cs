using AWear_API.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWear_API.Data
{
    public class Seed
    {
        private readonly UserManager<ApplicationUser> _genericUserManager;
       // private readonly UserManager<Medic> _medicUserManager;
       // private readonly UserManager<Pacient> _pacientUserManager;
        private readonly RoleManager<Role> _roleManager;

        public Seed(UserManager<ApplicationUser> genericUserManager, RoleManager<Role> roleManager)
        {
            _genericUserManager = genericUserManager;
            _roleManager = roleManager;
        }

        public void SeedUsers()
        {
            if (!_genericUserManager.Users.Any())
            {
                
                var roles = new List<Role>
                {
                    new Role{Name = "Admin"},
                    new Role{Name = "Medic"},
                    new Role{Name = "Pacient"}
                };

                foreach (var role in roles)
                {
                    _roleManager.CreateAsync(role).Wait();
                }

                var medic = new Medic()
                {
                    Id = Guid.NewGuid(),
                    Created = DateTime.Now,
                    CNP = "1950312180589",
                    FirstName = "MedicFirstName",
                    LastName = "MedicLastName",
                    Email = "medic@gmail.com",
                    UserName = "MeMedic",
                    FieldOfPractice = "Surgery",
                    ProffesionalGrades = "GeneralMedicine",
                    CabinetHours = "8-14"
                    
                };
                var pacient = new Pacient()
                {
                    Id = Guid.NewGuid(),
                    Created = DateTime.Now,
                    CNP = "1970312180789",
                    FirstName = "FirstName",
                    LastName = "LastName",
                    Email = "anemail@gmail.com",
                    UserName = "Me",
                    Address = "Tm",
                    DateOfBirth = DateTime.Now.AddYears(-22),
                    TelephoneNumber = "0722222222",
                    Height = 175,
                    Weight = 74,
                    Gender = "Male",
                    Medic = medic,
                    SensorDataList = new List<SensorData> { new SensorData
                    {
                        Id = Guid.NewGuid(),
                        TimeStamp = DateTime.Now,
                        Temperature = 20.0f,
                        Humidity = 50.0f,
                        Pulse = 120.0f,
                        EKGValue = 20.0f
                    }},
                    

                };
                var genUser = new ApplicationUser()
                {
                    Id = Guid.NewGuid(),
                    Created = DateTime.Now,
                    CNP = "1970312180788",
                    FirstName = "TheGreat",
                    LastName = "Admin",
                    Email = "balanescuadrian71@gmail.com",
                    UserName = "Admin"
                };

                _genericUserManager.CreateAsync(genUser, "password").Wait();
                _genericUserManager.AddToRoleAsync(genUser, "Admin").Wait();

                _genericUserManager.CreateAsync(medic, "password").Wait();
                _genericUserManager.CreateAsync(pacient, "password").Wait();

                _genericUserManager.AddToRoleAsync(pacient, "Pacient").Wait();
                _genericUserManager.AddToRoleAsync(medic, "Medic").Wait();



                //IdentityResult result = _genericUserManager.CreateAsync(genUser, "password").Result;
              

               // if (result.Succeeded)
               // {
                //    var admin = _genericUserManager.FindByNameAsync("Admin").Result;
               //     _genericUserManager.AddToRolesAsync(admin, new[] { "Admin" }).Wait();

               // }
            }
        }
    }
}

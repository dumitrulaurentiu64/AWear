using AWear_API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWear_API.Data
{
    public class DataContext : IdentityDbContext<ApplicationUser, Role, Guid, 
        IdentityUserClaim<Guid>, UserRole, IdentityUserLogin<Guid>, 
        IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<SensorData> SensorData { get; set; }
        public DbSet<Recommandation> Recommandations { get; set; }
        public DbSet<Warning> Warnings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.ApplicationUser)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            builder.Entity<Medic>().Property(p => p.Id).IsRequired().HasDefaultValue(Guid.NewGuid());
            builder.Entity<Medic>().Property(p => p.UserName).HasMaxLength(50);
            builder.Entity<Medic>().Property(p => p.Email).IsRequired(); // TODO - add email validation using fluent API design
            builder.Entity<Medic>().HasMany(p => p.Pacients).WithOne(p => p.Medic).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Medic>().HasMany(p => p.Recommandations).WithOne(p => p.IssuedByMedic).OnDelete(DeleteBehavior.Restrict);
            
            builder.Entity<Pacient>().Property(p => p.Id).IsRequired().HasDefaultValue(Guid.NewGuid());
            builder.Entity<Pacient>().Property(p => p.UserName).IsRequired().HasMaxLength(50);
            builder.Entity<Pacient>().Property(p => p.Email).IsRequired(); // TODO - add email validation using fluent API design
            builder.Entity<Pacient>().HasMany(p => p.SensorDataList).WithOne(p => p.SensorDataOfPacient).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Pacient>().HasMany(p => p.Warnings).WithOne(p => p.IssuedToPacient).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Pacient>().HasMany(p => p.Recommandations).WithOne(p => p.IssuedToPacient).OnDelete(DeleteBehavior.Restrict);
           // builder.Entity<Pacient>().HasOne(e => e.Medic).WithMany(c => c.Pacients).OnDelete(DeleteBehavior.Restrict);

            builder.Entity<SensorData>().HasKey(p => p.Id);
            builder.Entity<SensorData>().Property(p => p.Id).IsRequired().HasDefaultValue(Guid.NewGuid());
            //builder.Entity<SensorData>().HasOne(p => p.SensorDataOfPacient);
            

            builder.Entity<Recommandation>().HasKey(p => p.Id);
            builder.Entity<Recommandation>().Property(p => p.Id).IsRequired().HasDefaultValue(Guid.NewGuid());
            //builder.Entity<Recommandation>().HasOne(p => p.IssuedToPacient);
            //builder.Entity<Recommandation>().HasOne(p => p.IssuedByMedic);

            builder.Entity<Warning>().HasKey(p => p.Id);
            builder.Entity<Warning>().Property(p => p.Id).IsRequired().HasDefaultValue(Guid.NewGuid());
           // builder.Entity<Warning>().HasOne(p => p.IssuedToPacient);


        }
    }
}

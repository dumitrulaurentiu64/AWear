﻿// <auto-generated />
using System;
using AWear_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AWear_API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20190529174539_InitialMig")]
    partial class InitialMig
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AWear_API.Models.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new Guid("239f63d0-2395-4775-9e07-b92277cadd4d"));

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("CNP");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("ApplicationUser");
                });

            modelBuilder.Entity("AWear_API.Models.Recommandation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new Guid("4fbcf7db-b36a-4aab-aba9-1bc462de860c"));

                    b.Property<Guid>("MedicId");

                    b.Property<Guid>("PacientId");

                    b.Property<string>("RecMessage");

                    b.Property<DateTime>("TimeStamp");

                    b.HasKey("Id");

                    b.HasIndex("MedicId");

                    b.HasIndex("PacientId");

                    b.ToTable("Recommandations");
                });

            modelBuilder.Entity("AWear_API.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("AWear_API.Models.SensorData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new Guid("177dc651-0629-46af-bd35-7c9361b872a6"));

                    b.Property<double>("EKGValue");

                    b.Property<double>("Humidity");

                    b.Property<Guid>("PacientId");

                    b.Property<double>("Pulse");

                    b.Property<double>("Temperature");

                    b.Property<DateTime>("TimeStamp");

                    b.HasKey("Id");

                    b.HasIndex("PacientId");

                    b.ToTable("SensorData");
                });

            modelBuilder.Entity("AWear_API.Models.UserRole", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<Guid>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("AWear_API.Models.Warning", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new Guid("5b9ccc29-ea09-4a75-8f73-fa50f3da2fc7"));

                    b.Property<Guid>("PacientId");

                    b.Property<DateTime>("TimeStamp");

                    b.Property<string>("WarningMessage");

                    b.HasKey("Id");

                    b.HasIndex("PacientId");

                    b.ToTable("Warnings");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<Guid>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("AWear_API.Models.Medic", b =>
                {
                    b.HasBaseType("AWear_API.Models.ApplicationUser");

                    b.Property<string>("CabinetHours");

                    b.Property<string>("FieldOfPractice");

                    b.Property<string>("ProffesionalGrades");

                    b.HasDiscriminator().HasValue("Medic");
                });

            modelBuilder.Entity("AWear_API.Models.Pacient", b =>
                {
                    b.HasBaseType("AWear_API.Models.ApplicationUser");

                    b.Property<string>("Address");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Gender");

                    b.Property<double>("Height");

                    b.Property<Guid>("MedicId");

                    b.Property<string>("TelephoneNumber");

                    b.Property<double>("Weight");

                    b.HasIndex("MedicId");

                    b.HasDiscriminator().HasValue("Pacient");
                });

            modelBuilder.Entity("AWear_API.Models.Recommandation", b =>
                {
                    b.HasOne("AWear_API.Models.Medic", "IssuedByMedic")
                        .WithMany("Recommandations")
                        .HasForeignKey("MedicId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("AWear_API.Models.Pacient", "IssuedToPacient")
                        .WithMany("Recommandations")
                        .HasForeignKey("PacientId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("AWear_API.Models.SensorData", b =>
                {
                    b.HasOne("AWear_API.Models.Pacient", "SensorDataOfPacient")
                        .WithMany("SensorDataList")
                        .HasForeignKey("PacientId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("AWear_API.Models.UserRole", b =>
                {
                    b.HasOne("AWear_API.Models.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AWear_API.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AWear_API.Models.Warning", b =>
                {
                    b.HasOne("AWear_API.Models.Pacient", "IssuedToPacient")
                        .WithMany("Warnings")
                        .HasForeignKey("PacientId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("AWear_API.Models.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("AWear_API.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("AWear_API.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("AWear_API.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AWear_API.Models.Pacient", b =>
                {
                    b.HasOne("AWear_API.Models.Medic", "Medic")
                        .WithMany("Pacients")
                        .HasForeignKey("MedicId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}

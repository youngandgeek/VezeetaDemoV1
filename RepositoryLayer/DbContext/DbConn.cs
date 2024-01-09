using DomainLayer.Entities;
using DomainLayer.Enums;
using DomainLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.DbContext
{
    public class DbConn : IdentityDbContext<ApplicationUser>
    {
        public DbConn(DbContextOptions options) : base(options)
        {
        }

        public DbConn()
        {
        }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Appointment> Appointments { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<ApplicationUser>()
                .HasMany(user => user.PatientBookings)
            .WithOne(booking => booking.Patient)
                .HasForeignKey(booking => booking.PatientId);

            builder.Entity<ApplicationUser>()
                .HasMany(user => user.DoctorBookings)
            .WithOne(booking => booking.Doctor)
                .HasForeignKey(booking => booking.DoctorId);

            builder.Entity<ApplicationUser>()
                .HasMany(user => user.Appointments)
                .WithOne(appointment => appointment.Doctor)
                .HasForeignKey(appointment => appointment.DoctorId);

            // Your identity role configurations...

            var adminRoleName = GetEnumDisplayName(Role.Admin);

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = adminRoleName,
ConcurrencyStamp="1",
                NormalizedName = adminRoleName.ToUpper()
            });
            var patientRoleName = GetEnumDisplayName(Role.Patient);

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = patientRoleName,
                ConcurrencyStamp = "2",

                NormalizedName = patientRoleName.ToUpper()
            });
            var doctorRoleName = GetEnumDisplayName(Role.Doctor);

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = doctorRoleName,
                ConcurrencyStamp = "3",

                NormalizedName = doctorRoleName.ToUpper()
            });

        }

        // Helper method to get the display name of an enum value
        private static string GetEnumDisplayName(Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var displayAttribute = (DisplayAttribute)Attribute.GetCustomAttribute(field, typeof(DisplayAttribute));

            return displayAttribute?.Name ?? value.ToString();

        }
    }
}

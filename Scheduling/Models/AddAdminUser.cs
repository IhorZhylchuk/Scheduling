using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scheduling.Models
{
    public static class AddAdminUser
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            /*
            const string ADMIN_ID = "a18be9c0-aa65-4af8-bd17-00bd9344e575";
            const string ROLE_ADM_ID = ADMIN_ID + "2b1";

            const string DOCTORS_ID = "a12ne9c5-ba65-4af6-bd97-00bd9344d32376";
            const string ROLE_DOCTOR_ID = DOCTORS_ID + "3dv";

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = ROLE_ADM_ID,
                Name = "Admin"
            },
            new IdentityRole
            {
                Id = ROLE_DOCTOR_ID,
                Name = "Doctor"
            });


            var hasher = new PasswordHasher<MyUsersIdentity>();

            MyUsersIdentity admin = new MyUsersIdentity
            {
                Id = ADMIN_ID,
                Name = "Sara",
                NormalizedUserName = "Sara",
                UserName = "Sara",
                Surname = "Konor",
                EmailConfirmed = true,
                TelNumber = "+485756451",
                Email = "sara@gmail.com",
                NormalizedEmail = "sara@gmail.com",
                Gender = "Female",
                PasswordHash = hasher.HashPassword(null, "demo"),
                SecurityStamp = string.Empty
            };

            List<DoctorsIdentity> myDoctors = new List<DoctorsIdentity>()
            {
                new DoctorsIdentity
                {
                Id = DOCTORS_ID,
                Name = "Peter",
                NormalizedUserName = "Peter",
                UserName = "Peter",
                EmailConfirmed = true,
                NormalizedEmail = "petegriu@gmail.com",
                Surname = "Petegriu",
                TelNumber = "+48434343444",
                Email = "petegriu@gmail.com",
                Specialization = "Allergist/Immunologist",
                PasswordHash = hasher.HashPassword(null, "demo"),
                SecurityStamp = string.Empty
                },
                new DoctorsIdentity
                {
                Id = DOCTORS_ID+"1d",
                Name = "Anna",
                UserName = "Anna",
                NormalizedEmail = "soros@gmail.com",
                NormalizedUserName = "Anna",
                EmailConfirmed = true,
                Surname = "Soros",
                TelNumber = "+48434343444",
                Email = "soros@gmail.com",
                Specialization = "Cardiologist",
                PasswordHash = hasher.HashPassword(null, "demo"),
                SecurityStamp = string.Empty
                },
                new DoctorsIdentity
                {
                Id = DOCTORS_ID+"2d",
                Name = "Julia",
                UserName = "Julia",
                NormalizedUserName = "Julia",
                NormalizedEmail = "stupak@gmail.com",
                EmailConfirmed = true,
                Surname = "Stupak",
                TelNumber = "+48434343444",
                Email = "stupak@gmail.com",
                Specialization = "Dermatologist",
                PasswordHash = hasher.HashPassword(null, "demo"),
                SecurityStamp = string.Empty
                }
            };

            
            ReservationModel reservation = new ReservationModel
            {
                Date = new DateTime().Date,
                Id = 1,
                Doctor = null,
                Time = "08:00"
            };
            
            
           // modelBuilder.Entity<MyUsersIdentity>().HasData(admin);
            modelBuilder.Entity<DoctorsIdentity>().HasData(myDoctors);
            modelBuilder.Entity<ReservationModel>().HasData(reservation);
            
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ADM_ID,
                UserId = ADMIN_ID
            }
            ,
            new IdentityUserRole<string>
            {
                RoleId = ROLE_DOCTOR_ID,
                UserId = DOCTORS_ID
            },
            new IdentityUserRole<string>
            {
                RoleId = ROLE_DOCTOR_ID,
                UserId = DOCTORS_ID + "1d"
            },
            new IdentityUserRole<string>
            {
                RoleId = ROLE_DOCTOR_ID,
                UserId = DOCTORS_ID + "2d"
            }
           
            );
            */

            const string ADMIN_ID = "a18be9c0-aa65-4af8-bd17-00bd9344e575";
            const string ROLE_ADM_ID = ADMIN_ID;

            const string DOCTORS_ID = "a12be9c5-aa65-4af6-bd97-00bd9344e575";
            const string ROLE_DOCTOR_ID = DOCTORS_ID;

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = ROLE_ADM_ID,
                Name = "Admin"
            },
            new IdentityRole
            {
                Id = ROLE_DOCTOR_ID,
                Name = "Doctor"
            });


            var hasher = new PasswordHasher<MyUsersIdentity>();

            List<MyUsersIdentity> defaultUsers = new List<MyUsersIdentity>()
            {
                new MyUsersIdentity
            {
                Id = ADMIN_ID,
                Name = "Sara",
                NormalizedUserName = "Sara",
                UserName = "Sara",
                Surname = "Konor",
                EmailConfirmed = true,
                TelNumber = "+485756451",
                Email = "sara@gmail.com",
                NormalizedEmail = "sara@gmail.com",
                Gender = "Female",
                PasswordHash = hasher.HashPassword(null, "demo"),
                ProfileImagePath = "doctor.png",
                SecurityStamp = string.Empty
            },

            new MyUsersIdentity
                {
                Id = DOCTORS_ID,
                Name = "Peter",
                NormalizedUserName = "Peter",
                UserName = "Peter",
                EmailConfirmed = true,
                NormalizedEmail = "petegriu@gmail.com",
                Surname = "Petegriu",
                TelNumber = "+48434343444",
                Email = "petegriu@gmail.com",
                Specialization = "Allergist/Immunologist",
                PasswordHash = hasher.HashPassword(null, "demo"),
                ProfileImagePath = "doctor_1.png",
                SecurityStamp = string.Empty
                },
                new MyUsersIdentity
                {
                Id = DOCTORS_ID+"1d",
                Name = "Anna",
                UserName = "Anna",
                NormalizedEmail = "soros@gmail.com",
                NormalizedUserName = "Anna",
                EmailConfirmed = true,
                Surname = "Soros",
                TelNumber = "+48434343444",
                Email = "soros@gmail.com",
                Specialization = "Cardiologist",
                PasswordHash = hasher.HashPassword(null, "demo"),
                ProfileImagePath = "doctor.png",
                SecurityStamp = string.Empty
                },
                new MyUsersIdentity
                {
                Id = DOCTORS_ID+"2d",
                Name = "Julia",
                UserName = "Julia",
                NormalizedUserName = "Julia",
                NormalizedEmail = "stupak@gmail.com",
                EmailConfirmed = true,
                Surname = "Stupak",
                TelNumber = "+48434343444",
                Email = "stupak@gmail.com",
                Specialization = "Dermatologist",
                PasswordHash = hasher.HashPassword(null, "demo"),
                ProfileImagePath = "doctor.png",
                SecurityStamp = string.Empty
                }
            };
            ReservationModel reservation = new ReservationModel
            {
                Date = new DateTime().Date.ToString(),
                Id = 1,
                Specialist = "",
                Time = "08:00"
            };

            modelBuilder.Entity<MyUsersIdentity>().HasData(defaultUsers);
            modelBuilder.Entity<ReservationModel>().HasData(reservation);
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ADM_ID,
                UserId = ADMIN_ID
            }
            ,
            new IdentityUserRole<string>
            {
                RoleId = ROLE_DOCTOR_ID,
                UserId = DOCTORS_ID
            },
            new IdentityUserRole<string>
            {
                RoleId = ROLE_DOCTOR_ID,
                UserId = DOCTORS_ID + "1d"
            },
            new IdentityUserRole<string>
            {
                RoleId = ROLE_DOCTOR_ID,
                UserId = DOCTORS_ID + "2d"
            }
            );
            

        }
            
    }
}

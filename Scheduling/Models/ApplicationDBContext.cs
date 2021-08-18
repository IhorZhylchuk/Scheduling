using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scheduling.Models
{
    public class ApplicationDBContext: IdentityDbContext<MyUsersIdentity, IdentityRole, string>
    {
        public DbSet<ReservationModel> Reservations { get; set;}

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> dbContext): base(dbContext)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
            AddAdminUser.SeedData(builder);
        }
    }
}

using Airline.Admin.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline.Admin.DBContext
{
    public class AdminDbContext:DbContext
    {
        public AdminDbContext(DbContextOptions<AdminDbContext> options) : base(options)
        {

        }
        /// <summary>
        /// Create AdminLoginDetails table in Database
        /// </summary>
        public DbSet<AdminUser> tblAdminLoginDetails { set; get; }
        /// <summary>
        /// Inserting Default Vallue While creating Database
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminUser>().HasData(
              new AdminUser
              {
                  Id=1,
                  AdminId="USER1",
                  Password="Password1",
                  AdminName="NAGARAJU"
              }
              );
        }
    }
}

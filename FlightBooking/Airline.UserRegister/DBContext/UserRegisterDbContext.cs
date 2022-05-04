using Airline.UserRegister.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Airline.UserRegister.DBContext
{
    public class UserRegisterDbContext : DbContext
    {
        public UserRegisterDbContext(DbContextOptions<UserRegisterDbContext> options):base(options)
        {

        }

        public DbSet<User> UserRegistor { set; get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
           new User
           {
               UserID = 1,
               FirstName = "NAGARAJU",
               LastName = "KAKUMANI",
               mobile = "9666491876",
               Address = "BASAR",
               Email = "kakumani@gmail.com",
               Password = "Pass@word",
               DateOfBirth = DateTime.Now,

               CreatedBy = "Admin",
               CreatedDate = DateTime.Now,
               Updatedby = "Admin",
               UpdatedDate = DateTime.Now
           });
        }

    }
}

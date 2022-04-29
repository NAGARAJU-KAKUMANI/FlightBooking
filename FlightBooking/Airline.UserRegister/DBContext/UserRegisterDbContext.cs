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

        }

    }
}

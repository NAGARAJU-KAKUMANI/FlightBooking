using Airline.Booking.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline.Booking.DBContext
{
    public class ApplicationBookDbcontext :DbContext 
    {
        public ApplicationBookDbcontext(DbContextOptions<ApplicationBookDbcontext> options) : base(options)
        {

        }

        public DbSet<Bookings> tblBookings { set; get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

    }
}

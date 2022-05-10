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
        public  DbSet<Inventorys> tblInventoy { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bookings>().HasData(
              new Bookings
              {
                  TicketID = "TICK585755",
                  BookingID = "BCK125458",
                  FlightNumber = "V12345",
                  DateOfJourney = DateTime.Now.AddDays(10),
                  FromPlace = "Hyderabd",
                  ToPlace = "BASR",
                  BoardingTime = "10.00 AM",
                  EmailID = "kakumani15@gmail.com",
                  UserName = "NAGARAJU",
                  passportNumber = "V655585",
                  Age = 25,
                  SeatNumber = 2,
                  Status = 1,
                  Statusstr = "TicketBooked",
                  CreatedBy = "NAGARAJU",
                  CreatedDate = DateTime.Now,
                  Updatedby="NAGARAJU",
                  UpdatedDate=DateTime.Now,
                  Seattype=Seattype.Businessclass
              }
              );
        }

    }
}

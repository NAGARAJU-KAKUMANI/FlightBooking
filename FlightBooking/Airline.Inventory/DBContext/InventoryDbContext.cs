using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Airline.Inventory.Models;

namespace Airline.Inventory.DBContext
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
        {

        }
        public DbSet<Inventorys> tblInventories { get; set; }
        public DbSet<AirLine> tblAirLine { get; set; }
        public DbSet<Flight> tblFlight { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<AirLine>().HasData(
               new AirLine
               {
                   AirlineId = 1,
                   Name = "Cargo",
                   Address = "Hyderabad",
                   ContactNumber="9948757854"
               },
                new AirLine
                {
                    AirlineId = 2,
                    Name = "Indigo",
                    Address = "Banglore",
                    ContactNumber = "9948077376"
                }
               );
            model.Entity<Flight>().HasData(
               new Flight
               {
                   FlightID=1,
                  FlightNumber="V12345",
                  AirLineId=1,
                  FlightName="Enfield"

               },
                new Flight
                {
                    FlightID=2,
                    FlightNumber = "VF12345",
                    AirLineId = 2,
                    FlightName = "FZ-MR"
                }
               );

        }
    }
}

using Airline.Booking.DBContext;
using Airline.Booking.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline.Booking.Services
{
    public class BookingsRepository : IBookingRepository
    {
        public ApplicationBookDbcontext _bookingDbContext;
        public BookingsRepository(ApplicationBookDbcontext bookingDbContext)
        {
            _bookingDbContext = bookingDbContext;
        }

        public IEnumerable<Bookings> GetBookings()
        {
            return _bookingDbContext.tblBookings.ToList();
        }

        //public IEnumerable<Inventorys> GetInventorys()
        //{
        //    throw new NotImplementedException();
        //}

        public IEnumerable<Inventorys> GetInventorys()
        {
            return _bookingDbContext.tblInventoy.ToList();
        }

        public void Insert(Bookings bookings)
        {
            _bookingDbContext.tblBookings.Add(bookings);
            _bookingDbContext.SaveChanges();
        }

        public void UpdateBooking(Bookings bookings)
        {
            _bookingDbContext.Entry(bookings).State = EntityState.Modified;
            _bookingDbContext.SaveChanges();
        }
    }
}

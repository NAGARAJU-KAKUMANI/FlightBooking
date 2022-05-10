using Airline.Booking.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Airline.Booking.ViewModels
{
    public class BookingViewModel
    {
        public string FlightNumber { set; get; }
        [Required]
        public DateTime DateOfJourney { set; get; }
        [Required]
        public string FromPlace { set; get; }
        [Required]
        public string ToPlace { set; get; }
        [Required]
        public string BoardingTime { set; get; }
        [Required]
        [EmailAddress]
        public string EmailID { set; get; }
        [Required]
        public string CreatedBy { set; get; }
        [Required]
        public Seattype? Seattype { set; get; }
        [Required]
        public IEnumerable<UsersViewModel> usersViewModels { set; get; }
      
    }
}

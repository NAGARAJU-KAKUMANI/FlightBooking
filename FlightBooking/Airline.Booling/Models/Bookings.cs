using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Airline.Booking.Models
{
    public class Bookings
    {
        [Key]
        [Required]
        public string TicketID { set; get; }
        [Required]
        public string BookingID { set; get; }
        [Required]
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
        [StringLength(50)]
        public string UserName { set; get; }
        [Required]
        [StringLength(20)]
        public string passportNumber { set; get; }
        [Required]
        public int Age { set; get; }
        [Required]
        public int SeatNumber { set; get; }
        [Required]
        public int Status { set; get; }
        [Required]
        public string Statusstr { set; get; }
        [Required]
        public string CreatedBy { set; get; }
        [Required]
        public DateTime CreatedDate { set; get; }
        public string Updatedby { set; get; }
        public DateTime? UpdatedDate { set; get; }
        [Required]
        public Seattype? Seattype { set; get; }
    }
}

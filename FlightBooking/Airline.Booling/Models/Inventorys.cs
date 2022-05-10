using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Airline.Booking.Models
{
    public class Inventorys
    {
        [Key]
        public int InventoryId { get; set; }
        [Required]
        [StringLength(20)]
        public string FlightNumber { get; set; }
        [Required]
        public int AirLineId { get; set; }
        [Required]
        public string FromPlace { get; set; }
        [Required]
        public string ToPlace { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        [Required]
        public string startTime { set; get; }
        [Required]
        public string EndTime { set; get; }
        [Required]
        public int ScheduledDays { get; set; }
        [Required]
        public string Instrument { get; set; }
        [Required]
        public int BClassCount { get; set; }
        [Required]
        public int BclassAvailCount { set; get; }
        [Required]
        public int NBClassCount { get; set; }
        [Required]
        public int NBclassAvailableCount { set; get; }
        [Required]
        public decimal TicketCost { get; set; }
        [Required]
        public int Rows { get; set; }
        [Required]
        public int Meal { get; set; }
        [Required]
        public string CreatedBy { set; get; }
        [Required]
        public DateTime CreatedDate { set; get; }
        public string Updatedby { set; get; }
        public DateTime? UpdatedDate { set; get; }

    }
}

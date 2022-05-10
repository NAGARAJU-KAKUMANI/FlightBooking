using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Airline.Inventory.Models
{
    public class Flight
    {
        [Key]
        public int FlightID { set; get; }
        [Required]
        [StringLength(20)]
        public string FlightNumber { get; set; }
        [Required]
        public int AirLineId { get; set; }
        [Required]
        [StringLength(50)]
        public string FlightName { get; set; }
        [Required]
        public string CreatedBy { set; get; }
        [Required]
        public DateTime? CreatedDate { set; get; }
        public string Updatedby { set; get; }
        public DateTime? UpdatedDate { set; get; }
    }
}

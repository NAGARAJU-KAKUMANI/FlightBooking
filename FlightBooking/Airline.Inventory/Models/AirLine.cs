using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Airline.Inventory.Models
{
    public class AirLine
    {
        [Key]
        public int AirlineId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(200)]
        public string Address { get; set; }
        [Required]
        public string ContactNumber { get; set; }
        [Required]
        public string ActiveStatus { set; get; }
        [Required]
        public string CreatedBy { set; get; }
        [Required]
        public DateTime CreatedDate { set; get; }
        public string Updatedby { set; get; }
        public DateTime? UpdatedDate { set; get; }
    }
}

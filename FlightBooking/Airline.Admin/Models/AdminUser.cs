using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Airline.Admin.Models
{
    public class AdminUser
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string AdminId { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [StringLength(50)]
        public string AdminName { get; set; }
    }
}

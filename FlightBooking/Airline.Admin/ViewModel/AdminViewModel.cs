using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Airline.Admin.ViewModel
{
    public class AdminViewModel
    {
        [Required]
        [StringLength(20)]
        public string AdminId { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

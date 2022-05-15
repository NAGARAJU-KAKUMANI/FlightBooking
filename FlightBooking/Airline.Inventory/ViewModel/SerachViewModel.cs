using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Airline.Inventory.ViewModel
{
    public class SerachViewModel
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime FromDate { set; get; }
        [Required]
        public string FromPlace { set; get; }
        [Required]
        public string Toplace { set; get; }
    }
}

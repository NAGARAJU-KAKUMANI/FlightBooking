using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Authenticate.ViewModels
{
    public class Users
    {
        [Key]
        public int UserID { set; get; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public string FullName { set; get; }
        public string Mobile { set; get; }
        public int Role { set; get; }
      

    }
}

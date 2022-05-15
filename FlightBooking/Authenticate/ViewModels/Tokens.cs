using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authenticate.ViewModels
{
    public class Tokens
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public int Role { set; get; }
        public string Email { get; set; }
        public int UserID { set; get; }
    }
}

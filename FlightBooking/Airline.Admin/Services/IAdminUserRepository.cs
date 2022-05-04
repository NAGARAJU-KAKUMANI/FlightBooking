using Airline.Admin.Models;
using Airline.Admin.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline.Admin.Services
{
    public interface IAdminUserRepository
    {
        IEnumerable<AdminUser> GetAdminUser();
    }
}

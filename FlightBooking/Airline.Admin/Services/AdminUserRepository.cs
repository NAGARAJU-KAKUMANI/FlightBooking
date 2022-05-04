using Airline.Admin.DBContext;
using Airline.Admin.Models;
using Airline.Admin.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline.Admin.Services
{
    public class AdminUserRepository : IAdminUserRepository
    {
        public AdminDbContext _adminDbContext;
        public AdminUserRepository(AdminDbContext adminDbContext)
        {
            _adminDbContext = adminDbContext;
        }
        public IEnumerable<AdminUser> GetAdminUser()
        {
            return _adminDbContext.tblAdminLoginDetails.ToList();    
        }
    }
}

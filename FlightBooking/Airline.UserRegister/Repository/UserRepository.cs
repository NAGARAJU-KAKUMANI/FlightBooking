using Airline.UserRegister.DBContext;
using Airline.UserRegister.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline.UserRegister.Repository
{
    public class UserRepository : IUserRepository
    {
        public UserRegisterDbContext _UserRegisterDbContext;

        public UserRepository(UserRegisterDbContext userRegisterDbContext)
        {
            _UserRegisterDbContext = userRegisterDbContext;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _UserRegisterDbContext.UserRegistor.ToList();
        }

        public void insert(User user)
        {
            _UserRegisterDbContext.UserRegistor.Add(user);
            _UserRegisterDbContext.SaveChanges();
        }
    }
}

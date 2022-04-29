using Airline.UserRegister.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline.UserRegister.Repository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        void insert(User user);
    }
}

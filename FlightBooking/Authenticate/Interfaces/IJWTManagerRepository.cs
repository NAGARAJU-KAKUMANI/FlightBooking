using Authenticate.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authenticate.Interfaces
{
    public interface IJWTManagerRepository
    {
        Tokens Authenticate(Users users, bool value);
    }
}

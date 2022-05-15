using Authenticate.DBContext;
using Authenticate.Interfaces;
using Authenticate.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Authenticate.ViewModels
{
    public class JWTManagerRepository : IJWTManagerRepository
    {
        //Dictionary<string, string> UserRecords = new Dictionary<string, string>
        //{
        //    { "user1","password1"},
        //     { "user2","password2"}

        //};

        private readonly IConfiguration configuartion;

        private readonly UsersApplicationDbContext _usersDbContext;
        public JWTManagerRepository(IConfiguration iconfiguration, UsersApplicationDbContext usersDbContext)
        {
            configuartion = iconfiguration;
            _usersDbContext = usersDbContext;
        }

        
        public Tokens Authenticate(Users users, bool value)
        {
            if (value)
            {
                 Users userecordemail = _usersDbContext.tblUserRegistor.ToList().Where(o=>o.Email==users.Email || o.Mobile==users.Mobile).FirstOrDefault();
                if (userecordemail == null)
                {
                    return null;
                }
                _usersDbContext.tblUserRegistor.Add(users);
                _usersDbContext.SaveChanges();
            }
            Users userecord= _usersDbContext.tblUserRegistor.ToList().Where((x => x.Email == users.Email && x.Password == users.Password)).FirstOrDefault();
            if (userecord ==null)
            {
                return null;
            }
            
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(configuartion["JWT:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject=new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,users.Email)
                }),
                Expires=DateTime.UtcNow.AddMinutes(10),
                SigningCredentials=new SigningCredentials(new SymmetricSecurityKey(tokenKey),SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Tokens { Token = tokenHandler.WriteToken(token),Role= userecord.Role,Email=userecord.Email,UserID=userecord.UserID };
        }
    }
}

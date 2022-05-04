using Airline.UserRegister.Models;
using Airline.UserRegister.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace Airline.UserRegister.Controllers
{
    [Authorize]
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("insert-user-details")]
        public IActionResult InsertUserDetails([FromBody] User user)
        {
            try
            {
                // Validate modelState
                if (!ModelState.IsValid)
                {
                    return UnprocessableEntity(ModelState);
                }
                    using (var scope = new TransactionScope())
                    {
                        _userRepository.insert(user);
                        scope.Complete();
                        return Accepted();
                    }
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }
        /// <summary>
        /// Get All the Users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get-all-users")]
        public IActionResult GetAllUsers()
        {
            try
            {
                var users = _userRepository.GetAllUsers();
                return new OkObjectResult(users);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}

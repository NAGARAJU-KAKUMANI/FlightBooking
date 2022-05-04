using Airline.Admin.Models;
using Airline.Admin.Services;
using Airline.Admin.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline.Admin.Controllers
{
    [Authorize]
    [Route("api/admins")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        public readonly IAdminUserRepository _adminUserRepository;
        public AdminsController(IAdminUserRepository iadminUserRepository)
        {
            _adminUserRepository = iadminUserRepository;
        }
        /// <summary>
        /// Validate Admin Login Details And send Status to User
        /// </summary>
        /// <param name="adminViewModel"></param>
        /// <returns></returns>
       
        [HttpGet]
        [Route("check-admin-details")]
        public IActionResult CheckAdminDetails(AdminViewModel adminViewModel)
        {
            try
            {
                // Validate modelState
                if(!ModelState.IsValid)
                {
                    return UnprocessableEntity(ModelState);
                }
                
                IEnumerable<AdminUser> adminUser = _adminUserRepository.GetAdminUser().ToList()
                             .Where(o => o.AdminId == adminViewModel.AdminId && o.Password==adminViewModel.Password);    
                return Ok(adminUser);
              
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}

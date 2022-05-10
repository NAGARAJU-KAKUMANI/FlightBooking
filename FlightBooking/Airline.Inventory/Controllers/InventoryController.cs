using Airline.Inventory.Models;
using Airline.Inventory.Repository;
using Airline.Inventory.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace Airline.Inventory.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        public readonly IInventoryRepository _inventory;
        public InventoryController(IInventoryRepository inventory)
        {
            _inventory = inventory;
        }
        /// <summary>
        /// Search Flights user request
        /// </summary>
        /// <param name="serachViewModel"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("search-inventories")]
        public IActionResult GetAllInventories([FromBody] SerachViewModel serachViewModel)
        {
            try
            {
                // Validate modelState
                if (!ModelState.IsValid)
                {
                    return UnprocessableEntity(ModelState);
                }

                return Ok(_inventory.ShowInventories().Where(a => a.StartDate >= serachViewModel.FromDate &&
                                                               a.FromPlace.ToLower().Contains(serachViewModel.FromPlace.ToLower()) &&
                                                             a.ToPlace.ToLower().Contains(serachViewModel.Toplace.ToLower())));
            }
            catch
            {
                return BadRequest();
            }    
        }

        [HttpPost]
        [Route("PlanInventory")]
        public IActionResult AddNewInventory([FromBody] InventoryViewModel inventoryviewModel)
        {
            try
            {
                ////Validate modelState
                if (!ModelState.IsValid)
                {
                    return UnprocessableEntity(ModelState);
                }
                Inventorys inventorys = new Inventorys();
                inventorys.FlightNumber = inventoryviewModel.FlightNumber;
                inventorys.AirLineId = inventoryviewModel.AirLineId;
                inventorys.FromPlace = inventoryviewModel.FromPlace;
                inventorys.ToPlace = inventoryviewModel.ToPlace;
                inventorys.StartDate = inventoryviewModel.StartDate;
                inventorys.EndDate = inventoryviewModel.EndDate;
                inventorys.ScheduledDays =(flightAvailable?) inventoryviewModel.ScheduledDays;
                inventorys.Instrument = inventoryviewModel.Instrument;
                inventorys.BClassCount = inventoryviewModel.BClassCount;
                inventorys.NBClassCount = inventoryviewModel.NBClassCount;
                inventorys.TicketCost = inventoryviewModel.TicketCost;
                inventorys.Rows = inventoryviewModel.Rows;
                inventorys.Meal =(Meals?) inventoryviewModel.Meal;
                inventorys.CreatedBy = "Admin";
                inventorys.CreatedDate = DateTime.Now;
                inventorys.Updatedby = "Admin";
                inventorys.UpdatedDate = DateTime.Now;

                using (var scope = new TransactionScope())
                {
                    _inventory.PlanInventory(inventorys);
                    scope.Complete();
                    return Accepted();
                }
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}

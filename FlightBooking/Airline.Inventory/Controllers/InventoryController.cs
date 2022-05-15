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
    //[Authorize]
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
        [HttpPost]
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
                IEnumerable<Inventorys> inventories = _inventory.ShowInventories().ToList();
                IEnumerable<AirLine> Airline = _inventory.GetAirline().ToList();
                var flights = (from p in inventories
                              join e in Airline
                              on p.AirLineId equals e.AirlineId
                              where p.StartDate >= serachViewModel.FromDate &&
                                                               p.FromPlace.ToLower().Contains(serachViewModel.FromPlace.ToLower()) &&
                                                             p.ToPlace.ToLower().Contains(serachViewModel.Toplace.ToLower())
                              select new
                              {
                                  p.FlightNumber,
                                  e.Name,
                                  p.FromPlace,
                                  p.ToPlace,
                                  p.BclassAvailCount,
                                  p.NBclassAvailableCount,
                                  p.TicketCost,
                                  p.startTime,
                                  p.StartDate,
                                  p.EndDate,
                                  Meal = Enum.GetName(typeof(Meals), p.Meal)
                              }).ToList();

                return Ok(flights);
            }
            catch(Exception ex)
            {
                return BadRequest();
            }    
        }
        [Authorize]
        [HttpGet]
        [Route("get-all-inventories")]
        public IActionResult GetAllInventorie()
        {
            try
            {

                var posts = _inventory.ShowInventories().Select(p => new
                {
                    p.FlightNumber,
                    p.AirLineId,
                    p.FromPlace,
                    p.ToPlace,
                    p.BclassAvailCount,
                    p.NBclassAvailableCount,
                    p.TicketCost,
                    p.startTime
                });

                return Ok(posts);
            }
            catch
            {
                return BadRequest();
            }
        }
        [Authorize]
        [HttpPost]
        [Route("PlanInventory")]
        public IActionResult AddNewInventory([FromBody] InventoryViewModel inventoryviewModel)
        {
            try
            {
              IEnumerable< Inventorys> inventorys1=  _inventory.ShowInventories().ToList().Where(a => a.FlightNumber == inventoryviewModel.FlightNumber);
                if(inventorys1.Count()>0)
                {
                    return Accepted(new Status { Message = "Flight Number Already Exist" });
                }
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
                inventorys.CreatedBy = inventoryviewModel.CreatedBy;
                inventorys.CreatedDate = DateTime.Now;
                inventorys.Updatedby = "Admin";
                inventorys.UpdatedDate = DateTime.Now;

                inventorys.EndTime = inventoryviewModel.EndTime;
                inventorys.startTime = inventoryviewModel.startTime;
                inventorys.BclassAvailCount = inventoryviewModel.BClassCount;
                inventorys.NBclassAvailableCount = inventoryviewModel.NBClassCount;
                using (var scope = new TransactionScope())
                {
                    _inventory.PlanInventory(inventorys);
                    scope.Complete();
                    return Accepted(new Status { Message = "Flight Details Added Successfully" });
                }
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }
    }
}

using Airline.Inventory.Models;
using Airline.Inventory.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline.Inventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        public readonly IInventoryRepository _inventory;
        public InventoryController(IInventoryRepository inventory)
        {
            _inventory = inventory;
        }

        [HttpGet]
        [Route("GetAllInventories")]
        public IActionResult GetAllInventories()
        {
            return Ok(_inventory.ShowInventories());
        }

        [HttpPost]
        [Route("PlanInventory")]
        public void AddNewInventory(Inventorys inventory)
        {
            _inventory.PlanInventory(inventory);
        }
    }
}

using Airline.Inventory.DBContext;
using Airline.Inventory.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline.Inventory.Repository
{
    public class InventoryRepository : IInventoryRepository
    {
        public InventoryDbContext _inventoryDbContext;
        public InventoryRepository(InventoryDbContext inventoryDbContext)
        {
            _inventoryDbContext = inventoryDbContext;
        }
        public void CancelInventory(int id)
        {

        }

        public IEnumerable<AirLine> GetAirline()
        {
            return _inventoryDbContext.tblAirLine.ToList();
        }

        public void PlanInventory(Inventorys inventory)
        {
            _inventoryDbContext.tblInventoy.Add(inventory);
            _inventoryDbContext.SaveChanges();
        }

        public IEnumerable<Inventorys> ShowInventories()
        {
            return _inventoryDbContext.tblInventoy.ToList();
        }

        public void updateBookingCount(Inventorys inventorys)
        {
            _inventoryDbContext.Entry(inventorys).State = EntityState.Modified;
            _inventoryDbContext.SaveChanges();
        }
    }
}

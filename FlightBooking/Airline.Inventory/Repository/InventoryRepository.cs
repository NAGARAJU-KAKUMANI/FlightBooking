using Airline.Inventory.DBContext;
using Airline.Inventory.Models;
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

        public void PlanInventory(Inventorys inventory)
        {
            _inventoryDbContext.tblInventories.Add(inventory);
        }

        public List<Inventorys> ShowInventories()
        {
            return _inventoryDbContext.tblInventories.ToList();
        }
    }
}

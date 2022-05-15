using MassTransit;
using Airline.Inventory.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airline.Inventory.Repository;
using Airline.Inventory.Models;

namespace Airline.Inventory.Consumer
{
    public class BookingEventConsumer:IConsumer<BookingEvent>
    {
        public readonly IInventoryRepository _inventory;
        public BookingEventConsumer(IInventoryRepository inventory)
        {
            _inventory = inventory;
        }
        public Task Consume(ConsumeContext<BookingEvent> context)
        {
            try

            {
                Inventorys inventory = _inventory.ShowInventories().Where(a => //a.StartDate == context.Message.StartDate &&
                                                                     a.FromPlace.ToLower().Contains(context.Message.FromPlace.ToLower()) &&
                                                                   a.ToPlace.ToLower().Contains(context.Message.ToPlace.ToLower())&&
                                                                    a.FlightNumber == context.Message.FlightNumber
                                                                   && a.startTime == context.Message.startTime
                                                                  ).FirstOrDefault();
                if (context.Message.tickettype == 0)
                {
                    if (context.Message.Settype == 1)
                    {
                        inventory.BclassAvailCount = inventory.BclassAvailCount - context.Message.NumberOfTickets;
                        inventory.Updatedby = "user";
                        inventory.UpdatedDate = DateTime.Now;
                    }
                    else if (context.Message.Settype == 2)
                    {
                        inventory.BclassAvailCount = inventory.NBclassAvailableCount - context.Message.NumberOfTickets;
                        inventory.Updatedby = "user";
                        inventory.UpdatedDate = DateTime.Now;
                    }
                }
                else if (context.Message.tickettype == 1)
                {
                    if (context.Message.Settype == 1)
                    {
                        inventory.BclassAvailCount = inventory.BclassAvailCount +1;
                        inventory.Updatedby = "user";
                        inventory.UpdatedDate = DateTime.Now;
                    }
                    else if (context.Message.Settype == 2)
                    {
                        inventory.BclassAvailCount = inventory.NBclassAvailableCount +1;
                        inventory.Updatedby = "user";
                        inventory.UpdatedDate = DateTime.Now;
                    }
                }
                    _inventory.updateBookingCount(inventory);
                
                return Task.CompletedTask;
            }
            catch(Exception ex)
            {
                return Task.FromException(ex);
            }

        }
    }
}

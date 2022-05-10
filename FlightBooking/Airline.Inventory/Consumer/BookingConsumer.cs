using Airline.Inventory.Events;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline.Inventory.Consumer
{
    public class BookingConsumer:IConsumer<Bookingcofirm>
    {
        public Task Consume(ConsumeContext<Bookingcofirm> context)
        {
            var message = context.Message.FlightNumber;
            return Task.CompletedTask;
        }
    }
}

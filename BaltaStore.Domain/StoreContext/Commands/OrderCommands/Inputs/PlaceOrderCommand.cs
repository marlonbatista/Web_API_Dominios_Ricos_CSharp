using System;
using System.Collections.Generic;

namespace BaltaStore.Domain.StoreContext.OrderCommands.Inputs
{
    public class PlaceOrderCommand
    {
        public Guid customer { get; set; }
        public IList<OrderItemCommand> OrderItems { get; set; }
    }
}
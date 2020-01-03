using System;

namespace BaltaStore.Domain.StoreContext.OrderCommands.Inputs
{
    public class OrderItemCommand {
        public Guid Product { get; set; }
        public decimal Quantaty { get; set; }
    }
}
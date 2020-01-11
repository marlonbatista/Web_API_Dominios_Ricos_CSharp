using System;
using System.Collections.Generic;
using BaltaStore.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;

namespace BaltaStore.Domain.StoreContext.OrderCommands.Inputs
{
    public class PlaceOrderCommand : Notifiable, ICommands
    {
        public PlaceOrderCommand()
        {
            OrderItems = new List<OrderItemCommand>();
        }
        public Guid customer { get; set; }
        public IList<OrderItemCommand> OrderItems { get; set; }

        public bool Valid()
        {
            // Fail Fast Validation
            AddNotifications(new ValidationContract()
                .HasLen(customer.ToString(), 36, "Customer", "Identificador do cliente inválido")
                .IsGreaterThan(OrderItems.Count, 0, "Items", "Nenhum item do pedido foi encontrado")

                );
            return Valid();
        }
    }
}
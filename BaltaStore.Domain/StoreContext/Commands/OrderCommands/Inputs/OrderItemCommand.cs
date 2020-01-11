using System;
using BaltaStore.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;

namespace BaltaStore.Domain.StoreContext.OrderCommands.Inputs
{
    public class OrderItemCommand : Notifiable, ICommands
    {
        public Guid Product { get; set; }
        public decimal Quantaty { get; set; }

        public bool Valid()
        {
            // Fail Fast Validation
            AddNotifications(new ValidationContract()
                .HasLen(Product.ToString(), 36, "Product", "Identificador do produto é inválido")
                .IsNotNull(Quantaty, "Quantaty", "A quantidade não pode ser nula")
                
                );
            return IsValid;
        }
    }
}
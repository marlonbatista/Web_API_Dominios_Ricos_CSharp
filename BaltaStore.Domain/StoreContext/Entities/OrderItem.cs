using FluentValidator;
using System.Collections;
using System.Collections.Generic;

namespace BaltaStore.Domain.StoreContext.Entites
{
    public class OrderItem : Notifiable
    {
        //Não deve inserir o preço do produto
        public OrderItem(Product product, decimal quantaty)
        {
            Product = product;
            Quantity = quantaty;
            Price = product.Price;

            if (product.QuantityOnHand < quantaty)
                AddNotification("Quantity", "Produto fora de estoque");
        }
        public Product Product { get; private set; }
        public decimal Quantity { get; private set; }
        public decimal Price { get; private set; }
    }
}
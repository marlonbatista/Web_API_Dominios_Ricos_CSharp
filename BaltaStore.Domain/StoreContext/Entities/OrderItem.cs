namespace BaltaStore.Domain.StoreContext.Entites
{
    public class OrderItem
    {
        //Não deve inserir o preço do produto
        public OrderItem(Product product, decimal quantaty)
        {
            Product = product;
            Quantity = quantaty;
            Price = product.Price;
        }
        public Product Product { get; private set; }
        public decimal Quantity { get; private set; }
        public decimal Price { get; private set; }
    }
}
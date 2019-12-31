using BaltaStore.Domain.StoreContext.Entites;
using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Creating user
            var name = new Name("Marlon", "Batitsta");
            var document = new Document("1234567891011");
            var email = new Email("marlon.batista@batista.com");

            //Creating Product
            var mouse = new Product("Mouse", "Rato", "imagem.png", 59.90M, 10);
            var teclado = new Product("teclado", "teclado", "imagem.png", 159.90M, 10);
            var impressora = new Product("impressora", "impressora", "imagem.png", 359.90M, 10);
            var cadeira = new Product("cadeira", "cadeira", "imagem.png", 559.90M, 10);


            var c = new Customer(name, document, email, "126578965214");

            var order = new Order(c);
            //order.AddItem(new OrderItem(mouse, 5));
            //order.AddItem(new OrderItem(teclado, 5));
            //order.AddItem(new OrderItem(impressora, 5));
            //order.AddItem(new OrderItem(cadeira, 5));
            
            //Realizei o pedido
             order.Place();

            //Verificar se o pedido é válido 
            var valid = order.IsValid;

            //Simular Pagamento
            order.Pay();

            //Simular Envio
            order.Ship();

            //Simular o Cancelamento
            order.Cancel();

        }
    }
}

using BaltaStore.Domain.StoreContext.Entites;
using BaltaStore.Domain.StoreContext.Enums;
using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests
{
    [TestClass]
    public class OrderTests
    {
        private Product _mouse;
        private Product _keyboard;
        private Product _chair;
        private Product _monitor;
        private Customer _customer;
        private Order _order;

        public OrderTests()
        {

            var name = new Name("Marlon", "Batista");
            var document = new Document("41335625186");
            var email = new Email("teste@gmail.com");
            _customer = new Customer(name, document, email, "1132126545");
            _order = new Order(_customer);

            _mouse = new Product("Mouse Game", "Mouse Game", "mouse.jpg", 100M, 10);
            _keyboard = new Product("Teclado Game", "Teclado Game", "Teclado.jpg", 100M, 10);
            _chair = new Product("Cadeira Game", "Cadeira Game", "Cadeira.jpg", 100M, 10);
            _monitor = new Product("Monitor Game", "Monitor Game", "Monitor.jpg", 100M, 10);

        }
        //1º Teste se consigo criar um novo pedido
        [TestMethod]
        public void ShouldCreatedOrderWhenValid()
        {
            Assert.AreEqual(true, _order.IsValid);
        }

        // Ao criado o pedido, o status deve ser created
        [TestMethod]
        public void StatusShouldBeCreatedWhenOrderCreated()
        {
            Assert.AreEqual(EOrderStatus.Created, _order.Status);
        }

        // Ao adicionar um novo item,  a quantidade items deve mudar
        [TestMethod]
        public void ShouldReturnTwoWhenAddedTwoValidItems()
        {
            _order.AddItem(_monitor, 5);
            _order.AddItem(_mouse, 5);
            Assert.AreEqual(2, _order.Items.Count);
        }

        // Ao adicionar um novo item,  subtrair a quantidade do produto
        [TestMethod]
        public void ShouldReturnFiveWhenWhenAddedPurchasedFiveItem()
        {
            _order.AddItem(_mouse, 5);
            Assert.AreEqual(_mouse.QuantityOnHand, 5);
        }

        // Ao Confirmar o pedido, deve gerar um número
        [TestMethod]
        public void ShouldReturnANumberWhenOrderPlaced()
        {
            _order.Place();
            Assert.AreNotEqual("", _order.Number);
        }

        // Ao pagar um pedido, o status deve ser PAGO(payed)
        [TestMethod]
        public void ShouldReturnPaidWhenOrderPaid()
        {
            _order.Pay();
            Assert.AreEqual(EOrderStatus.Paid, _order.Status);
        }

        // Dados mais 10 produtos deve ter 2 entregas
        [TestMethod]
        public void ShouldReturnTwoShippingWhenPurchaseTenProducts()
        {
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);

            _order.Ship();

            Assert.AreEqual(2, _order.Deliveries.Count);
        }

        // Ao cancelar o pedido, o status deve ser cancelado
        [TestMethod]
        public void StatusShouldBeCanceledWhenOrderCanceled()
        {
            _order.Cancel();
            Assert.AreEqual(EOrderStatus.Canceled, _order.Status);
        }

        // Ao cancelar o pedido, deve cancelar as entregas
        [TestMethod]
        public void ShouldCancelShippingWhenOrderCanceled()
        {
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);

            _order.Ship();

            _order.Cancel();

            foreach (var item in _order.Deliveries)
            {
                Assert.AreEqual(EDeliveryStatus.Canceled, item.Status);
            }
        }
    }
}
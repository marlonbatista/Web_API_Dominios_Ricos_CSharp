using BaltaStore.Domain.StoreContext.CustomerCommands.Inputs;
using BaltaStore.Domain.StoreContext.OrderCommands.Inputs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests
{
    [TestClass]
    public class CreateOrderItemCommandTests
    {
        [TestMethod]
        public void ShouldValidateWhenCommandIsValid()
        {
            var command = new OrderItemCommand();
            command.Quantaty = 10;

            Assert.AreEqual(true, command.Valid());
        }

        [TestMethod]
        public void ShouldReturnFalseWhenQuantatyIsNegative()
        {
            var command = new OrderItemCommand();
            command.Quantaty =  -1;

            Assert.AreEqual(false, command.Valid());
        }

        

    }
}

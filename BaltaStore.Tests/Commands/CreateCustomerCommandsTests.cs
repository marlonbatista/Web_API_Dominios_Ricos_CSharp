using BaltaStore.Domain.StoreContext.CustomerCommands.Inputs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests
{
    [TestClass]
    public class CreateCustomerCommandTests
    {
        [TestMethod]
        public void ShouldValidateWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Zulu";
            command.LastName = "Baltieri";
            command.Document = "31876351217";
            command.Email = "zulu.baltieri@teste.com";
            command.phone = "11123456783";

            Assert.AreEqual(true, command.Valid());
        }

        [TestMethod]
        public void ShouldValidateWhenCommandIstNotValid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Zu";
            command.LastName = "Baltieri";
            command.Document = "31876351217";
            command.Email = "zulu.baltieri@teste.com";
            command.phone = "11123456783";

            Assert.AreEqual(false, command.Valid());
        }

    }
}

using BaltaStore.Domain.StoreContext.CustomerCommands.Inputs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests
{
    [TestClass]
    public class CreateAddressCommandTests
    {
        [TestMethod]
        public void ShouldValidateWhenCommandIsValid()
        {
            var command = new AddAdressCommand();
            command.Street = "Avenida Dom Carmugo do Exemplo";
            command.Number = "1234";
            command.City = "Exemplo Profundo";
            command.District = "Vale Distinto";
            command.State = "Mato Alto";
            command.ZipCode = "12654987";
            command.Country = "Summer Rifts";

            Assert.AreEqual(true, command.Valid());
        }

        [TestMethod]
        public void ShouldValidateWhenCommandIstNotValid()
        {
            var command = new AddAdressCommand();
            command.Street = "Av";
            command.Number = "1234";
            command.City = "Exemplo Profundo";
            command.District = "Vale Distinto";
            command.State = "Mato Alto";
            command.ZipCode = "12654987";
            command.Country = "Summer Rifts";

            Assert.AreEqual(false, command.Valid());
        }

    }
}

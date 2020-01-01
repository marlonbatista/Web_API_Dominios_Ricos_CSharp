using BaltaStore.Domain.StoreContext.Entites;
using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests
{
    [TestClass]
    public class NameTests
    {
        [TestMethod]
        public void ShouldReturnNotificationWhenNameIsNotValid()
        {
            var nameInvalid =  new Name("","Batista"); 
            Assert.AreEqual(false, nameInvalid.IsValid);
            Assert.AreEqual(1 , nameInvalid.Notifications.Count);
        }
    }
}

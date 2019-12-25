using BaltaStore.Domain.StoreContext.Entites;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var c = new Customer(
                "Marlon",
                "Batista",
                "1234567891011",
                "hello@balta.io",
                "1533336666",
                "Rua dos Desenvolvedores"
                );
            
            var order = new Order(c);
            
            
        }   
    }
}

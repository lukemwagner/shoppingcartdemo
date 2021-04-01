using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCart.Lib;

namespace ShoppingCart.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var testClass = new Class1();

            string result = testClass.SayHello();

            Assert.AreEqual(result, "Hello"); 
        }
    }
}

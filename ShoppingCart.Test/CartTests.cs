using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShoppingCart.Test
{
    [TestClass]
    public class MasterCartTest
    {
        [TestMethod]
        public void Cart_Total_ReturnsCorrectAmount_Test1()
        {
            // Chart containing: 1 bread, 1 butter and 1 milk should total 2.95

            Assert.Fail("Cart should total 2.95");

        }
        [TestMethod]
        public void Cart_Total_ReturnsCorrectAmount_Test2()
        {
            // Chart containing: 2 butter and 2 bread should total 3.10
            
            Assert.Fail("Cart should total 3.10");

        }
        [TestMethod]
        public void Cart_Total_ReturnsCorrectAmount_Test3()
        {
            // Chart containing: 4 milk should total 3.45
            
            Assert.Fail("Cart should total 3.45");

        }

        [TestMethod]
        public void Cart_Total_ReturnsCorrectAmount_Test4()
        {
            // Chart containing: 2 butter, 1 bread and 8 milk should total 9.00
            
            Assert.Fail("Cart should total 9.00");

        }
    }
}
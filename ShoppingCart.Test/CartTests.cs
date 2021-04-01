using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCart.Lib;


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

        [TestMethod]
        public void Products_ShouldCreateProductList()
        {
            // Test the creation of a list of products: Butter, Milk and Bread.
            // The test should succeed once the IProduct interface and StandardProduct class is full implimented.

            var productList = new List<IProduct>();

            productList.Add( new Product() { ProductID = 1, ProductName = "Butter", Price = 0.8m});
            productList.Add( new Product() { ProductID = 2, ProductName = "Milk", Price = 1.15m});
            productList.Add( new Product() { ProductID = 3, ProductName = "Bread", Price = 1m});
            
            Assert.IsTrue(productList.Count == 3, "Product List should have 3 products");

        }

                [TestMethod]
        public void Cart_ShouldAddProduct()
        {
            // Cart should accept a product and return the product

            ICartProduct product = new CartProduct() { ProductID = 1, ProductName = "Butter", Price = 0.8m, Quantity = 1};
            
            IShoppingCart cart = new ShoppingCartStandard();

            cart.AddProduct(product);

            var result = cart.GetCartProducts().FirstOrDefault();

            Assert.AreSame(product, result, "Product not added to cart");

        }

        [TestMethod]
        public void Cart_ShouldAddProduct_updateQuantity()
        {
            // Cart should update the quantity if the same Item is submitted

            ICartProduct product1 = new CartProduct() { ProductID = 1, ProductName = "Butter", Price = 0.8m, Quantity = 1};
            ICartProduct product2 = new CartProduct() { ProductID = 1, ProductName = "Butter", Price = 0.8m, Quantity = 2};

            IShoppingCart cart = new ShoppingCartStandard();

            cart.AddProduct(product1);
            cart.AddProduct(product2);

            var result = cart.GetCartProducts().FirstOrDefault();

            Assert.AreEqual(3, result.Quantity, "Product quantity not updated");

        }
        
       [TestMethod]
        public void Cart_ShouldReturnSubTotal()
        {
            // Cart should return the correct subtotal

            ICartProduct product1 = new CartProduct() { ProductID = 1, ProductName = "Butter", Price = 0.8m, Quantity = 1};
            ICartProduct product2 = new CartProduct() { ProductID = 2, ProductName = "Milk", Price = 1.15m, Quantity = 2};
            ICartProduct product3 = new CartProduct() { ProductID = 1, ProductName = "Butter", Price = 0.8m, Quantity = 1};

            IShoppingCart cart = new ShoppingCartStandard();

            cart.AddProduct(product1);
            cart.AddProduct(product2);
            cart.AddProduct(product3);

            var result = cart.SubTotal();

            Assert.AreEqual(3.9m, result, "Cart subtotal incorrect");

        }

    }

 

}
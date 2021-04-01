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

            IOffersShoppingCart cart = new ShoppingCartOffers(
                new List<IDiscountConfig>() {
                    new Buy2GetItemHalfPrice(1,3),
                    new Buy3Get4thFree(2)
                }
            );

            // add products to the cart
            cart.AddProduct( new CartProduct() { ProductID = 1, ProductName = "Butter", Price = 0.8m, Quantity = 1});
            cart.AddProduct( new CartProduct() { ProductID = 2, ProductName = "Milk", Price = 1.15m, Quantity = 1});
            cart.AddProduct( new CartProduct() { ProductID = 3, ProductName = "Bread", Price = 1m, Quantity = 1});
            
            // Cart should return 2.95
            Assert.IsTrue(cart.Total() == 2.95m, "Incorrect cart total returned");

        }
        [TestMethod]
        public void Cart_Total_ReturnsCorrectAmount_Test2()
        {
            // Chart containing: 2 butter and 2 bread should total 3.10
            
            IOffersShoppingCart cart = new ShoppingCartOffers(
                new List<IDiscountConfig>() {
                    new Buy2GetItemHalfPrice(1,3),
                    new Buy3Get4thFree(2)
                }
            );

            // add products to the cart
            cart.AddProduct( new CartProduct() { ProductID = 1, ProductName = "Butter", Price = 0.8m, Quantity = 2});
            cart.AddProduct( new CartProduct() { ProductID = 3, ProductName = "Bread", Price = 1m, Quantity = 2});
            
            // result should return 3.10
            Assert.IsTrue(cart.Total() == 3.1m, "Incorrect cart total returned");

        }
        [TestMethod]
        public void Cart_Total_ReturnsCorrectAmount_Test3()
        {
            // Chart containing: 4 X milk should total 3.45
            
            IOffersShoppingCart cart = new ShoppingCartOffers(
                new List<IDiscountConfig>() {
                    new Buy2GetItemHalfPrice(1,3),
                    new Buy3Get4thFree(2)
                }
            );

            // add products to the cart
            cart.AddProduct( new CartProduct() { ProductID = 2, ProductName = "Milk", Price = 1.15m, Quantity = 4});
            
            // result should return 3.45
            Assert.IsTrue(cart.Total() == 3.45m, "Incorrect cart total returned");

        }

        [TestMethod]
        public void Cart_Total_ReturnsCorrectAmount_Test4()
        {
            // Chart containing: 2 butter, 1 bread and 8 milk should total 9.00
            
            IOffersShoppingCart cart = new ShoppingCartOffers(
                new List<IDiscountConfig>() {
                    new Buy2GetItemHalfPrice(1,3),
                    new Buy3Get4thFree(2)
                }
            );

            // add products to the cart
            cart.AddProduct( new CartProduct() { ProductID = 1, ProductName = "Butter", Price = 0.8m, Quantity = 2});
            cart.AddProduct( new CartProduct() { ProductID = 2, ProductName = "Milk", Price = 1.15m, Quantity = 8});
            cart.AddProduct( new CartProduct() { ProductID = 3, ProductName = "Bread", Price = 1m, Quantity = 1});
            
            // result should return 9.00
            Assert.IsTrue(cart.Total() == 9.0m, "Incorrect cart total returned");

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

        [TestMethod]
        public void Discount_Buy2GetItemHalfPrice_ShouldReturnSingleDiscount()
        {
            // Discount should return half price bread (£0.50) if there are 2 butter in the cart

            var productList = new List<ICartProduct>();

            productList.Add( new CartProduct() { ProductID = 1, ProductName = "Butter", Price = 0.8m, Quantity = 2});
            productList.Add( new CartProduct() { ProductID = 2, ProductName = "Bread", Price = 1m, Quantity = 1});
            
            // create discount object by passing the product ID's to which it applies
            IDiscountConfig offer  = new Buy2GetItemHalfPrice(1,2);

            IDiscountApplied discount = offer.ApplyDiscount(productList);
            var result = discount != null ? discount.DiscountValue : 0;

            Assert.AreEqual(0.5m, result, "Discount returned incorrect value");

        }

        [TestMethod]
        public void Discount_Buy2GetItemHalfPrice_ShouldReturnMultiDiscount()
        {
            // Discount should return half price bread X 2 (£1) if there are 4 X butter in the cart

            var productList = new List<ICartProduct>();

            productList.Add( new CartProduct() { ProductID = 1, ProductName = "Butter", Price = 0.8m, Quantity = 5});
            productList.Add( new CartProduct() { ProductID = 2, ProductName = "Bread", Price = 1m, Quantity = 3});
            
            // create discount object by passing the product ID's to which it applies
            IDiscountConfig offer  = new Buy2GetItemHalfPrice(1,2);

            IDiscountApplied discount = offer.ApplyDiscount(productList);
            var result = discount != null ? discount.DiscountValue : 0;
            
            Assert.AreEqual(1m, result, "Discount returned incorrect value");

        }

        [TestMethod]
        public void Discount_Buy2GetItemHalfPrice_ShouldReturnNoDiscount()
        {
            // Discount should return null if the product list does not meet the offer requirements

            var productList = new List<ICartProduct>();

            productList.Add( new CartProduct() { ProductID = 1, ProductName = "Butter", Price = 0.8m, Quantity = 1});
            productList.Add( new CartProduct() { ProductID = 2, ProductName = "Bread", Price = 1m, Quantity = 1});
            
            // create discount object by passing the product ID's to which it applies
            IDiscountConfig offer  = new Buy2GetItemHalfPrice(1,2);

            IDiscountApplied discount = offer.ApplyDiscount(productList);
            
            Assert.AreSame(null, discount, "Discount should not return a value");

        }

        [TestMethod]
        public void Discount_Buy3Get4thFree_ShouldReturnSingleDiscount()
        {
            // Discount should 1 free item if 4 are purchased

            var productList = new List<ICartProduct>();

            productList.Add( new CartProduct() { ProductID = 1, ProductName = "Milk", Price = 1.15m, Quantity = 4});
            
            // create discount object by passing the product ID to which it applies
            IDiscountConfig offer = new Buy3Get4thFree(1);

            IDiscountApplied discount = offer.ApplyDiscount(productList);
            var result = discount != null ? discount.DiscountValue : 0;

            Assert.AreEqual(1.15m, result, "Discount returned incorrect value");

        }

        [TestMethod]
        public void Discount_Buy3Get4thFree_ShouldReturnMultiDiscount()
        {
            // Offer should return multiple discounts if the cart matches the criteria

            var productList = new List<ICartProduct>();

            productList.Add( new CartProduct() { ProductID = 1, ProductName = "Milk", Price = 1.15m, Quantity = 10});
            
            // create discount object by passing the product ID's to which it applies
            IDiscountConfig offer = new Buy3Get4thFree(1);

            IDiscountApplied discount = offer.ApplyDiscount(productList);
            var result = discount != null ? discount.DiscountValue : 0;
            
            Assert.AreEqual(2.3m, result, "Discount returned incorrect value");

        }

        [TestMethod]
        public void Discount_Buy3Get4thFree_ShouldReturnNoDiscount()
        {
            // Discount should return null if the product list does not meet the offer requirements

            var productList = new List<ICartProduct>();

            productList.Add( new CartProduct() { ProductID = 1, ProductName = "Milk", Price = 1.15m, Quantity = 3});
            
            // create discount object by passing the product ID's to which it applies
            IDiscountConfig offer = new Buy3Get4thFree(1);

            IDiscountApplied discount = offer.ApplyDiscount(productList);
            
            Assert.AreSame(null, discount, "Discount should not return a value");

        }

        [TestMethod]
        public void Cart_ShouldAddOffers()
        {
            // Cart should accept a accept a list of offers in the constructor and be retrivable.

            IOffersShoppingCart cart = new ShoppingCartOffers(
                new List<IDiscountConfig>() {
                    new Buy2GetItemHalfPrice(1,2),
                    new Buy3Get4thFree(1)
                }
            );

            var result = cart.CurrentOffers.Count();

            Assert.IsTrue(result == 2, "Offers not added to cart");

        }

        [TestMethod]
        public void Cart_AppliedOfferShouldReturn()
        {
            // Cart should return a list of applied offers

            IOffersShoppingCart cart = new ShoppingCartOffers(
                new List<IDiscountConfig>() {
                    new Buy2GetItemHalfPrice(1,2),
                    new Buy3Get4thFree(1)
                }
            );

            // add products to meet the criteria of the Buy3Get4thFree offer
            cart.AddProduct( new CartProduct() { ProductID = 1, ProductName = "Milk", Price = 1.15m, Quantity = 4});

            var result = cart.AppliedDiscounts().FirstOrDefault();

            var offerName = result != null ? result.DiscountConfig.DiscountName : string.Empty;

            Assert.IsTrue(offerName == "Buy 3 get get the 4th free", "No or incorrect offer returned");

        }

        [TestMethod]
        public void Cart_ShouldReturnTotal_WithDiscountApplied()
        {
            // Cart should return a list of applied offers

            IOffersShoppingCart cart = new ShoppingCartOffers(
                new List<IDiscountConfig>() {
                    new Buy2GetItemHalfPrice(1,2),
                    new Buy3Get4thFree(1)
                }
            );

            // add products to meet the criteria of the Buy3Get4thFree offer
            cart.AddProduct( new CartProduct() { ProductID = 1, ProductName = "Milk", Price = 1.15m, Quantity = 4});

            // result should return 1 milk free - £1.15
            var result = cart.SubTotal() - cart.Total();

            Assert.IsTrue(result == 1.15m, "Incorrect discount applied to Total");

        }

    }

}
using System;

//  standard implimentation of Product 
namespace ShoppingCart.Lib
{
    public class Product : IProduct
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
    }
}
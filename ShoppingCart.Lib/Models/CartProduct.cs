using System;

//  standard implimentation of Product 
namespace ShoppingCart.Lib
{
    public class CartProduct : Product, ICartProduct
    {
        public int Quantity { get; set; }
    }
}
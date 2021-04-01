using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.Lib
{
    public class ShoppingCartStandard : IShoppingCart
    {
        private readonly List<ICartProduct> _cartProducts = new List<ICartProduct>();

        public void AddProduct(ICartProduct Product)
        {
            // Check if product already exists in cart
            var existing = _cartProducts.FirstOrDefault(s => s.ProductID == Product.ProductID);
            if (existing != null) {
                // If so, update the quantity of the existing product
                existing.Quantity += Product.Quantity;
            }
            else {
                // add new product to cart
                _cartProducts.Add(Product);
            }
        }

        public IEnumerable<ICartProduct> GetCartProducts() 
        {
            return _cartProducts;
        }

        public decimal SubTotal()
        {
            return _cartProducts.Sum(t => t.Price * t.Quantity);
        }
    }
}

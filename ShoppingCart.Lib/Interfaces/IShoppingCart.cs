using System.Collections.Generic;

// Base interface for Shopping cart
namespace ShoppingCart.Lib
{
    public interface IShoppingCart
    {
        void AddProduct(ICartProduct Product);

        IEnumerable<ICartProduct> GetCartProducts();

        decimal SubTotal();

    }
}
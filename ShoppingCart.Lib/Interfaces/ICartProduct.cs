// Base interface for Product Items
namespace ShoppingCart.Lib
{
    public interface ICartProduct : IProduct
    {
        int Quantity { get; set; }

    }
}
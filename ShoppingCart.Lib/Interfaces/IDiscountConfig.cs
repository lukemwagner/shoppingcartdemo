using System.Collections.Generic;

// Base interface for discount configuration
namespace ShoppingCart.Lib
{
    public interface IDiscountConfig
    {
        // Read-only property to return the name of the discount
        string DiscountName { get; }

        // The Product ID initiating the discount
        int TargetProductID { get; set; }

        // The Product ID where the discount is applied
        int DiscountProductID { get; set; }

        IDiscountApplied ApplyDiscount(IEnumerable<ICartProduct> CartProducts);

    }
}
using System.Collections.Generic;

// interface to extend offers to Shopping cart
namespace ShoppingCart.Lib
{
    public interface IOffersShoppingCart : IShoppingCart
    {
        IEnumerable<IDiscountConfig> CurrentOffers { get; }
        IEnumerable<IDiscountApplied> AppliedDiscounts();
        decimal Total();

    }
}
// Base interface for discount applied item
namespace ShoppingCart.Lib
{
    public interface IDiscountApplied
    {
        // The discount applied
        IDiscountConfig DiscountConfig { get; set; }

        decimal DiscountValue { get; set; }

    }
}
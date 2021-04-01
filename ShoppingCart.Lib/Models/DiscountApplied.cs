namespace ShoppingCart.Lib
{
    public class DiscountApplied : IDiscountApplied
    {
        // The discount applied
        public IDiscountConfig DiscountConfig { get; set; }
        public decimal DiscountValue { get; set; }

    }
}
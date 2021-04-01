using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.Lib
{
    public class Buy2GetItemHalfPrice : IDiscountConfig
    {
        
        private readonly string _discountName = "Buy 2 get additional item half price";

        public Buy2GetItemHalfPrice(int TargetProduct, int DiscountProduct)
        {
            TargetProductID = TargetProduct;
            DiscountProductID = DiscountProduct;
        }

        public string DiscountName 
        { get {
            return _discountName;
        } }

        // The Product ID initiating the discount
        public int TargetProductID { get; set; }

        // The Product ID where the discount is applied
        public int DiscountProductID { get; set; }

        public IDiscountApplied ApplyDiscount(IEnumerable<ICartProduct> CartProducts)
        {
            // check pattern matches
            var targetCount = CartProducts.Where(s => s.ProductID == TargetProductID).Sum(s => s.Quantity);
            var discountCount = CartProducts.Where(s => s.ProductID == DiscountProductID).Sum(s => s.Quantity);

            // in case multiple, check the Discount product is 1-2 of the target product
            var maxQuantity = Math.Min(discountCount, Math.Floor(targetCount * 0.5));

            if (maxQuantity > 0)
            {
                // get the price of the target product
                var discountProduct = CartProducts.FirstOrDefault(s => s.ProductID == DiscountProductID);

                return new DiscountApplied() {
                    DiscountConfig = this,
                    DiscountValue = discountProduct.Price * 0.5m * Convert.ToDecimal(maxQuantity)
                };            
            }



            return null;
        }
    }
}
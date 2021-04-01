using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.Lib
{
    public class Buy3Get4thFree : IDiscountConfig
    {
        
        private readonly string _discountName = "Buy 3 get get the 4th free";

        public Buy3Get4thFree(int TargetProduct)
        {
            TargetProductID = TargetProduct;
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

            // in case multiple, check the Discount product is in multiples of 4
            var maxQuantity = Math.Floor(targetCount * 0.25);

            if (maxQuantity > 0)
            {
                // get the price of the target product
                var discountProduct = CartProducts.FirstOrDefault(s => s.ProductID == TargetProductID);

                return new DiscountApplied() {
                    DiscountConfig = this,
                    DiscountValue = discountProduct.Price * Convert.ToDecimal(maxQuantity)
                };            
            }

            return null;
        }
    }
}
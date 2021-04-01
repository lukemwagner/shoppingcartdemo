using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.Lib
{
    public class ShoppingCartOffers : ShoppingCartStandard, IOffersShoppingCart
    {
        private IEnumerable<IDiscountConfig> _currentOffers;

        public ShoppingCartOffers(IEnumerable<IDiscountConfig> CurrentOffers)
        {
            _currentOffers = CurrentOffers;
        }

        public IEnumerable<IDiscountConfig> CurrentOffers{
            get { return _currentOffers; }
        }

        public IEnumerable<IDiscountApplied> AppliedDiscounts()
        {
            var appliedDiscounts = new List<IDiscountApplied>();

            // apply each availble offer
            foreach (var offer in _currentOffers) {
                IDiscountApplied applied = offer.ApplyDiscount(base.GetCartProducts());
                if (applied != null) appliedDiscounts.Add(applied);
            }

            return appliedDiscounts;
        }

        public decimal Total()
        {
            return base.SubTotal() - AppliedDiscounts().Sum(s => s.DiscountValue);
        }
    }
}

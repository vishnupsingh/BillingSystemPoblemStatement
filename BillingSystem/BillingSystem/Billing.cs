using BillingSystem.Interfaces;
using BillingSystem.Models;
using System.Collections.Generic;
using System.Linq;

namespace BillingSystem
{
    /// <summary>
    ///     Represents a class for billing related processes.
    /// </summary>
    public class Billing: IBilling
    {
        private Cart cart;

        /// <summary>
        ///     Parameterized Constructor.
        /// </summary>
        /// <param name="cart"></param>
        public Billing(Cart cart)
        {
            this.cart = cart;
        }

        /// <summary>
        ///     A method to calcluate total cart value.
        /// </summary>
        /// <returns>A <see cref="double"/> value as total cart value.</returns>
        public double CalculateCartValue()
        {
            var totalValue = default(double);

            foreach (var item in this.cart.Items)
            {
                totalValue += (item.SKU.Price * item.Quantity);
            }

            return totalValue;
        }

        public double CalculateCartValue(IList<Promotion> promotions)
        {
            var totalValue = default(double);

            foreach (var item in this.cart.Items)
            {
                if (promotions.Any(promotion => promotion.Items.Contains(item.SKU.Id)))
                {
                    this.ApplyPromotion(item, promotions);
                }

                if (item.PromotionsApplied.HasValue)
                {
                    totalValue += item.ItemValue.Value;
                }
                else
                {
                    totalValue += (item.SKU.Price * item.Quantity);
                }

            }

            cart.TotalValue = totalValue;
            return totalValue;
        }

        public void ApplyPromotion(CartItem item, IList<Promotion> promotions)
        {
            var applicablePromotion = promotions.FirstOrDefault(promotion => promotion.Items.Contains(item.SKU.Id));
            var promotionalValue = 0d;

            if (applicablePromotion == null)
                return;

            if (applicablePromotion.Quantity == 0)
                return;

            switch (applicablePromotion.PromotionType)
            {
                case PromotionType.BulkItems:
                    {
                        if (item.Quantity >= applicablePromotion.Quantity)
                        {
                            var itemCount = item.Quantity;
                            while (itemCount >= applicablePromotion.Quantity)
                            {
                                promotionalValue += applicablePromotion.OfferValue;
                                itemCount -= applicablePromotion.Quantity;
                            }
                            promotionalValue += (itemCount * item.SKU.Price);
                            item.ItemValue = promotionalValue;
                            item.PromotionsApplied = applicablePromotion.Id;
                        }
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

        }
    }
}

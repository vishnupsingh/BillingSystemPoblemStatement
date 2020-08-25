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

        /// <summary>
        ///     A method to calcluate total cart value.
        /// </summary>
        /// <param name="promotions">List of promotions</param>
        /// <returns>A <see cref="double"/> value as total cart value.</returns>
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

        private void ApplyPromotion(CartItem item, IList<Promotion> promotions)
        {
            var applicablePromotion = promotions.FirstOrDefault(promotion => promotion.Items.Contains(item.SKU.Id));

            if (applicablePromotion == null)
                return;

            if (applicablePromotion.Quantity == 0)
                return;

            var promotionCalculator = PromotionCalculatorFactory.GetPromotionCalculator(applicablePromotion.PromotionType);
            promotionCalculator.ApplyPromotion(item, applicablePromotion);

        }
    }
}

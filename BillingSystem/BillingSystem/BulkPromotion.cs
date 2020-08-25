using BillingSystem.Interfaces;
using BillingSystem.Models;

namespace BillingSystem
{
    /// <summary>
    ///     Caculates Bulk promotion offer.
    /// </summary>
    public class BulkPromotion: IPromotionCalculator
    {
        /// <summary>
        ///     A method to apply promotion on supplied cart item.
        /// </summary>
        /// <param name="currentCartItem">The cart item.</param>
        /// <param name="promotion">Promotion to be applied.</param>
        public void ApplyPromotion(CartItem currentCartItem, Promotion promotion)
        {
            var promotionalValue = 0d;
            if (currentCartItem.Quantity >= promotion.Quantity)
            {
                var itemCount = currentCartItem.Quantity;
                while (itemCount >= promotion.Quantity)
                {
                    promotionalValue += promotion.OfferValue;
                    itemCount -= promotion.Quantity;
                }
                promotionalValue += (itemCount * currentCartItem.SKU.Price);
                currentCartItem.ItemValue = promotionalValue;
                currentCartItem.PromotionsApplied = promotion.Id;
            }
        }
    }
}

using BillingSystem.Interfaces;
using BillingSystem.Models;
using System;

namespace BillingSystem
{
    /// <summary>
    ///     Caculates Combo promotion offer.
    /// </summary>
    public class ComboPromotion: IPromotionCalculator
    {
        /// <summary>
        ///     A method to apply promotion on supplied cart item.
        /// </summary>
        /// <param name="currentCartItem">The cart item.</param>
        /// <param name="promotion">Promotion to be applied.</param>
        public void ApplyPromotion(CartItem currentCartItem, Promotion promotion)
        {
            throw new NotImplementedException();
        }
    }
}

using BillingSystem.Models;

namespace BillingSystem.Interfaces
{
    /// <summary>
    ///     A contract to implement promotion calculator.
    /// </summary>
    public interface IPromotionCalculator
    {
        /// <summary>
        ///     A method to apply promotion on supplied cart item.
        /// </summary>
        /// <param name="currentCartItem">The cart item.</param>
        /// <param name="promotion">Promotion to be applied.</param>
        void ApplyPromotion(CartItem currentCartItem, Promotion promotion);
    }
}

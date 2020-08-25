using System.Linq;
using BillingSystem.Interfaces;
using BillingSystem.Models;

namespace BillingSystem
{
    /// <summary>
    ///     Caculates Combo promotion offer.
    /// </summary>
    public class ComboPromotion: IPromotionCalculator
    {
        private Cart cart;

        /// <summary>
        ///     Paremeterized constructor.
        /// </summary>
        /// <param name="cart">Cart object.</param>
        public ComboPromotion(Cart cart)
        {
            this.cart = cart;
        }

        /// <summary>
        ///     A method to apply promotion on supplied cart item.
        /// </summary>
        /// <param name="currentCartItem">The cart item.</param>
        /// <param name="promotion">Promotion to be applied.</param>
        public void ApplyPromotion(CartItem currentCartItem, Promotion promotion)
        {
            var cartItemIds = this.cart.Items.Select(cartItem => cartItem.SKU.Id).ToList();
            if (promotion.Items.All(item => cartItemIds.Contains(item)))
            {
                var minQuantity = this.GetMinimumQuanityItem(promotion);

                foreach (var promotionalItem in promotion.Items)
                {
                    var cartItemOnOffer = cart.Items.FirstOrDefault(item => item.SKU.Id == promotionalItem);
                    cartItemOnOffer.PromotionsApplied = promotion.Id;

                    if (cartItemOnOffer.Quantity > minQuantity)
                    {
                        cartItemOnOffer.ItemValue = cartItemOnOffer.SKU.Price * (cartItemOnOffer.Quantity - minQuantity);
                    }
                    else
                    {
                        cartItemOnOffer.ItemValue = 0;
                    }
                }

                var lastComboItem = cart.Items.FirstOrDefault(item => item.SKU.Id == promotion.Items.LastOrDefault());
                lastComboItem.ItemValue += promotion.OfferValue * minQuantity;
            }
        }

        private int GetMinimumQuanityItem(Promotion promotion)
        {
            var promotionalItems = cart.Items.Where(item => promotion.Items.Contains(item.SKU.Id)).ToList();
            var cartItem = promotionalItems.ElementAt(0);
            var minQuantity = cartItem.Quantity;
            for (int i = 0; i < promotion.Items.Count; i++)
            {
                var cartItem2 = cart.Items.ElementAt(i);
                if (cartItem2.Quantity < minQuantity)
                {
                    minQuantity = cartItem2.Quantity;
                }

            }

            return minQuantity;
        }
    }
}

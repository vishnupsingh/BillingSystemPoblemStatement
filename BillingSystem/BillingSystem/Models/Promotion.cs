using System.Collections.Generic;

namespace BillingSystem.Models
{
    /// <summary>
    ///     Represents a promotion.
    /// </summary>
    public class Promotion
    {
        /// <summary>
        ///     Gets or Sets Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or Sets PromotionType.
        /// </summary>
        public PromotionType PromotionType { get; set; }

        /// <summary>
        ///     Gets or Sets Items.    
        /// </summary>
        public IList<int> Items { get; set; }

        /// <summary>
        ///     Gets or Sets OfferValue.
        /// </summary>
        public double OfferValue { get; set; }

        /// <summary>
        ///     Gets or Sets Quantity.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        ///     Gets or Sets Discount.
        /// </summary>
        public double? Discount { get; set; }
    }
}

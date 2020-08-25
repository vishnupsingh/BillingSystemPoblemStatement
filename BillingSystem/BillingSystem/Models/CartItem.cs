namespace BillingSystem.Models
{
    /// <summary>
    ///     Represents a cart item.
    /// </summary>
    public class CartItem
    {
        /// <summary>
        ///     Gets or Sets Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or Sets an SKU.
        /// </summary>
        public SKU SKU { get; set; }

        /// <summary>
        ///     Gets or Sets Quantity.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        ///     Gets or Sets the PromotionsApplied.
        /// </summary>
        public int? PromotionsApplied { get; set; }

        /// <summary>
        ///     Gets or Sets the ItemValue.    
        /// </summary>
        public double? ItemValue { get; set; }
    }
}

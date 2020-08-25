namespace BillingSystem.Models
{
    /// <summary>
    ///     Represents an SKU.
    /// </summary>
    public class SKU
    {
        /// <summary>
        ///     Default constructor.
        /// </summary>
        public SKU()
        {
            this.Quantity = 1;
        }

        /// <summary>
        ///     Gets or Sets Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or Sets Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or Sets Price.
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        ///     Gets or Sets Quantity.
        /// </summary>
        public int Quantity { get; set; }
    }
}

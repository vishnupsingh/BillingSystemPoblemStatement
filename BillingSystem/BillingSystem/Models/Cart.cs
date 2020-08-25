using System.Collections.Generic;

namespace BillingSystem.Models
{
    /// <summary>
    ///     Represents a shopping cart.
    /// </summary>
    public class Cart
    {
        /// <summary>
        ///     Default constructor.
        /// </summary>
        public Cart()
        {
            this.Items = new List<SKU>();
        }

        /// <summary>
        ///     Parameterized Consructor.
        /// </summary>
        /// <param name="items">Cart Items.</param>
        public Cart(IList<SKU> items)
        {
            this.Items = items;
        }

        /// <summary>
        ///     Gets or Sets cart items.
        /// </summary>
        public IList<SKU> Items { get; set; }
    }
}

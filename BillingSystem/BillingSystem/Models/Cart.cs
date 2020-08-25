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
            this.Items = new List<CartItem>();
        }

        /// <summary>
        ///     Parameterized Consructor.
        /// </summary>
        /// <param name="items">Cart Items.</param>
        public Cart(IList<CartItem> items)
        {
            this.Items = items;
        }

        /// <summary>
        ///     Gets or Sets cart items.
        /// </summary>
        public IList<CartItem> Items { get; set; }

        /// <summary>
        ///     Gets or Sets TotalValue.
        /// </summary>
        public double TotalValue { get; set; }
    }
}

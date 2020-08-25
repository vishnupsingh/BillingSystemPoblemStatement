using BillingSystem.Interfaces;
using BillingSystem.Models;

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
                totalValue += item.Price;
            }

            return totalValue;
        }
    }
}

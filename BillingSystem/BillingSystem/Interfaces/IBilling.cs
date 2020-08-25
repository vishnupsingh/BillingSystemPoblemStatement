using BillingSystem.Models;
using System.Collections.Generic;

namespace BillingSystem.Interfaces
{
    /// <summary>
    ///     A contract for billing class.
    /// </summary>
    interface IBilling
    {
        /// <summary>
        ///     A method to calcluate total cart value.
        /// </summary>
        /// <returns>A <see cref="double"></see> value as total cart value.</returns>
        public double CalculateCartValue();

        /// <summary>
        ///     A method to calcluate total cart value.    
        /// </summary>
        /// <param name="promotions">A list of promotions.</param>s
        /// <returns>A <see cref="double"></see> value as total cart value.</returns>
        double CalculateCartValue(IList<Promotion> promotions);
    }
}

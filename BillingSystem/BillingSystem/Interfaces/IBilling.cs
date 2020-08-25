using System.Collections.Generic;
using BillingSystem.Models;

namespace BillingSystem.Interfaces
{
    /// <summary>
    ///     A contract for billing class.
    /// </summary>
    public interface IBilling
    {
        /// <summary>
        ///     A method to calcluate total cart value.
        /// </summary>
        /// <returns>A <see cref="double"></see> value as total cart value.</returns>
        void CalculateCartValue();

        /// <summary>
        ///     A method to calcluate total cart value.    
        /// </summary>
        /// <param name="promotions">A list of promotions.</param>s
        /// <returns>A <see cref="double"></see> value as total cart value.</returns>
        void CalculateCartValue(IList<Promotion> promotions);
    }
}

namespace BillingSystem.Interfaces
{
    interface IBilling
    {
        /// <summary>
        ///     A method to calcluate total cart value.
        /// </summary>
        /// <returns>A <see cref="double"></see> value as total cart value.</returns>
        public double CalculateCartValue();
    }
}

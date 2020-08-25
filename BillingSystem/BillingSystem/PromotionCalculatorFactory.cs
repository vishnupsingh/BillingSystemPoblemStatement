using BillingSystem.Interfaces;
using BillingSystem.Models;

namespace BillingSystem
{
    /// <summary>
    ///     A factor class to generate promotion calculator.
    /// </summary>
    public class PromotionCalculatorFactory
    {
        /// <summary>
        ///     A method to create promotion calculator object.
        /// </summary>
        /// <param name="promotionType">Promotion type enum.</param>
        /// <returns>A instance of <see cref="IPromotionCalculator"/>.</returns>
        public static IPromotionCalculator GetPromotionCalculator(PromotionType promotionType)
        {
            IPromotionCalculator promotionCalculator;
            switch (promotionType)
            {
                case PromotionType.BulkItems:
                    {
                        promotionCalculator =  new BulkPromotion();
                        break;
                    }
                case PromotionType.Combo:
                    {
                        promotionCalculator = new ComboPromotion();
                        break;
                    }
                default:
                    {
                        return null;
                    }
            }

            return promotionCalculator;
        }
    }
}

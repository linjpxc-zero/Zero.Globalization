using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Zero.Globalization.Extensions
{
    /// <summary>
    ///
    /// </summary>
    public static class CurrencyExtensions
    {
        /// <summary>
        /// Get the current currency, representing the amount of zero.
        /// </summary>
        /// <param name="this">The this.</param>
        /// <returns></returns>
        public static Money Money(this CurrencyInfo @this)
        {
            return Money(@this, decimal.Zero);
        }

        /// <summary>
        /// Get the amount specified in the current currency.
        /// </summary>
        /// <param name="this">The this.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static Money Money(this CurrencyInfo @this, decimal value)
        {
            return new Money(@this, value);
        }

        /// <summary>
        /// Gets the <see cref="CurrencyInfo"/> of the specified <see cref="RegionInfo"/>.
        /// </summary>
        /// <param name="this">The this.</param>
        /// <returns></returns>
        public static CurrencyInfo GetCurrency(this RegionInfo @this)
        {
            return CurrencyInfo.FromRegion(@this);
        }

        /// <summary>
        /// Gets the <see cref="CurrencyInfo"/> of the specified <see cref="CultureInfo" />.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns></returns>
        public static CurrencyInfo GetCurrency(this CultureInfo culture)
        {
            return CurrencyInfo.FromCulture(culture);
        }

        /// <summary>
        /// Get all <see cref="RegionInfo"/> using the current currency.
        /// </summary>
        /// <param name="this">The this.</param>
        /// <returns></returns>
        public static IEnumerable<RegionInfo> GetEntities(this CurrencyInfo @this)
        {
            return CultureInfo.GetCultures(CultureTypes.AllCultures)
                .Where(culture => !(culture.IsNeutralCulture || string.IsNullOrWhiteSpace(culture.Name)))
                .Select(culture => new RegionInfo(culture.Name))
                .Where(region => string.Equals(@this.Code, region.ISOCurrencySymbol, StringComparison.OrdinalIgnoreCase));
        }
    }
}
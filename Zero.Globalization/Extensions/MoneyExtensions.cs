namespace Zero.Globalization.Extensions
{
    public static class MoneyExtensions
    {
        /// <summary>
        /// Converts to minor.
        /// </summary>
        /// <param name="this">The this.</param>
        /// <returns></returns>
        public static int ToMinor(this Money @this)
            => (int)(@this / @this.Currency.MinorUnit);

        /// <summary>
        /// Converts to.
        /// </summary>
        /// <param name="this">The this.</param>
        /// <param name="currency">The currency.</param>
        /// <param name="rate">The rate.</param>
        /// <returns></returns>
        public static Money ConvertTo(this Money @this, CurrencyInfo currency, decimal rate)
        {
            if (@this.Currency == currency)
            {
                return @this;
            }
            return new ExchangeRate(@this.Currency, currency, rate).Convert(@this);
        }

        /// <summary>
        /// Converts to.
        /// </summary>
        /// <param name="this">The this.</param>
        /// <param name="rate">The rate.</param>
        /// <returns></returns>
        public static Money ConvertTo(this Money @this, ExchangeRate rate)
            => rate.Convert(@this);
    }
}
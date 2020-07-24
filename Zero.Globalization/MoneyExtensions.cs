namespace Zero.Globalization
{
    public static class MoneyExtensions
    {
        /// <summary>
        /// Converts to minor.
        /// </summary>
        /// <param name="this">The this.</param>
        /// <returns></returns>
        public static int ToMinor(this Money @this)
        {
            return (int)(@this / @this.Currency.MinorUnit);
        }
    }
}
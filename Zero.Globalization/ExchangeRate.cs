using System;

namespace Zero.Globalization
{
    /// <summary>
    /// A conversion of money of one currency into money of another currency
    /// </summary>
    /// <seealso cref="System.IEquatable{Zero.Globalization.ExchangeRate}" />
    [Serializable]
    public readonly struct ExchangeRate : IEquatable<ExchangeRate>
    {
        /// <summary>
        /// Get a value representing the base currency.
        /// </summary>
        /// <value>
        /// The basic currency.
        /// </value>
        public CurrencyInfo BasicCurrency { get; }

        /// <summary>
        /// Get a value representing the quote currency.
        /// </summary>
        /// <value>
        /// The quote currency.
        /// </value>
        public CurrencyInfo QuoteCurrency { get; }

        /// <summary>
        /// Get a value representing the value of the exchange rate.
        /// </summary>
        /// <value>
        /// The rate.
        /// </value>
        public decimal Rate { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExchangeRate"/> struct.
        /// </summary>
        /// <param name="basicCurrency">The basic currency.</param>
        /// <param name="quoteCurrency">The quote currency.</param>
        /// <param name="rate">The exchange rate.</param>
        /// <exception cref="ArgumentException">
        /// rate
        /// </exception>
        public ExchangeRate(CurrencyInfo basicCurrency, CurrencyInfo quoteCurrency, decimal rate)
        {
            if (basicCurrency == quoteCurrency)
            {
                throw new ArgumentException(string.Empty);
            }

            if (rate < 0)
            {
                throw new ArgumentException(string.Empty, nameof(rate));
            }

            this.BasicCurrency = basicCurrency;
            this.QuoteCurrency = quoteCurrency;
            this.Rate = rate;
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        ///   <see langword="true" /> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <see langword="false" />.
        /// </returns>
        public bool Equals(ExchangeRate other)
        {
            return BasicCurrency.Equals(other.BasicCurrency) && QuoteCurrency.Equals(other.QuoteCurrency) && Rate == other.Rate;
        }

        /// <summary>
        /// Converts the specified money.
        /// </summary>
        /// <param name="money">The money.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">money</exception>
        public Money Convert(Money money)
        {
            if (money.Currency == this.BasicCurrency)
            {
                return new Money(this.QuoteCurrency, (decimal)money * this.Rate);
            }

            if (money.Currency == QuoteCurrency)
            {
                return new Money(this.BasicCurrency, (decimal)money / this.Rate);
            }
            throw new ArgumentException(string.Empty, nameof(money));
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            return obj is ExchangeRate other && Equals(other);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(this.BasicCurrency, this.QuoteCurrency, this.Rate);
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"{this.BasicCurrency.Code}/{this.QuoteCurrency.Code} {this.Rate}";
        }

        /// <summary>
        /// Converts the string representation of an exchange rate to its <see cref="ExchangeRate"/> equivalent. A return value indicates whether the conversion succeeded or failed.
        /// </summary>
        /// <param name="value">The string representation of the exchange rate to convert.</param>
        /// <param name="result">The result.</param>
        /// <returns></returns>
        public static bool TryParse(string value, out ExchangeRate result)
        {
            result = default;
            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }

            value = value.Trim();
            var array = value.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            if (array.Length != 2)
            {
                return false;
            }

            var currencyValues = array[0].Trim();
            var index = currencyValues.IndexOf("/", StringComparison.InvariantCultureIgnoreCase);
            if (index < 0)
            {
                index = 3;
            }

            if (!CurrencyInfo.TryFromCode(currencyValues.Substring(0, index).Trim(), out var basicCurrency))
            {
                return false;
            }

            if (!CurrencyInfo.TryFromCode(currencyValues.Substring(index).Trim(), out var quoteCurrency))
            {
                return false;
            }

            if (!decimal.TryParse(array[1].Trim(), out var rate))
            {
                return false;
            }

            result = new ExchangeRate(basicCurrency, quoteCurrency, rate);
            return true;
        }

        /// <summary>
        /// Converts the string representation of an exchange rate to its <see cref="ExchangeRate"/> equivalent. A return value indicates whether the conversion succeeded or failed.
        /// </summary>
        /// <param name="value">The string representation of the exchange rate to convert.</param>
        /// <param name="result">The result.</param>
        /// <returns></returns>
        public static bool TryParse(ReadOnlySpan<char> value, out ExchangeRate result)
        {
            result = default;
            if (value.IsEmpty)
            {
                return false;
            }

            value = value.Trim();
            var spaceIndex = value.IndexOf(' ');
            var currencyValues = value.Slice(0, spaceIndex);

            if (currencyValues.Length < 6)
            {
                return false;
            }

            var index = currencyValues.IndexOf('/');
            if (index < 0)
            {
                index = 3;
            }

            if (!CurrencyInfo.TryFromCode(currencyValues.Slice(0, index).Trim(), out var basicCurrency))
            {
                return false;
            }

            if (!CurrencyInfo.TryFromCode(currencyValues.Slice(index).Trim(), out var quoteCurrency))
            {
                return false;
            }
            if (!decimal.TryParse(value.Slice(spaceIndex).Trim(), out var rate))
            {
                return false;
            }

            result = new ExchangeRate(basicCurrency, quoteCurrency, rate);
            return true;
        }

        /// <summary>
        ///  Converts the string representation of an exchange rate to its <see cref="ExchangeRate"/> equivalent.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        /// <exception cref="FormatException"></exception>
        public static ExchangeRate Parse(ReadOnlySpan<char> value)
        {
            if (TryParse(value, out var rate))
            {
                return rate;
            }
            throw new FormatException();
        }

        /// <summary>
        ///  Converts the string representation of an exchange rate to its <see cref="ExchangeRate"/> equivalent.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        /// <exception cref="FormatException"></exception>
        public static ExchangeRate Parse(string value)
        {
            if (TryParse(value, out var rate))
            {
                return rate;
            }
            throw new FormatException();
        }

        public static bool operator ==(ExchangeRate left, ExchangeRate right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ExchangeRate left, ExchangeRate right)
        {
            return !left.Equals(right);
        }
    }
}
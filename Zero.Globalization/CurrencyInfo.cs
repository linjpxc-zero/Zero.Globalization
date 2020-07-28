using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace Zero.Globalization
{
    /// <summary>
    /// Contains information about the currency.
    /// </summary>
    /// <seealso cref="System.IEquatable{Zero.Globalization.CurrencyInfo}" />
    /// <seealso cref="System.IComparable" />
    /// <seealso cref="System.IComparable{Zero.Globalization.CurrencyInfo}" />
    /// <seealso cref="System.ICloneable" />
    [Serializable]
    [SuppressMessage("Design", "CA1036:重写可比较类型中的方法", Justification = "<挂起>")]
    public readonly partial struct CurrencyInfo : IEquatable<CurrencyInfo>, IComparable, IComparable<CurrencyInfo>
    {
        internal CurrencyInfo(string code = default, string numeric = default, int decimalDigits = default, string englishName = default, string symbol = default, bool isFund = false)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                throw new ArgumentException(string.Empty, nameof(code));
            }

            if (string.IsNullOrWhiteSpace(numeric))
            {
                throw new ArgumentException(string.Empty, nameof(numeric));
            }

            if (string.IsNullOrWhiteSpace(symbol))
            {
                throw new ArgumentException(string.Empty, nameof(symbol));
            }

            this.Code = code;
            this.Numeric = numeric;
            this.EnglishName = englishName;
            this.DecimalDigits = decimalDigits < 0 ? 0 : decimalDigits;
            this.Symbol = symbol;
            this.IsFund = isFund;
        }

        /// <summary>
        /// Get a value representing the three-letter currency code.
        /// </summary>
        /// <value>
        /// ISO-4217 currency code.
        /// </value>
        public string Code { get; }

        /// <summary>
        /// Get a value representing the English name of the currency.
        /// </summary>
        /// <value>
        /// The name of the english.
        /// </value>
        public string EnglishName { get; }

        /// <summary>
        /// Get a value representing the number of digits after the decimal separator.
        /// </summary>
        /// <value>
        /// The decimal digits.
        /// </value>
        public int DecimalDigits { get; }

        /// <summary>
        /// Get a value representing the major currency unit.
        /// </summary>
        /// <value>
        /// The major unit.
        /// </value>
        public decimal MajorUnit => decimal.One;

        /// <summary>
        /// Get a value representing the minor currency unit.
        /// </summary>
        /// <value>
        /// The minor unit.
        /// </value>
        public decimal MinorUnit => this.DecimalDigits == 0 ? this.MajorUnit : new decimal(1.0 / Math.Pow(10.0, this.DecimalDigits));

        /// <summary>
        /// Gets the numeric.
        /// </summary>
        /// <value>
        /// ISO-4217 currency numeric.
        /// </value>
        public string Numeric { get; }

        /// <summary>
        /// Gets the symbol.
        /// </summary>
        /// <value>
        /// ISO-4217 currency symbol.
        /// </value>
        public string Symbol { get; }

        public bool IsFund { get; }

        /// <summary>
        /// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has these meanings:
        /// Value
        /// Meaning
        /// Less than zero
        /// This instance precedes <paramref name="obj" /> in the sort order.
        /// Zero
        /// This instance occurs in the same position in the sort order as <paramref name="obj" />.
        /// Greater than zero
        /// This instance follows <paramref name="obj" /> in the sort order.
        /// </returns>
        /// <exception cref="ArgumentException">obj</exception>
        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            if (obj is CurrencyInfo currency)
            {
                return this.CompareTo(currency);
            }
            throw new ArgumentException(string.Empty, nameof(obj));
        }

        /// <summary>
        /// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
        /// </summary>
        /// <param name="other">An object to compare with this instance.</param>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has these meanings:
        /// Value
        /// Meaning
        /// Less than zero
        /// This instance precedes <paramref name="other" /> in the sort order.
        /// Zero
        /// This instance occurs in the same position in the sort order as <paramref name="other" />.
        /// Greater than zero
        /// This instance follows <paramref name="other" /> in the sort order.
        /// </returns>
        public int CompareTo(CurrencyInfo other)
        {
            var i = string.Compare(this.Code, other.Code, StringComparison.OrdinalIgnoreCase);
            if (i > 0)
            {
                return 1;
            }
            if (i < 0)
            {
                return -1;
            }
            return 0;
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
            => obj is CurrencyInfo info && Equals(info);

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        ///   <see langword="true" /> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <see langword="false" />.
        /// </returns>
        public bool Equals(CurrencyInfo other)
            => Code == other.Code;

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode()
            => -434485196 + EqualityComparer<string>.Default.GetHashCode(Code);

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
            => this.Code;

        /// <summary>
        /// Gets the <see cref="CurrencyInfo"/> that represents the currency used by the current thread.
        /// </summary>
        /// <value>
        /// The current currency.
        /// </value>
        public static CurrencyInfo CurrentCurrency => FromRegion(RegionInfo.CurrentRegion);

        /// <summary>
        /// Compares the specified left.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns></returns>
        public static int Compare(CurrencyInfo left, CurrencyInfo right)
            => left.CompareTo(right);

        /// <summary>
        /// Compares the numeric.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns></returns>
        public static int CompareNumeric(CurrencyInfo left, CurrencyInfo right)
        {
            var i = string.Compare(left.Numeric, right.Numeric, StringComparison.OrdinalIgnoreCase);
            if (i > 0)
            {
                return 1;
            }
            if (i < 0)
            {
                return -1;
            }
            return 0;
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator ==(CurrencyInfo left, CurrencyInfo right)
            => left.Equals(right);

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator !=(CurrencyInfo left, CurrencyInfo right)
            => !(left == right);
    }
}
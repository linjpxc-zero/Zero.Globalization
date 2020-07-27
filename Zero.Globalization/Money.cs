using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace Zero.Globalization
{
    /// <summary>
    /// Represents Money, an amount defined in a specific Currency.
    /// </summary>
    /// <seealso cref="System.IEquatable{Zero.Globalization.Money}" />
    /// <seealso cref="System.IComparable" />
    /// <seealso cref="System.IComparable{Zero.Globalization.Money}" />
    /// <seealso cref="System.IFormattable" />
    [Serializable]
    [SuppressMessage("Usage", "CA2225:运算符重载具有命名的备用项", Justification = "<挂起>")]
    public readonly struct Money : IEquatable<Money>, IComparable, IComparable<Money>, IFormattable, IConvertible
    {
        private readonly decimal amount;

        /// <summary>
        /// Initializes a new instance of the <see cref="Money"/> struct.
        /// </summary>
        /// <param name="amount">The amount.</param>
        public Money(decimal amount)
            : this(CurrencyInfo.CurrentCurrency, amount) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Money"/> struct.
        /// </summary>
        /// <param name="currency">The currency.</param>
        /// <param name="amount">The amount.</param>
        public Money(CurrencyInfo currency, decimal amount)
        {
            this.Currency = currency;
            this.amount = amount;
        }

        /// <summary>
        /// Gets the currency.
        /// </summary>
        /// <value>
        /// The currency.
        /// </value>
        public CurrencyInfo Currency { get; }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        ///   <see langword="true" /> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <see langword="false" />.
        /// </returns>
        public bool Equals(Money other)
        {
            return amount == other.amount && Currency.Equals(other.Currency);
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
        public int CompareTo(Money other)
        {
            AssertIsSameCurrency(this.Currency, other.Currency);
            return decimal.Compare(this.amount, other.amount);
        }

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
            if (obj is Money money)
            {
                return this.CompareTo(money);
            }
            throw new ArgumentException(string.Empty, nameof(obj));
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
            return obj is Money other && Equals(other);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return (amount.GetHashCode() * 397) ^ Currency.GetHashCode();
            }
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return this.ConvertToString(null, null);
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public string ToString(string format)
        {
            return this.ToString(format, null);
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return this.ConvertToString(format, formatProvider);
        }

        /// <summary>
        /// Compares the specified left.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns></returns>
        public static int Compare(Money left, Money right) => left.CompareTo(right);

        /// <summary>
        /// Adds the specified left.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns></returns>
        public static Money Add(Money left, Money right)
        {
            AssertIsSameCurrency(left.Currency, right.Currency);
            return new Money(left.Currency, decimal.Add(left.amount, right.amount));
        }

        /// <summary>
        /// Adds the specified money.
        /// </summary>
        /// <param name="money">The money.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static Money Add(Money money, decimal value)
        {
            return new Money(money.Currency, decimal.Add(money.amount, value));
        }

        /// <summary>
        /// Subtracts the specified left.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns></returns>
        public static Money Subtract(Money left, Money right)
        {
            AssertIsSameCurrency(left.Currency, right.Currency);
            return new Money(left.Currency, decimal.Subtract(left.amount, right.amount));
        }

        /// <summary>
        /// Subtracts the specified money.
        /// </summary>
        /// <param name="money">The money.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static Money Subtract(Money money, decimal value)
        {
            return new Money(money.Currency, decimal.Subtract(money.amount, value));
        }

        /// <summary>
        /// Multiplies the specified money.
        /// </summary>
        /// <param name="money">The money.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static Money Multiply(Money money, decimal value)
        {
            return new Money(money.Currency, decimal.Multiply(money.amount, value));
        }

        /// <summary>
        /// Divides the specified money.
        /// </summary>
        /// <param name="money">The money.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static Money Divide(Money money, decimal value)
        {
            return new Money(money.Currency, decimal.Divide(money.amount, value));
        }

        /// <summary>
        /// Negates the specified money.
        /// </summary>
        /// <param name="money">The money.</param>
        /// <returns></returns>
        public static Money Negate(Money money)
        {
            return new Money(money.Currency, decimal.Negate(money.amount));
        }

        /// <summary>
        /// Gets the bits.
        /// </summary>
        /// <param name="money">The money.</param>
        /// <returns></returns>
        public static int[] GetBits(Money money)
        {
            return decimal.GetBits(money.amount);
        }

        /// <summary>
        /// Converts to byte.
        /// </summary>
        /// <param name="money">The money.</param>
        /// <returns></returns>
        public static byte ToByte(Money money)
        {
            return decimal.ToByte(money.amount);
        }

        /// <summary>
        /// Converts to sbyte.
        /// </summary>
        /// <param name="money">The money.</param>
        /// <returns></returns>
        [CLSCompliant(false)]
        public static sbyte ToSByte(Money money)
        {
            return decimal.ToSByte(money.amount);
        }

        /// <summary>
        /// Converts to int16.
        /// </summary>
        /// <param name="money">The money.</param>
        /// <returns></returns>
        public static short ToInt16(Money money)
        {
            return decimal.ToInt16(money.amount);
        }

        /// <summary>
        /// Converts to uint16.
        /// </summary>
        /// <param name="money">The money.</param>
        /// <returns></returns>
        [CLSCompliant(false)]
        public static ushort ToUInt16(Money money)
        {
            return decimal.ToUInt16(money.amount);
        }

        /// <summary>
        /// Converts to int32.
        /// </summary>
        /// <param name="money">The money.</param>
        /// <returns></returns>
        public static int ToInt32(Money money)
        {
            return decimal.ToInt32(money.amount);
        }

        /// <summary>
        /// Converts to uint32.
        /// </summary>
        /// <param name="money">The money.</param>
        /// <returns></returns>
        [CLSCompliant(false)]
        public static uint ToUInt32(Money money)
        {
            return decimal.ToUInt32(money.amount);
        }

        /// <summary>
        /// Converts to int64.
        /// </summary>
        /// <param name="money">The money.</param>
        /// <returns></returns>
        public static long ToInt64(Money money)
        {
            return decimal.ToInt64(money.amount);
        }

        /// <summary>
        /// Converts to uint64.
        /// </summary>
        /// <param name="money">The money.</param>
        /// <returns></returns>
        [CLSCompliant(false)]
        public static ulong ToUInt64(Money money)
        {
            return decimal.ToUInt64(money.amount);
        }

        /// <summary>
        /// Converts to single.
        /// </summary>
        /// <param name="money">The money.</param>
        /// <returns></returns>
        public static float ToSingle(Money money)
        {
            return decimal.ToSingle(money.amount);
        }

        /// <summary>
        /// Converts to double.
        /// </summary>
        /// <param name="money">The money.</param>
        /// <returns></returns>
        public static double ToDouble(Money money)
        {
            return decimal.ToDouble(money.amount);
        }

        /// <summary>
        /// Parses the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static Money Parse(string value)
            => Parse(value.AsSpan());

        /// <summary>
        /// Parses the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        /// <exception cref="FormatException"></exception>
        public static Money Parse(ReadOnlySpan<char> value)
        {
            if (TryParse(value, out var money))
            {
                return money;
            }
            throw new FormatException();
        }

        /// <summary>
        /// Tries the parse.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="result">The result.</param>
        /// <returns></returns>
        public static bool TryParse(string value, out Money result)
            => TryParse(value.AsSpan(), out result);

        /// <summary>
        /// Tries the parse.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="result">The result.</param>
        /// <returns></returns>
        public static bool TryParse(ReadOnlySpan<char> value, out Money result)
        {
            result = default;
            value = value.Trim();
            if (value.IsEmpty)
            {
                return false;
            }

            if (char.IsNumber(value[0]))
            {
                if (decimal.TryParse(value, out var tmp))
                {
                    result = new Money(tmp);
                    return true;
                }
                return false;
            }

            if (value.Length < 3)
            {
                return false;
            }
            if (CurrencyInfo.TryFromCode(value.Slice(0, 3), out var currency))
            {
                if (value.Length == 3)
                {
                    result = new Money(currency, decimal.Zero);
                }
                else
                {
                    if (decimal.TryParse(value.Slice(3).Trim(), out var tmp))
                    {
                        result = new Money(currency, tmp);
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Money operator +(Money left, Money right)
            => Add(left, right);

        public static Money operator +(Money money, decimal value)
            => Add(money, value);

        public static Money operator +(decimal value, Money money)
            => Add(money, value);

        public static Money operator -(Money left, Money right)
            => Subtract(left, right);

        public static Money operator -(Money left, decimal value)
            => Subtract(left, value);

        public static Money operator -(decimal value, Money money)
            => new Money(money.Currency, decimal.Subtract(value, money.amount));

        public static Money operator *(Money money, decimal value)
            => Multiply(money, value);

        public static Money operator *(decimal value, Money money)
            => Multiply(money, value);

        public static Money operator /(Money money, decimal value)
            => Divide(money, value);

        public static Money operator /(decimal value, Money money)
            => new Money(money.Currency, decimal.Divide(value, money.amount));

        public static bool operator >(Money left, Money right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator <(Money left, Money right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator >=(Money left, Money right)
        {
            return left.CompareTo(right) >= 0;
        }

        public static bool operator <=(Money left, Money right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator ==(Money left, Money right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Money left, Money right)
        {
            return !left.Equals(right);
        }

        public static explicit operator double(Money money)
        {
            return (double)money.amount;
        }

        public static explicit operator long(Money money)
        {
            return (long)money.amount;
        }

        public static explicit operator decimal(Money money)
        {
            return money.amount;
        }

        public static explicit operator float(Money money)
        {
            return (float)money.amount;
        }

        public static implicit operator Money(long value)
        {
            return new Money(value);
        }

        [CLSCompliant(false)]
        public static implicit operator Money(ulong value)
        {
            return new Money(value);
        }

        public static implicit operator Money(byte value) => new Money(value);

        [CLSCompliant(false)]
        public static implicit operator Money(ushort value) => new Money(value);

        [CLSCompliant(false)]
        public static implicit operator Money(uint value) => new Money(value);

        public static explicit operator Money(double value) => new Money((decimal)value);

        public static explicit operator Money(float value) => new Money((decimal)value);

        private static void AssertIsSameCurrency(CurrencyInfo left, CurrencyInfo right)
        {
            if (left != right)
            {
                throw new InvalidCurrencyOperationException();
            }
        }

        private string ConvertToString(string format, IFormatProvider provider)
        {
            if (!string.IsNullOrWhiteSpace(format) && format.StartsWith("I", StringComparison.InvariantCulture) && (format.Length >= 1 && format.Length <= 2))
            {
                format = format.Replace("I", "C", StringComparison.InvariantCulture);

                provider = GetFormatProvider(this.Currency, provider, true);
            }
            else
            {
                provider = GetFormatProvider(this.Currency, provider, false);
            }

            return this.amount.ToString(format ?? "C", provider);
        }

        private static IFormatProvider GetFormatProvider(CurrencyInfo currency, IFormatProvider provider,
            bool useCode = false)
        {
            NumberFormatInfo numberFormatInfo = null;
            if (provider != null)
            {
                if (provider is CultureInfo culture)
                {
                    numberFormatInfo = culture.NumberFormat.Clone() as NumberFormatInfo;
                }

                if (provider is NumberFormatInfo format)
                {
                    numberFormatInfo = format.Clone() as NumberFormatInfo;
                }
            }
            else
            {
                numberFormatInfo = CultureInfo.CurrentCulture.NumberFormat.Clone() as NumberFormatInfo;
            }

            if (numberFormatInfo == null)
            {
                return null;
            }

            numberFormatInfo.CurrencyDecimalDigits = (int)currency.DecimalDigits;
            numberFormatInfo.CurrencySymbol = currency.Symbol;

            if (useCode)
            {
                numberFormatInfo.CurrencySymbol = currency.Code;
                if (numberFormatInfo.CurrencyPositivePattern == 0)
                {
                    numberFormatInfo.CurrencyPositivePattern = 2;
                }

                if (numberFormatInfo.CurrencyPositivePattern == 1)
                {
                    numberFormatInfo.CurrencyPositivePattern = 3;
                }

                switch (numberFormatInfo.CurrencyNegativePattern)
                {
                    case 0: numberFormatInfo.CurrencyNegativePattern = 14; break;
                    case 1: numberFormatInfo.CurrencyNegativePattern = 9; break;
                    case 2: numberFormatInfo.CurrencyNegativePattern = 12; break;
                    case 3: numberFormatInfo.CurrencyNegativePattern = 11; break;
                    case 4: numberFormatInfo.CurrencyNegativePattern = 15; break;
                    case 5: numberFormatInfo.CurrencyNegativePattern = 8; break;
                    case 6: numberFormatInfo.CurrencyNegativePattern = 13; break;
                    case 7: numberFormatInfo.CurrencyNegativePattern = 10; break;
                }
            }

            return numberFormatInfo;
        }

        #region IConvertible

        /// <summary>
        /// Returns the <see cref="System.TypeCode" /> for this instance.
        /// </summary>
        /// <returns>
        /// The enumerated constant that is the <see cref="System.TypeCode" /> of the class or value type that implements this interface.
        /// </returns>
        TypeCode IConvertible.GetTypeCode()
            => TypeCode.Object;

        /// <summary>
        /// Converts to boolean.
        /// </summary>
        /// <param name="provider">An <see cref="System.IFormatProvider" /> interface implementation that supplies culture-specific formatting information.</param>
        /// <returns>
        /// A Boolean value equivalent to the value of this instance.
        /// </returns>
        bool IConvertible.ToBoolean(IFormatProvider provider)
            => Convert.ToBoolean(this.amount, provider);

        /// <summary>
        /// Converts to byte.
        /// </summary>
        /// <param name="provider">An <see cref="System.IFormatProvider" /> interface implementation that supplies culture-specific formatting information.</param>
        /// <returns>
        /// An 8-bit unsigned integer equivalent to the value of this instance.
        /// </returns>
        byte IConvertible.ToByte(IFormatProvider provider)
            => Convert.ToByte(this.amount, provider);

        /// <summary>
        /// Converts to char.
        /// </summary>
        /// <param name="provider">An <see cref="System.IFormatProvider" /> interface implementation that supplies culture-specific formatting information.</param>
        /// <returns>
        /// A Unicode character equivalent to the value of this instance.
        /// </returns>
        char IConvertible.ToChar(IFormatProvider provider)
            => Convert.ToChar(this.amount, provider);

        /// <summary>
        /// Converts to datetime.
        /// </summary>
        /// <param name="provider">An <see cref="System.IFormatProvider" /> interface implementation that supplies culture-specific formatting information.</param>
        /// <returns>
        /// A <see cref="System.DateTime" /> instance equivalent to the value of this instance.
        /// </returns>
        DateTime IConvertible.ToDateTime(IFormatProvider provider)
            => Convert.ToDateTime(this.amount, provider);

        /// <summary>
        /// Converts to decimal.
        /// </summary>
        /// <param name="provider">An <see cref="System.IFormatProvider" /> interface implementation that supplies culture-specific formatting information.</param>
        /// <returns>
        /// A <see cref="System.Decimal" /> number equivalent to the value of this instance.
        /// </returns>
        decimal IConvertible.ToDecimal(IFormatProvider provider)
            => Convert.ToDecimal(this.amount, provider);

        /// <summary>
        /// Converts to double.
        /// </summary>
        /// <param name="provider">An <see cref="System.IFormatProvider" /> interface implementation that supplies culture-specific formatting information.</param>
        /// <returns>
        /// A double-precision floating-point number equivalent to the value of this instance.
        /// </returns>
        double IConvertible.ToDouble(IFormatProvider provider)
            => Convert.ToDouble(this.amount, provider);

        /// <summary>
        /// Converts to int16.
        /// </summary>
        /// <param name="provider">An <see cref="System.IFormatProvider" /> interface implementation that supplies culture-specific formatting information.</param>
        /// <returns>
        /// An 16-bit signed integer equivalent to the value of this instance.
        /// </returns>
        short IConvertible.ToInt16(IFormatProvider provider)
            => Convert.ToInt16(this.amount, provider);

        /// <summary>
        /// Converts to int32.
        /// </summary>
        /// <param name="provider">An <see cref="System.IFormatProvider" /> interface implementation that supplies culture-specific formatting information.</param>
        /// <returns>
        /// An 32-bit signed integer equivalent to the value of this instance.
        /// </returns>
        int IConvertible.ToInt32(IFormatProvider provider)
            => Convert.ToInt32(this.amount, provider);

        /// <summary>
        /// Converts to int64.
        /// </summary>
        /// <param name="provider">An <see cref="System.IFormatProvider" /> interface implementation that supplies culture-specific formatting information.</param>
        /// <returns>
        /// An 64-bit signed integer equivalent to the value of this instance.
        /// </returns>
        long IConvertible.ToInt64(IFormatProvider provider)
            => Convert.ToInt64(this.amount, provider);

        /// <summary>
        /// Converts to sbyte.
        /// </summary>
        /// <param name="provider">An <see cref="System.IFormatProvider" /> interface implementation that supplies culture-specific formatting information.</param>
        /// <returns>
        /// An 8-bit signed integer equivalent to the value of this instance.
        /// </returns>
        sbyte IConvertible.ToSByte(IFormatProvider provider)
            => Convert.ToSByte(this.amount, provider);

        /// <summary>
        /// Converts to single.
        /// </summary>
        /// <param name="provider">An <see cref="System.IFormatProvider" /> interface implementation that supplies culture-specific formatting information.</param>
        /// <returns>
        /// A single-precision floating-point number equivalent to the value of this instance.
        /// </returns>
        float IConvertible.ToSingle(IFormatProvider provider)
            => Convert.ToSingle(this.amount, provider);

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        string IConvertible.ToString(IFormatProvider provider)
            => ConvertToString(null, provider);

        /// <summary>
        /// Converts to type.
        /// </summary>
        /// <param name="conversionType">The <see cref="System.Type" /> to which the value of this instance is converted.</param>
        /// <param name="provider">An <see cref="System.IFormatProvider" /> interface implementation that supplies culture-specific formatting information.</param>
        /// <returns>
        /// An <see cref="System.Object" /> instance of type <paramref name="conversionType" /> whose value is equivalent to the value of this instance.
        /// </returns>
        object IConvertible.ToType(Type conversionType, IFormatProvider provider)
            => Convert.ChangeType(this.amount, conversionType, provider);

        /// <summary>
        /// Converts to uint16.
        /// </summary>
        /// <param name="provider">An <see cref="System.IFormatProvider" /> interface implementation that supplies culture-specific formatting information.</param>
        /// <returns>
        /// An 16-bit unsigned integer equivalent to the value of this instance.
        /// </returns>
        ushort IConvertible.ToUInt16(IFormatProvider provider)
            => Convert.ToUInt16(this.amount, provider);

        /// <summary>
        /// Converts to uint32.
        /// </summary>
        /// <param name="provider">An <see cref="System.IFormatProvider" /> interface implementation that supplies culture-specific formatting information.</param>
        /// <returns>
        /// An 32-bit unsigned integer equivalent to the value of this instance.
        /// </returns>
        uint IConvertible.ToUInt32(IFormatProvider provider)
            => Convert.ToUInt32(this.amount, provider);

        /// <summary>
        /// Converts to uint64.
        /// </summary>
        /// <param name="provider">An <see cref="System.IFormatProvider" /> interface implementation that supplies culture-specific formatting information.</param>
        /// <returns>
        /// An 64-bit unsigned integer equivalent to the value of this instance.
        /// </returns>
        ulong IConvertible.ToUInt64(IFormatProvider provider)
            => Convert.ToUInt64(this.amount, provider);

        #endregion IConvertible
    }
}
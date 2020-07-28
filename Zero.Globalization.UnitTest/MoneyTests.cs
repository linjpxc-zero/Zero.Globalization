using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace Zero.Globalization.UnitTest
{
    [TestFixture]
    internal class MoneyTests
    {
        [Test]
        [MoneyTestCaseSource(nameof(MoneyTestsSources.Add_Source))]
        public Money? Add_Test(Money objA, Money objB, Type exceptionType)
        {
            if (exceptionType == null)
            {
                return Money.Add(objA, objB);
            }
            Assert.Throws(exceptionType, () => Money.Add(objA, objB));
            return null;
        }

        [Test]
        [MoneyTestCaseSource(nameof(MoneyTestsSources.Add_Decimal_Source))]
        public Money Add_Test(Money money, decimal value)
            => Money.Add(money, value);

        [Test]
        [MoneyTestCaseSource(nameof(MoneyTestsSources.Subtract_Source))]
        public Money? Subtract_Test(Money left, Money right, Type exceptionType)
        {
            if (exceptionType == null)
            {
                return Money.Subtract(left, right);
            }
            Assert.Throws(exceptionType, () => Money.Subtract(left, right));
            return null;
        }

        [Test]
        [MoneyTestCaseSource(nameof(MoneyTestsSources.Subtract_Decimal_Source))]
        public Money Subtract_Test(Money money, decimal value)
            => Money.Subtract(money, value);

        [Test]
        [MoneyTestCaseSource(nameof(MoneyTestsSources.Multiply_Decimal_Source))]
        public Money Multiply_Test(Money money, decimal value)
            => Money.Multiply(money, value);

        [Test]
        [MoneyTestCaseSource(nameof(MoneyTestsSources.Divide_Decimal_Source))]
        public Money Divide_Test(Money money, decimal value)
            => Money.Divide(money, value);

        [Test]
        [MoneyTestCaseSource(nameof(MoneyTestsSources.Negate_Source))]
        public Money Negate_Test(Money money)
            => Money.Negate(money);

        [Test]
        [MoneyTestCaseSource(nameof(MoneyTestsSources.GetBits_Source))]
        public int[] GetBits_Test(Money money)
            => Money.GetBits(money);

        [Test]
        [MoneyTestCaseSource(nameof(MoneyTestsSources.ToByte_Source))]
        public byte? ToByte_Test(Money money, Type exceptionType)
        {
            if (exceptionType == null)
            {
                return Money.ToByte(money);
            }
            Assert.Throws(exceptionType, () => Money.ToByte(money));
            return null;
        }

        [Test]
        [MoneyTestCaseSource(nameof(MoneyTestsSources.ToSByte_Source))]
        public sbyte? ToSByte_Test(Money money, Type exceptionType)
        {
            if (exceptionType == null)
            {
                return Money.ToSByte(money);
            }
            Assert.Throws(exceptionType, () => Money.ToSByte(money));
            return null;
        }

        [Test]
        [MoneyTestCaseSource(nameof(MoneyTestsSources.ToInt16_Source))]
        public short? ToInt16_Test(Money money, Type exceptionType)
        {
            if (exceptionType == null)
            {
                return Money.ToInt16(money);
            }
            Assert.Throws(exceptionType, () => Money.ToInt16(money));
            return null;
        }

        [Test]
        [MoneyTestCaseSource(nameof(MoneyTestsSources.ToUInt16_Source))]
        public ushort? ToUInt16_Test(Money money, Type exceptionType)
        {
            if (exceptionType == null)
            {
                return Money.ToUInt16(money);
            }
            Assert.Throws(exceptionType, () => Money.ToUInt16(money));
            return null;
        }

        [Test]
        [MoneyTestCaseSource(nameof(MoneyTestsSources.ToInt32_Source))]
        public int? ToInt32_Test(Money money, Type exceptionType)
        {
            if (exceptionType == null)
            {
                return Money.ToInt32(money);
            }
            Assert.Throws(exceptionType, () => Money.ToInt32(money));
            return null;
        }

        [Test]
        [MoneyTestCaseSource(nameof(MoneyTestsSources.ToUInt32_Source))]
        public uint? ToUInt32_Test(Money money, Type exceptionType)
        {
            if (exceptionType == null)
            {
                return Money.ToUInt32(money);
            }
            Assert.Throws(exceptionType, () => Money.ToUInt32(money));
            return null;
        }

        [Test]
        [MoneyTestCaseSource(nameof(MoneyTestsSources.ToInt64_Source))]
        public long? ToInt64_Test(Money money, Type exceptionType)
        {
            if (exceptionType == null)
            {
                return Money.ToInt64(money);
            }
            Assert.Throws(exceptionType, () => Money.ToInt64(money));
            return null;
        }

        [Test]
        [MoneyTestCaseSource(nameof(MoneyTestsSources.ToUInt64_Source))]
        public ulong? ToUInt64_Test(Money money, Type exceptionType)
        {
            if (exceptionType == null)
            {
                return Money.ToUInt64(money);
            }
            Assert.Throws(exceptionType, () => Money.ToUInt64(money));
            return null;
        }

        [Test]
        [MoneyTestCaseSource(nameof(MoneyTestsSources.ToSingle_Source))]
        public float ToSingle_Test(Money money)
            => Money.ToSingle(money);

        [Test]
        [MoneyTestCaseSource(nameof(MoneyTestsSources.ToDouble_Source))]
        public double ToDouble_Test(Money money)
         => Money.ToDouble(money);

        [Test]
        [MoneyTestCaseSource(nameof(MoneyTestsSources.Parse_Source))]
        public Money? Parse_Test(string value, Type exceptionType)
        {
            if (exceptionType == null)
            {
                return Money.Parse(value);
            }
            Assert.Throws(exceptionType, () => Money.Parse(value));
            return null;
        }

        [Test]
        [MoneyTestCaseSource(nameof(MoneyTestsSources.Add_Source))]
        [SuppressMessage("Style", "IDE1006:命名样式", Justification = "<挂起>")]
        public Money? op_Addition_Test(Money left, Money right, Type exceptionType)
        {
            if (exceptionType == null)
            {
                return left + right;
            }
            Assert.Throws(exceptionType, () =>
            {
                _ = left + right;
            });
            return null;
        }

        [Test]
        [MoneyTestCaseSource(nameof(MoneyTestsSources.Add_Decimal_Source))]
        [SuppressMessage("Style", "IDE1006:命名样式", Justification = "<挂起>")]
        public Money op_Addition_Test(Money left, decimal value)
        {
            var result = left + value;
            Assert.AreEqual(result, value + left);
            return result;
        }

        [Test]
        [MoneyTestCaseSource(nameof(MoneyTestsSources.Divide_Decimal_Source))]
        [SuppressMessage("Style", "IDE1006:命名样式", Justification = "<挂起>")]
        public Money op_Division_Test(Money money, decimal value)
            => money / value;

        [Test]
        [MoneyTestCaseSource(nameof(MoneyTestsSources.Divide_Decimal_Source2))]
        [SuppressMessage("Style", "IDE1006:命名样式", Justification = "<挂起>")]
        public Money op_Division_Test(decimal value, Money money)
            => value / money;

        [Test]
        [MoneyTestCaseSource(nameof(MoneyTestsSources.op_Equality_Source))]
        [SuppressMessage("Style", "IDE1006:命名样式", Justification = "<挂起>")]
        public bool op_Equality_Tests(Money left, Money right)
            => left == right;

        [Test]
        [MoneyTestCaseSource(nameof(MoneyTestsSources.op_Explicit_Money_Decimal_Source))]
        [SuppressMessage("Style", "IDE1006:命名样式", Justification = "<挂起>")]
        public decimal op_Explicit_Money_Decimal_Test(Money money)
            => (decimal)money;

        [Test]
        [MoneyTestCaseSource(nameof(MoneyTestsSources.op_Explicit_Money_Int64_Source))]
        [SuppressMessage("Style", "IDE1006:命名样式", Justification = "<挂起>")]
        public long op_Explicit_Money_Int64_Test(Money money)
            => (long)money;

        [Test]
        [MoneyTestCaseSource(nameof(MoneyTestsSources.op_Explicit_Money_Single_Source))]
        [SuppressMessage("Style", "IDE1006:命名样式", Justification = "<挂起>")]
        public float op_Explicit_Money_Single_Test(Money money)
            => (float)money;

        [Test]
        [MoneyTestCaseSource(nameof(MoneyTestsSources.op_Explicit_Money_Double_Source))]
        [SuppressMessage("Style", "IDE1006:命名样式", Justification = "<挂起>")]
        public double op_Explicit_Money_Double_Test(Money money)
            => (double)money;

        [Test]
        [MoneyTestCaseSource(nameof(MoneyTestsSources.op_Explicit_Double_Money_Source))]
        [SuppressMessage("Style", "IDE1006:命名样式", Justification = "<挂起>")]
        public Money op_Explicit_Double_Money_Test(double value)
            => (Money)value;

        [Test]
        [MoneyTestCaseSource(nameof(MoneyTestsSources.op_Explicit_Single_Money_Source))]
        [SuppressMessage("Style", "IDE1006:命名样式", Justification = "<挂起>")]
        public Money op_Explicit_Single_Money_Test(float value)
            => (Money)value;

        [Test]
        [MoneyTestCaseSource(nameof(MoneyTestsSources.op_GreaterThan_Source))]
        [SuppressMessage("Style", "IDE1006:命名样式", Justification = "<挂起>")]
        public bool op_GreaterThan_Test(Money left, Money right)
            => left > right;

        [Test]
        [MoneyTestCaseSource(nameof(MoneyTestsSources.op_GreaterThanOrEqual_Source))]
        [SuppressMessage("Style", "IDE1006:命名样式", Justification = "<挂起>")]
        public bool op_GreaterThanOrEqual_Test(Money left, Money right)
            => left >= right;

        [Test]
        [MoneyTestCaseSource(nameof(MoneyTestsSources.op_Implicit_Byte_Money_Source))]
        [SuppressMessage("Style", "IDE1006:命名样式", Justification = "<挂起>")]
        public Money op_Implicit_Byte_Money_Test(byte value)
            => value;

        [Test]
        [MoneyTestCaseSource(nameof(MoneyTestsSources.op_Implicit_Int64_Money_Source))]
        [SuppressMessage("Style", "IDE1006:命名样式", Justification = "<挂起>")]
        public Money op_Implicit_Int64_Money_Test(long value)
            => value;

        [Test]
        [MoneyTestCaseSource(nameof(MoneyTestsSources.op_Implicit_UInt32_Money_Source))]
        [SuppressMessage("Style", "IDE1006:命名样式", Justification = "<挂起>")]
        public Money op_Implicit_UInt32_Money_Test(uint value)
            => value;

        [Test]
        [MoneyTestCaseSource(nameof(MoneyTestsSources.op_Implicit_UInt64_Money_Source))]
        [SuppressMessage("Style", "IDE1006:命名样式", Justification = "<挂起>")]
        public Money op_Implicit_UInt64_Money_Test(ulong value)
            => value;

        [Test]
        [MoneyTestCaseSource(nameof(MoneyTestsSources.op_Implicit_UInt16_Money_Source))]
        [SuppressMessage("Style", "IDE1006:命名样式", Justification = "<挂起>")]
        public Money op_Implicit_UInt16_Money_Test(ushort value)
            => value;

        [Test]
        [MoneyTestCaseSource(nameof(MoneyTestsSources.op_Inequality_Source))]
        [SuppressMessage("Style", "IDE1006:命名样式", Justification = "<挂起>")]
        public bool op_Inequality_Test(Money left, Money right)
            => left != right;

        [Test]
        [MoneyTestCaseSource(nameof(MoneyTestsSources.op_LessThan_Source))]
        [SuppressMessage("Style", "IDE1006:命名样式", Justification = "<挂起>")]
        public bool op_LessThan_Test(Money left, Money right)
            => left < right;

        [Test]
        [MoneyTestCaseSource(nameof(MoneyTestsSources.op_LessThanOrEqual_Source))]
        [SuppressMessage("Style", "IDE1006:命名样式", Justification = "<挂起>")]
        public bool op_LessThanOrEqual_Test(Money left, Money right)
          => left <= right;

        [Test]
        [MoneyTestCaseSource(nameof(MoneyTestsSources.Multiply_Decimal_Source))]
        [SuppressMessage("Style", "IDE1006:命名样式", Justification = "<挂起>")]
        public Money op_Multiply_Test(Money money, decimal value)
        {
            var result = money * value;
            Assert.AreEqual(result, value * money);
            return result;
        }

        [Test]
        [MoneyTestCaseSource(nameof(MoneyTestsSources.Subtract_Source))]
        [SuppressMessage("Style", "IDE1006:命名样式", Justification = "<挂起>")]
        public Money? op_Substration_Test(Money left, Money right, Type exceptionType)
        {
            if (exceptionType == null)
            {
                return left - right;
            }
            Assert.Throws(exceptionType, () =>
            {
                _ = left - right;
            });
            return null;
        }

        [Test]
        [MoneyTestCaseSource(nameof(MoneyTestsSources.Subtract_Decimal_Source))]
        [SuppressMessage("Style", "IDE1006:命名样式", Justification = "<挂起>")]
        public Money op_Substration_Test(Money money, decimal value)
        {
            var result = money - value;
            Assert.AreEqual(result, Money.Negate(value - money));
            return result;
        }

        [Test]
        [MoneyTestCaseSource(nameof(MoneyTestsSources.Compare_Source))]
        public int? Compare_Test(Money left, Money right, Type exceptionType)
        {
            if (exceptionType == null)
            {
                return Money.Compare(left, right);
            }
            Assert.Throws(exceptionType, () => Money.Compare(left, right));
            return null;
        }

        [Test]
        [MoneyTestCaseSource(nameof(MoneyTestsSources.CompareTo_Source))]
        public int? CompareTo_Test(Money money, object obj, Type exceptionType)
        {
            if (exceptionType == null)
            {
                return money.CompareTo(obj);
            }
            Assert.Throws(exceptionType, () => money.CompareTo(obj));
            return null;
        }

        [Test]
        [MoneyTestCaseSource(nameof(MoneyTestsSources.GetHashCode_Source))]
        public bool GetHashCode_Test(Money objA, Money objB)
        {
            return objA.GetHashCode() == objB.GetHashCode();
        }

        [Test]
        [MoneyTestCaseSource(nameof(MoneyTestsSources.ToString_Source))]
        public string ToString_Test(Money money)
            => money.ToString();

        [Test]
        [MoneyTestCaseSource(nameof(MoneyTestsSources.ToString_Format_Source))]
        public string ToString_Test(Money money, string format)
            => money.ToString(format);

        [Test]
        [MoneyTestCaseSource(nameof(MoneyTestsSources.ToString_Format_Provider_Source))]
        public string ToString_Test(Money money, string format, IFormatProvider provider)
            => money.ToString(format, provider);

        [Test]
        [MoneyTestCaseSource(nameof(MoneyTestsSources.Equals_Source))]
        public bool Equals_Test(Money money, object obj)
            => money.Equals(obj);

        [Test]
        public void IConvertible_Test()
        {
            _ = Money.TryParse("CNY1", out var result);
            var money = result as IConvertible;
            Assert.AreEqual(money.GetTypeCode(), TypeCode.Object);
            Assert.AreEqual(money.ToBoolean(CultureInfo.InvariantCulture), true);
            Assert.AreEqual(money.ToByte(CultureInfo.InvariantCulture), (byte)1);
            Assert.AreEqual(money.ToDecimal(CultureInfo.InvariantCulture), 1M);
            Assert.AreEqual(money.ToDouble(CultureInfo.InvariantCulture), 1D);
            Assert.AreEqual(money.ToInt16(CultureInfo.InvariantCulture), (short)1);
            Assert.AreEqual(money.ToInt32(CultureInfo.InvariantCulture), 1);
            Assert.AreEqual(money.ToInt64(CultureInfo.InvariantCulture), 1L);
            Assert.AreEqual(money.ToSByte(CultureInfo.InvariantCulture), (sbyte)1);
            Assert.AreEqual(money.ToSingle(CultureInfo.InvariantCulture), 1F);
            Assert.AreEqual(money.ToType(typeof(decimal), CultureInfo.InvariantCulture), 1M);
            Assert.AreEqual(money.ToUInt16(CultureInfo.InvariantCulture), (ushort)1);
            Assert.AreEqual(money.ToUInt32(CultureInfo.InvariantCulture), 1U);
            Assert.AreEqual(money.ToUInt64(CultureInfo.InvariantCulture), 1UL);
            Assert.Throws<InvalidCastException>(() => money.ToChar(CultureInfo.InvariantCulture));
            Assert.Throws<InvalidCastException>(() => money.ToDateTime(CultureInfo.InvariantCulture));
        }

        private static class MoneyTestsSources
        {
            public static IEnumerable<TestCaseData> Add_Source()
            {
                yield return new TestCaseData(new Money(CurrencyInfo.FromCode("CNY"), 1), new Money(CurrencyInfo.FromCode("CNY"), 1), null).Returns(new Money(CurrencyInfo.FromCode("CNY"), 2));
                yield return new TestCaseData(new Money(CurrencyInfo.FromCode("CNY"), 1), new Money(CurrencyInfo.FromCode("CLP"), 1), typeof(InvalidCurrencyOperationException)).Returns(null);
            }

            public static IEnumerable<TestCaseData> Add_Decimal_Source()
            {
                yield return new TestCaseData(new Money(CurrencyInfo.FromCode("CNY"), 1), 1M).Returns(new Money(CurrencyInfo.FromCode("CNY"), 2));
            }

            public static IEnumerable<TestCaseData> Subtract_Source()
            {
                yield return new TestCaseData(new Money(CurrencyInfo.FromCode("CNY"), 2), new Money(CurrencyInfo.FromCode("CNY"), 1), null).Returns(new Money(CurrencyInfo.FromCode("CNY"), 1));
                yield return new TestCaseData(new Money(CurrencyInfo.FromCode("CNY"), 1), new Money(CurrencyInfo.FromCode("CLP"), 1), typeof(InvalidCurrencyOperationException)).Returns(null);
            }

            public static IEnumerable<TestCaseData> Subtract_Decimal_Source()
            {
                yield return new TestCaseData(new Money(CurrencyInfo.FromCode("CNY"), 2), 1M).Returns(new Money(CurrencyInfo.FromCode("CNY"), 1));
            }

            public static IEnumerable<TestCaseData> Multiply_Decimal_Source()
            {
                yield return new TestCaseData(new Money(CurrencyInfo.FromCode("CNY"), 1), 2M).Returns(new Money(CurrencyInfo.FromCode("CNY"), 2));
            }

            public static IEnumerable<TestCaseData> Divide_Decimal_Source()
            {
                yield return new TestCaseData(new Money(CurrencyInfo.FromCode("CNY"), 1), 3M).Returns(new Money(CurrencyInfo.FromCode("CNY"), 0.33M));
                yield return new TestCaseData(new Money(CurrencyInfo.FromCode("CNY"), 2), 3M).Returns(new Money(CurrencyInfo.FromCode("CNY"), 0.67M));
                yield return new TestCaseData(new Money(CurrencyInfo.FromCode("CNY"), 1), 8M).Returns(new Money(CurrencyInfo.FromCode("CNY"), 0.13M));
            }

            public static IEnumerable<TestCaseData> Negate_Source()
            {
                yield return new TestCaseData(new Money(CurrencyInfo.FromCode("CNY"), 1M)).Returns(new Money(CurrencyInfo.FromCode("CNY"), -1M));
            }

            public static IEnumerable<TestCaseData> GetBits_Source()
            {
                yield return new TestCaseData(new Money(CurrencyInfo.FromCode("CNY"), 1M)).Returns(new int[] { 1, 0, 0, 0 });
            }

            public static IEnumerable<TestCaseData> ToByte_Source()
            {
                yield return new TestCaseData(new Money(CurrencyInfo.FromCode("CNY"), 1000M), typeof(OverflowException)).Returns(null);
                yield return new TestCaseData(new Money(CurrencyInfo.FromCode("CNY"), byte.MaxValue + 1M), typeof(OverflowException)).Returns(null);
                yield return new TestCaseData(new Money(CurrencyInfo.FromCode("CNY"), byte.MaxValue), null).Returns(byte.MaxValue);
            }

            public static IEnumerable<TestCaseData> ToSByte_Source()
            {
                yield return new TestCaseData(new Money(CurrencyInfo.FromCode("CNY"), sbyte.MaxValue + 1M), typeof(OverflowException)).Returns(null);
                yield return new TestCaseData(new Money(CurrencyInfo.FromCode("CNY"), sbyte.MinValue - 1M), typeof(OverflowException)).Returns(null);
                yield return new TestCaseData(new Money(CurrencyInfo.FromCode("CNY"), sbyte.MaxValue), null).Returns(sbyte.MaxValue);
                yield return new TestCaseData(new Money(CurrencyInfo.FromCode("CNY"), sbyte.MinValue), null).Returns(sbyte.MinValue);
            }

            public static IEnumerable<TestCaseData> ToInt16_Source()
            {
                yield return new TestCaseData(new Money(CurrencyInfo.FromCode("CNY"), short.MaxValue + 1M), typeof(OverflowException)).Returns(null);
                yield return new TestCaseData(new Money(CurrencyInfo.FromCode("CNY"), short.MinValue - 1M), typeof(OverflowException)).Returns(null);
                yield return new TestCaseData(new Money(CurrencyInfo.FromCode("CNY"), short.MaxValue), null).Returns(short.MaxValue);
                yield return new TestCaseData(new Money(CurrencyInfo.FromCode("CNY"), short.MinValue), null).Returns(short.MinValue);
            }

            public static IEnumerable<TestCaseData> ToUInt16_Source()
            {
                yield return new TestCaseData(new Money(CurrencyInfo.FromCode("CNY"), ushort.MaxValue + 1M), typeof(OverflowException)).Returns(null);
                yield return new TestCaseData(new Money(CurrencyInfo.FromCode("CNY"), ushort.MinValue - 1M), typeof(OverflowException)).Returns(null);
                yield return new TestCaseData(new Money(CurrencyInfo.FromCode("CNY"), ushort.MaxValue), null).Returns(ushort.MaxValue);
                yield return new TestCaseData(new Money(CurrencyInfo.FromCode("CNY"), ushort.MinValue), null).Returns(ushort.MinValue);
            }

            public static IEnumerable<TestCaseData> ToInt32_Source()
            {
                yield return new TestCaseData(new Money(CurrencyInfo.FromCode("CNY"), int.MaxValue + 1M), typeof(OverflowException)).Returns(null);
                yield return new TestCaseData(new Money(CurrencyInfo.FromCode("CNY"), int.MinValue - 1M), typeof(OverflowException)).Returns(null);
                yield return new TestCaseData(new Money(CurrencyInfo.FromCode("CNY"), int.MaxValue), null).Returns(int.MaxValue);
                yield return new TestCaseData(new Money(CurrencyInfo.FromCode("CNY"), int.MinValue), null).Returns(int.MinValue);
            }

            public static IEnumerable<TestCaseData> ToUInt32_Source()
            {
                yield return new TestCaseData(new Money(CurrencyInfo.FromCode("CNY"), uint.MaxValue + 1M), typeof(OverflowException)).Returns(null);
                yield return new TestCaseData(new Money(CurrencyInfo.FromCode("CNY"), uint.MinValue - 1M), typeof(OverflowException)).Returns(null);
                yield return new TestCaseData(new Money(CurrencyInfo.FromCode("CNY"), uint.MaxValue), null).Returns(uint.MaxValue);
                yield return new TestCaseData(new Money(CurrencyInfo.FromCode("CNY"), uint.MinValue), null).Returns(uint.MinValue);
            }

            public static IEnumerable<TestCaseData> ToInt64_Source()
            {
                yield return new TestCaseData(new Money(CurrencyInfo.FromCode("CNY"), long.MaxValue + 1M), typeof(OverflowException)).Returns(null);
                yield return new TestCaseData(new Money(CurrencyInfo.FromCode("CNY"), long.MinValue - 1M), typeof(OverflowException)).Returns(null);
                yield return new TestCaseData(new Money(CurrencyInfo.FromCode("CNY"), long.MaxValue), null).Returns(long.MaxValue);
                yield return new TestCaseData(new Money(CurrencyInfo.FromCode("CNY"), long.MinValue), null).Returns(long.MinValue);
            }

            public static IEnumerable<TestCaseData> ToUInt64_Source()
            {
                yield return new TestCaseData(new Money(CurrencyInfo.FromCode("CNY"), ulong.MaxValue + 1M), typeof(OverflowException)).Returns(null);
                yield return new TestCaseData(new Money(CurrencyInfo.FromCode("CNY"), ulong.MinValue - 1M), typeof(OverflowException)).Returns(null);
                yield return new TestCaseData(new Money(CurrencyInfo.FromCode("CNY"), ulong.MaxValue), null).Returns(ulong.MaxValue);
                yield return new TestCaseData(new Money(CurrencyInfo.FromCode("CNY"), ulong.MinValue), null).Returns(ulong.MinValue);
            }

            public static IEnumerable<TestCaseData> ToSingle_Source()
            {
                yield return new TestCaseData(new Money(CurrencyInfo.FromCode("CNY"), 1.1M)).Returns(1.1F);
                yield return new TestCaseData(new Money(CurrencyInfo.FromCode("CNY"), 0.99M)).Returns(0.99F);
            }

            public static IEnumerable<TestCaseData> ToDouble_Source()
            {
                yield return new TestCaseData(new Money(CurrencyInfo.FromCode("CNY"), 1.1M)).Returns(1.1D);
                yield return new TestCaseData(new Money(CurrencyInfo.FromCode("CNY"), 0.99M)).Returns(0.99D);
            }

            public static IEnumerable<TestCaseData> Parse_Source()
            {
                yield return new TestCaseData("11.1", null).Returns(new Money(11.1M));
                yield return new TestCaseData("CNY0.99", null).Returns(new Money(CurrencyInfo.FromCode("CNY"), 0.99M));
                yield return new TestCaseData("CNY 0.99", null).Returns(new Money(CurrencyInfo.FromCode("CNY"), 0.99M));
                yield return new TestCaseData("CNY ", null).Returns(new Money(CurrencyInfo.FromCode("CNY"), 0M));
                yield return new TestCaseData("CNY ¥1.11", null).Returns(new Money(CurrencyInfo.FromCode("CNY"), 1.11M));
                yield return new TestCaseData("fds", typeof(FormatException)).Returns(null);
                yield return new TestCaseData("", typeof(FormatException)).Returns(null);
                yield return new TestCaseData("1fdsf", typeof(FormatException)).Returns(null);
                yield return new TestCaseData("aa", typeof(FormatException)).Returns(null);
                yield return new TestCaseData("CNY ¥aa", typeof(FormatException)).Returns(null);
            }

            public static IEnumerable<TestCaseData> Divide_Decimal_Source2()
            {
                yield return new TestCaseData(1M, new Money(CurrencyInfo.FromCode("CNY"), 3)).Returns(new Money(CurrencyInfo.FromCode("CNY"), 0.33M));
                yield return new TestCaseData(2M, new Money(CurrencyInfo.FromCode("CNY"), 3)).Returns(new Money(CurrencyInfo.FromCode("CNY"), 0.67M));
                yield return new TestCaseData(1M, new Money(CurrencyInfo.FromCode("CNY"), 8)).Returns(new Money(CurrencyInfo.FromCode("CNY"), 0.13M));
            }

            [SuppressMessage("Style", "IDE1006:命名样式", Justification = "<挂起>")]
            public static IEnumerable<TestCaseData> op_Equality_Source()
            {
                yield return new TestCaseData(new Money(1.1251M), new Money(1.13M)).Returns(true);
                yield return new TestCaseData(new Money(1.1268M), new Money(1.13M)).Returns(true);
            }

            [SuppressMessage("Style", "IDE1006:命名样式", Justification = "<挂起>")]
            public static IEnumerable<TestCaseData> op_Explicit_Money_Decimal_Source()
            {
                yield return new TestCaseData(new Money(1.123456M)).Returns(1.123456M);
            }

            [SuppressMessage("Style", "IDE1006:命名样式", Justification = "<挂起>")]
            public static IEnumerable<TestCaseData> op_Explicit_Money_Int64_Source()
            {
                yield return new TestCaseData(new Money(1.123456M)).Returns(1L);
            }

            [SuppressMessage("Style", "IDE1006:命名样式", Justification = "<挂起>")]
            public static IEnumerable<TestCaseData> op_Explicit_Money_Single_Source()
            {
                yield return new TestCaseData(new Money(1.123456M)).Returns(1.123456F);
            }

            [SuppressMessage("Style", "IDE1006:命名样式", Justification = "<挂起>")]
            public static IEnumerable<TestCaseData> op_Explicit_Money_Double_Source()
            {
                yield return new TestCaseData(new Money(1.123456M)).Returns(1.123456D);
            }

            [SuppressMessage("Style", "IDE1006:命名样式", Justification = "<挂起>")]
            public static IEnumerable<TestCaseData> op_Explicit_Double_Money_Source()
            {
                yield return new TestCaseData(1.11D).Returns(new Money(1.11M));
            }

            [SuppressMessage("Style", "IDE1006:命名样式", Justification = "<挂起>")]
            public static IEnumerable<TestCaseData> op_Explicit_Single_Money_Source()
            {
                yield return new TestCaseData(1.11F).Returns(new Money(1.11M));
            }

            [SuppressMessage("Style", "IDE1006:命名样式", Justification = "<挂起>")]
            public static IEnumerable<TestCaseData> op_GreaterThan_Source()
            {
                yield return new TestCaseData(new Money(1M), new Money(2M)).Returns(false);
                yield return new TestCaseData(new Money(2M), new Money(1M)).Returns(true);
            }

            [SuppressMessage("Style", "IDE1006:命名样式", Justification = "<挂起>")]
            public static IEnumerable<TestCaseData> op_GreaterThanOrEqual_Source()
            {
                yield return new TestCaseData(new Money(1M), new Money(2M)).Returns(false);
                yield return new TestCaseData(new Money(2M), new Money(1M)).Returns(true);
                yield return new TestCaseData(new Money(1M), new Money(1M)).Returns(true);
            }

            [SuppressMessage("Style", "IDE1006:命名样式", Justification = "<挂起>")]
            public static IEnumerable<TestCaseData> op_Implicit_Byte_Money_Source()
            {
                yield return new TestCaseData((byte)1).Returns(new Money(1));
            }

            [SuppressMessage("Style", "IDE1006:命名样式", Justification = "<挂起>")]
            public static IEnumerable<TestCaseData> op_Implicit_Int64_Money_Source()
            {
                yield return new TestCaseData(1L).Returns(new Money(1));
            }

            [SuppressMessage("Style", "IDE1006:命名样式", Justification = "<挂起>")]
            public static IEnumerable<TestCaseData> op_Implicit_UInt32_Money_Source()
            {
                yield return new TestCaseData(1U).Returns(new Money(1));
            }

            [SuppressMessage("Style", "IDE1006:命名样式", Justification = "<挂起>")]
            public static IEnumerable<TestCaseData> op_Implicit_UInt64_Money_Source()
            {
                yield return new TestCaseData(1UL).Returns(new Money(1));
            }

            [SuppressMessage("Style", "IDE1006:命名样式", Justification = "<挂起>")]
            public static IEnumerable<TestCaseData> op_Implicit_UInt16_Money_Source()
            {
                yield return new TestCaseData((ushort)1).Returns(new Money(1));
            }

            [SuppressMessage("Style", "IDE1006:命名样式", Justification = "<挂起>")]
            public static IEnumerable<TestCaseData> op_Inequality_Source()
            {
                yield return new TestCaseData(new Money(1), new Money(1)).Returns(false);
                yield return new TestCaseData(new Money(1), new Money(2)).Returns(true);
            }

            [SuppressMessage("Style", "IDE1006:命名样式", Justification = "<挂起>")]
            public static IEnumerable<TestCaseData> op_LessThan_Source()
            {
                yield return new TestCaseData(new Money(1), new Money(2)).Returns(true);
                yield return new TestCaseData(new Money(1), new Money(1)).Returns(false);
                yield return new TestCaseData(new Money(2), new Money(1)).Returns(false);
            }

            [SuppressMessage("Style", "IDE1006:命名样式", Justification = "<挂起>")]
            public static IEnumerable<TestCaseData> op_LessThanOrEqual_Source()
            {
                yield return new TestCaseData(new Money(1), new Money(2)).Returns(true);
                yield return new TestCaseData(new Money(1), new Money(1)).Returns(true);
                yield return new TestCaseData(new Money(2), new Money(1)).Returns(false);
            }

            public static IEnumerable<TestCaseData> Compare_Source()
            {
                yield return new TestCaseData(new Money(1), new Money(2), null).Returns(-1);
                yield return new TestCaseData(new Money(2), new Money(1), null).Returns(1);
                yield return new TestCaseData(new Money(1), new Money(1), null).Returns(0);
                yield return new TestCaseData(new Money(CurrencyInfo.FromCode("CNY"), 1), new Money(CurrencyInfo.FromCode("CHE"), 1), typeof(InvalidCurrencyOperationException)).Returns(null);
            }

            public static IEnumerable<TestCaseData> CompareTo_Source()
            {
                yield return new TestCaseData(new Money(1), new Money(1), null).Returns(0);
                yield return new TestCaseData(new Money(1), null, null).Returns(1);
                yield return new TestCaseData(new Money(1), 1, typeof(ArgumentException)).Returns(null);
            }

            public static IEnumerable<TestCaseData> GetHashCode_Source()
            {
                yield return new TestCaseData(new Money(1), new Money(1)).Returns(true);
            }

            public static IEnumerable<TestCaseData> ToString_Source()
            {
                yield return new TestCaseData(new Money(CurrencyInfo.FromCode("CNY"), 1)).Returns("¥1.00");
                yield return new TestCaseData(new Money(CurrencyInfo.FromCode("CNY"), 1.123M)).Returns("¥1.12");
                yield return new TestCaseData(new Money(CurrencyInfo.FromCode("CNY"), 1.1251M)).Returns("¥1.13");
                yield return new TestCaseData(new Money(CurrencyInfo.FromCode("CNY"), 1.1257M)).Returns("¥1.13");
            }

            public static IEnumerable<TestCaseData> ToString_Format_Source()
            {
                yield return new TestCaseData(new Money(CurrencyInfo.FromCode("CNY"), 1), "I").Returns("CNY 1.00");
                yield return new TestCaseData(new Money(CurrencyInfo.FromCode("CNY"), 1.123M), null).Returns("¥1.12");
                yield return new TestCaseData(new Money(CurrencyInfo.FromCode("CNY"), 1.1251M), null).Returns("¥1.13");
                yield return new TestCaseData(new Money(CurrencyInfo.FromCode("CNY"), 1.1257M), null).Returns("¥1.13");
            }

            public static IEnumerable<TestCaseData> ToString_Format_Provider_Source()
            {
                yield return new TestCaseData(new Money(CurrencyInfo.FromCode("CNY"), 1), "I", CultureInfo.CurrentCulture.NumberFormat).Returns("CNY 1.00");
                yield return new TestCaseData(new Money(CurrencyInfo.FromCode("CNY"), 1.123M), null, null).Returns("¥1.12");
                yield return new TestCaseData(new Money(CurrencyInfo.FromCode("CNY"), 1.1251M), null, null).Returns("¥1.13");
                yield return new TestCaseData(new Money(CurrencyInfo.FromCode("CNY"), 1.1257M), null, null).Returns("¥1.13");
            }

            public static IEnumerable<TestCaseData> Equals_Source()
            {
                yield return new TestCaseData(new Money(1), null).Returns(false);
                yield return new TestCaseData(new Money(1), new Money(1)).Returns(true);
                yield return new TestCaseData(new Money(1), 1).Returns(false);
            }
        }

        [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
        private sealed class MoneyTestCaseSourceAttribute : TestCaseSourceAttribute
        {
            public MoneyTestCaseSourceAttribute(string sourceName)
                : base(typeof(MoneyTestsSources), sourceName) { }
        }
    }
}
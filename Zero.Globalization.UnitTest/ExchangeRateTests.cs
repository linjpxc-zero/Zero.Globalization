using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Zero.Globalization.UnitTest
{
    [TestFixture]
    internal class ExchangeRateTests
    {
        [Test]
        [ExchangeRateTestCaseSource(nameof(ExchangeRateTestSource.Parse_String_Source))]
        public ExchangeRate? Parse(string value, Type exceptionType)
        {
            if (exceptionType == null)
            {
                return ExchangeRate.Parse(value);
            }
            Assert.Throws(exceptionType, () => ExchangeRate.Parse(value));
            return null;
        }

        [Test]
        [ExchangeRateTestCaseSource(nameof(ExchangeRateTestSource.Parse_ReadOnlyMenory_Source))]
        public ExchangeRate? Parse(ReadOnlyMemory<char> value, Type exceptionType)
        {
            if (exceptionType == null)
            {
                return ExchangeRate.Parse(value.Span);
            }
            Assert.Throws(exceptionType, () => ExchangeRate.Parse(value.Span));
            return null;
        }

        [Test]
        public void NewTest()
        {
            Assert.Throws<ArgumentException>(() => new ExchangeRate(CurrencyInfo.FromCode("CNY"), CurrencyInfo.FromCode("CNY"), 1M));
            Assert.Throws<ArgumentException>(() => new ExchangeRate(CurrencyInfo.FromCode("USD"), CurrencyInfo.FromCode("CNY"), -1));
        }

        [Test]
        [ExchangeRateTestCaseSource(nameof(ExchangeRateTestSource.GetHashCode_Source))]
        public bool GetHashCode_Test(ExchangeRate objA, ExchangeRate objB)
            => objA.GetHashCode() == objB.GetHashCode();

        [Test]
        [ExchangeRateTestCaseSource(nameof(ExchangeRateTestSource.Convert_Source))]
        public Money? Convert_Test(ExchangeRate rate, Money money, Type exceptionType)
        {
            if (exceptionType == null)
            {
                return rate.Convert(money);
            }
            Assert.Throws(exceptionType, () => rate.Convert(money));
            return null;
        }

        [Test]
        [ExchangeRateTestCaseSource(nameof(ExchangeRateTestSource.op_Equality_Source))]
        [SuppressMessage("Style", "IDE1006:命名样式", Justification = "<挂起>")]
        public bool op_Equality_Test(ExchangeRate left, ExchangeRate right)
            => left == right;

        [Test]
        [ExchangeRateTestCaseSource(nameof(ExchangeRateTestSource.op_Inequality_Source))]
        [SuppressMessage("Style", "IDE1006:命名样式", Justification = "<挂起>")]
        public bool op_Inequality_Test(ExchangeRate left, ExchangeRate right)
           => left != right;

        [Test]
        [ExchangeRateTestCaseSource(nameof(ExchangeRateTestSource.Equals_Source))]
        public bool Equals_Test(ExchangeRate rate, object obj)
            => rate.Equals(obj);

        private static class ExchangeRateTestSource
        {
            public static IEnumerable<TestCaseData> Parse_String_Source()
            {
                yield return new TestCaseData("USD/CNY 0.70074", null).Returns(new ExchangeRate(CurrencyInfo.FromCode("USD"), CurrencyInfo.FromCode("CNY"), 0.70074M));
                yield return new TestCaseData("USDCNY 0.70074", null).Returns(new ExchangeRate(CurrencyInfo.FromCode("USD"), CurrencyInfo.FromCode("CNY"), 0.70074M));
                yield return new TestCaseData("", typeof(FormatException)).Returns(null);
                yield return new TestCaseData("USDCNY", typeof(FormatException)).Returns(null);
                yield return new TestCaseData("AAACNY 0.70074", typeof(FormatException)).Returns(null);
                yield return new TestCaseData("USDAAA 0.70074", typeof(FormatException)).Returns(null);
                yield return new TestCaseData("USDCNY abcd", typeof(FormatException)).Returns(null);
                yield return new TestCaseData("USDCN abcd", typeof(FormatException)).Returns(null);
            }

            public static IEnumerable<TestCaseData> Parse_ReadOnlyMenory_Source()
            {
                yield return new TestCaseData("USD/CNY 0.70074".AsMemory(), null).Returns(new ExchangeRate(CurrencyInfo.FromCode("USD"), CurrencyInfo.FromCode("CNY"), 0.70074M));
                yield return new TestCaseData("USDCNY 0.70074".AsMemory(), null).Returns(new ExchangeRate(CurrencyInfo.FromCode("USD"), CurrencyInfo.FromCode("CNY"), 0.70074M));
                yield return new TestCaseData("".AsMemory(), typeof(FormatException)).Returns(null);
                yield return new TestCaseData("USDCNY".AsMemory(), typeof(FormatException)).Returns(null);
                yield return new TestCaseData("AAACNY 0.70074".AsMemory(), typeof(FormatException)).Returns(null);
                yield return new TestCaseData("USDAAA 0.70074".AsMemory(), typeof(FormatException)).Returns(null);
                yield return new TestCaseData("USDCNY abcd".AsMemory(), typeof(FormatException)).Returns(null);
                yield return new TestCaseData("USDCN abcd".AsMemory(), typeof(FormatException)).Returns(null);
            }

            public static IEnumerable<TestCaseData> GetHashCode_Source()
            {
                yield return new TestCaseData(ExchangeRate.Parse("USDCNY 0.70074"), ExchangeRate.Parse("USDCNY 0.70074")).Returns(true);
            }

            public static IEnumerable<TestCaseData> Convert_Source()
            {
                yield return new TestCaseData(ExchangeRate.Parse("USDCNY 7.0074"), new Money(CurrencyInfo.FromCode("USD"), 1), null).Returns(new Money(CurrencyInfo.FromCode("CNY"), 7.01M));
                yield return new TestCaseData(ExchangeRate.Parse("USDCNY 7.0074"), new Money(CurrencyInfo.FromCode("USD"), 2), null).Returns(new Money(CurrencyInfo.FromCode("CNY"), 14.01M));
                yield return new TestCaseData(ExchangeRate.Parse("USDCNY 7.0074"), new Money(CurrencyInfo.FromCode("USD"), 99), null).Returns(new Money(CurrencyInfo.FromCode("CNY"), 693.73M));

                yield return new TestCaseData(ExchangeRate.Parse("USDCNY 7.0074"), new Money(CurrencyInfo.FromCode("CNY"), 1), null).Returns(new Money(CurrencyInfo.FromCode("USD"), 0.14M));
                yield return new TestCaseData(ExchangeRate.Parse("USDCNY 7.0074"), new Money(CurrencyInfo.FromCode("CNY"), 2), null).Returns(new Money(CurrencyInfo.FromCode("USD"), 0.29M));
                yield return new TestCaseData(ExchangeRate.Parse("USDCNY 7.0074"), new Money(CurrencyInfo.FromCode("CNY"), 99), null).Returns(new Money(CurrencyInfo.FromCode("USD"), 14.13M));

                yield return new TestCaseData(ExchangeRate.Parse("USDCNY 7.0074"), new Money(CurrencyInfo.FromCode("BOB"), 99), typeof(ArgumentException)).Returns(null);
            }

            [SuppressMessage("Style", "IDE1006:命名样式", Justification = "<挂起>")]
            public static IEnumerable<TestCaseData> op_Equality_Source()
            {
                yield return new TestCaseData(ExchangeRate.Parse("USDCNY 7.0074"), ExchangeRate.Parse("USDCNY 7.0074")).Returns(true);
                yield return new TestCaseData(ExchangeRate.Parse("USDCNY 7.0073"), ExchangeRate.Parse("USDCNY 7.0074")).Returns(false);
            }

            [SuppressMessage("Style", "IDE1006:命名样式", Justification = "<挂起>")]
            public static IEnumerable<TestCaseData> op_Inequality_Source()
            {
                yield return new TestCaseData(ExchangeRate.Parse("USDCNY 7.0074"), ExchangeRate.Parse("USDCNY 7.0074")).Returns(false);
                yield return new TestCaseData(ExchangeRate.Parse("USDCNY 7.0073"), ExchangeRate.Parse("USDCNY 7.0074")).Returns(true);
            }

            public static IEnumerable<TestCaseData> Equals_Source()
            {
                yield return new TestCaseData(ExchangeRate.Parse("USDCNY 7.0074"), ExchangeRate.Parse("USDCNY 7.0074")).Returns(true);
                yield return new TestCaseData(ExchangeRate.Parse("USDCNY 7.0074"), null).Returns(false);
                yield return new TestCaseData(ExchangeRate.Parse("USDCNY 7.0074"), 1).Returns(false);
            }
        }

        [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
        private sealed class ExchangeRateTestCaseSourceAttribute : TestCaseSourceAttribute
        {
            public ExchangeRateTestCaseSourceAttribute(string sourceName)
                : base(typeof(ExchangeRateTestSource), sourceName)
            {
            }
        }
    }
}
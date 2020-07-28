using NUnit.Framework;
using System;
using System.Collections.Generic;
using Zero.Globalization.Extensions;

namespace Zero.Globalization.UnitTest.Extensions
{
    [TestFixture]
    internal class MoneyExtensionsTests
    {
        [Test]
        [MoneyExtensionsTestsSource(nameof(MoneyExtensionsTestsSource.ToMinor_Source))]
        public int ToMinor_Test(Money money)
            => money.ToMinor();

        [Test]
        [MoneyExtensionsTestsSource(nameof(MoneyExtensionsTestsSource.ConvertTo_Source))]
        public Money ConvertTo_Test(Money money, ExchangeRate rate)
            => money.ConvertTo(rate);

        [Test]
        [MoneyExtensionsTestsSource(nameof(MoneyExtensionsTestsSource.ConvertTo_Rate_Source))]
        public Money ConvertTo_Test(Money money, CurrencyInfo currency, decimal rate)
           => money.ConvertTo(currency, rate);

        private static class MoneyExtensionsTestsSource
        {
            public static IEnumerable<TestCaseData> ToMinor_Source()
            {
                yield return new TestCaseData(new Money(CurrencyInfo.FromCode("CNY"), 1)).Returns(100);
            }

            public static IEnumerable<TestCaseData> ConvertTo_Source()
            {
                yield return new TestCaseData(new Money(CurrencyInfo.FromCode("USD"), 1), ExchangeRate.Parse("USDCNY 7.0074")).Returns(new Money(CurrencyInfo.FromCode("CNY"), 7.01M));
            }

            public static IEnumerable<TestCaseData> ConvertTo_Rate_Source()
            {
                yield return new TestCaseData(new Money(CurrencyInfo.FromCode("USD"), 1), CurrencyInfo.FromCode("CNY"), 7.0074M).Returns(new Money(CurrencyInfo.FromCode("CNY"), 7.01M));
                yield return new TestCaseData(new Money(CurrencyInfo.FromCode("USD"), 1), CurrencyInfo.FromCode("USD"), 1M).Returns(new Money(CurrencyInfo.FromCode("USD"), 1M));
            }
        }

        [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
        private sealed class MoneyExtensionsTestsSourceAttribute : TestCaseSourceAttribute
        {
            public MoneyExtensionsTestsSourceAttribute(string sourceName)
                : base(typeof(MoneyExtensionsTestsSource), sourceName)
            {
            }
        }
    }
}
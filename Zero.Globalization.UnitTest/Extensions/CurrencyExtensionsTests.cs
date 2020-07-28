using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Zero.Globalization.Extensions;

namespace Zero.Globalization.UnitTest.Extensions
{
    [TestFixture]
    internal class CurrencyExtensionsTests
    {
        [Test]
        [CurrencyExtensionsTestsSource(nameof(CurrencyExtensionsTestsSource.Money_Source))]
        public Money Money_Test(CurrencyInfo currency, decimal? value)
        {
            if (value == null)
            {
                return currency.Money();
            }
            return currency.Money(value.Value);
        }

        [Test]
        [CurrencyExtensionsTestsSource(nameof(CurrencyExtensionsTestsSource.GetCurrency_Region_Source))]
        public CurrencyInfo GetCurrency_Test(RegionInfo region)
            => region.GetCurrency();

        [Test]
        [CurrencyExtensionsTestsSource(nameof(CurrencyExtensionsTestsSource.GetCurrency_Culture_Source))]
        public CurrencyInfo GetCurrency_Test(CultureInfo culture)
            => culture.GetCurrency();

        [Test]
        public void GetEntities_Test()
        {
            Assert.IsTrue(CurrencyInfo.CurrentCurrency.GetEntities().Any());
        }

        private static class CurrencyExtensionsTestsSource
        {
            public static IEnumerable<TestCaseData> Money_Source()
            {
                yield return new TestCaseData(CurrencyInfo.FromCode("CNY"), null).Returns(new Money(CurrencyInfo.FromCode("CNY"), 0M));
                yield return new TestCaseData(CurrencyInfo.FromCode("CNY"), 1M).Returns(new Money(CurrencyInfo.FromCode("CNY"), 1M));
            }

            public static IEnumerable<TestCaseData> GetCurrency_Region_Source()
            {
                yield return new TestCaseData(new RegionInfo("cn")).Returns(CurrencyInfo.FromCode("CNY"));
            }

            public static IEnumerable<TestCaseData> GetCurrency_Culture_Source()
            {
                yield return new TestCaseData(CultureInfo.GetCultureInfo("zh-CN")).Returns(CurrencyInfo.FromCode("CNY"));
            }
        }

        [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
        private sealed class CurrencyExtensionsTestsSourceAttribute : TestCaseSourceAttribute
        {
            public CurrencyExtensionsTestsSourceAttribute(string sourceName)
                : base(typeof(CurrencyExtensionsTestsSource), sourceName)
            {
            }
        }
    }
}
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;

namespace Zero.Globalization.UnitTest
{
    [TestFixture]
    internal class CurrencyInfoTests
    {
        [TestCase("CNY", ExpectedResult = true)]
        [TestCase("BDE", ExpectedResult = false)]
        [TestCase("", ExpectedResult = false)]
        public bool TryFromCode_Test(string code)
        {
            return CurrencyInfo.TryFromCode(code, out _);
        }

        [TestCase("156", ExpectedResult = true)]
        [TestCase("123", ExpectedResult = false)]
        [TestCase("", ExpectedResult = false)]
        public bool TryFromNumeric_Test(string numeric)
        {
            return CurrencyInfo.TryFromNumeric(numeric, out _);
        }

        [Test]
        [CurrencyTestCaseSource(nameof(CurrencyInfoTestsSources.TryFromCode_ReadOnlyMemory_Source))]
        public bool TryFromCode_Test(ReadOnlyMemory<char> code)
        {
            return CurrencyInfo.TryFromCode(code.Span, out _);
        }

        [Test]
        [CurrencyTestCaseSource(nameof(CurrencyInfoTestsSources.TryFromNumeric_ReadOnlyMemory_Source))]
        public bool TryFromNumeric_Test(ReadOnlyMemory<char> numeric)
        {
            return CurrencyInfo.TryFromNumeric(numeric.Span, out _);
        }

        [Test]
        [CurrencyTestCaseSource(nameof(CurrencyInfoTestsSources.FromCode_ReadOnlyMemory_Source))]
        public CurrencyInfo? FromCode_Test(ReadOnlyMemory<char> code, Type exceptionType)
        {
            if (exceptionType == null)
            {
                return CurrencyInfo.FromCode(code.Span);
            }
            Assert.Throws(exceptionType, () => CurrencyInfo.FromCode(code.Span));
            return null;
        }

        [Test]
        [CurrencyTestCaseSource(nameof(CurrencyInfoTestsSources.FromNumeric_ReadOnlyMemory_Source))]
        public CurrencyInfo? FromNumeric_Test(ReadOnlyMemory<char> numeric, Type exceptionType)
        {
            if (exceptionType == null)
            {
                return CurrencyInfo.FromNumeric(numeric.Span);
            }
            Assert.Throws(exceptionType, () => CurrencyInfo.FromNumeric(numeric.Span));
            return null;
        }

        [Test]
        [CurrencyTestCaseSource(nameof(CurrencyInfoTestsSources.TryFromRegion_Source))]
        public bool TryFromRegion_Test(RegionInfo region, Type exceptionType)
        {
            if (exceptionType == null)
            {
                return CurrencyInfo.TryFromRegion(region, out _);
            }
            Assert.Throws(exceptionType, () => CurrencyInfo.TryFromRegion(region, out _));
            return false;
        }

        [TestCase("CN", ExpectedResult = true)]
        public bool TryFromRegion_Test(string regionName)
        {
            return CurrencyInfo.TryFromRegion(regionName, out _);
        }

        [Test]
        [CurrencyTestCaseSource(nameof(CurrencyInfoTestsSources.TryFromCulture_Source))]
        public bool TryFromCulture_Test(CultureInfo culture, Type exceptionType)
        {
            if (exceptionType == null)
            {
                return CurrencyInfo.TryFromCulture(culture, out _);
            }
            Assert.Throws(exceptionType, () => CurrencyInfo.TryFromCulture(culture, out _));
            return false;
        }

        [Test]
        [CurrencyTestCaseSource(nameof(CurrencyInfoTestsSources.FromCode_Source))]
        public CurrencyInfo? FromCode_Test(string code, Type exceptionType)
        {
            if (exceptionType == null)
            {
                return CurrencyInfo.FromCode(code);
            }
            Assert.Throws(exceptionType, () => CurrencyInfo.FromCode(code));
            return null;
        }

        [Test]
        [CurrencyTestCaseSource(nameof(CurrencyInfoTestsSources.FromNumeric_Source))]
        public CurrencyInfo? FromNumeric_Test(string numeric, Type exceptionType)
        {
            if (exceptionType == null)
            {
                return CurrencyInfo.FromNumeric(numeric);
            }
            Assert.Throws(exceptionType, () => CurrencyInfo.FromNumeric(numeric));
            return null;
        }

        [Test]
        [CurrencyTestCaseSource(nameof(CurrencyInfoTestsSources.FromRegion_Source))]
        public CurrencyInfo FromRegion_Test(RegionInfo region)
        {
            return CurrencyInfo.FromRegion(region);
        }

        [Test]
        [CurrencyTestCaseSource(nameof(CurrencyInfoTestsSources.FromRegion_String_Source))]
        public CurrencyInfo FromRegion_Test(string regionName)
        {
            return CurrencyInfo.FromRegion(regionName);
        }

        [Test]
        [CurrencyTestCaseSource(nameof(CurrencyInfoTestsSources.FromCulture_Source))]
        public CurrencyInfo FromCulture_Test(CultureInfo culture)
        {
            return CurrencyInfo.FromCulture(culture);
        }

        [Test]
        [CurrencyTestCaseSource(nameof(CurrencyInfoTestsSources.CurrencyEnglishName_Source))]
        public string CurrencyEnglishName_Test(CurrencyInfo currency)
            => currency.EnglishName;

        [Test]
        [CurrencyTestCaseSource(nameof(CurrencyInfoTestsSources.CurrencyDecimalDigits_Source))]
        public int CurrencyDecimalDigits_Test(CurrencyInfo currency)
            => currency.DecimalDigits;

        [Test]
        [CurrencyTestCaseSource(nameof(CurrencyInfoTestsSources.CurrencyMajorUnit_Source))]
        public decimal CurrencyMajorUnit_Test(CurrencyInfo currency)
        {
            return currency.MajorUnit;
        }

        [Test]
        [CurrencyTestCaseSource(nameof(CurrencyInfoTestsSources.CurrencyMinorUnit_Source))]
        public decimal CurrencyMinorUnit_Test(CurrencyInfo currency)
            => currency.MinorUnit;

        [Test]
        [CurrencyTestCaseSource(nameof(CurrencyInfoTestsSources.CurrencySymbol_Source))]
        public string CurrencySymbol_Test(CurrencyInfo currency)
            => currency.Symbol;

        [Test]
        [CurrencyTestCaseSource(nameof(CurrencyInfoTestsSources.CurrencyIsFund_Source))]
        public bool CurrencyIsFund_Test(CurrencyInfo currency)
            => currency.IsFund;

        [Test]
        [CurrencyTestCaseSource(nameof(CurrencyInfoTestsSources.CompareTo_Source))]
        public int CompareTo_Test(CurrencyInfo @this, object currency, Type exceptionType)
        {
            if (exceptionType == null)
            {
                return @this.CompareTo(currency);
            }
            Assert.Throws(exceptionType, () => @this.CompareTo(currency));
            return 0;
        }

        [Test]
        [CurrencyTestCaseSource(nameof(CurrencyInfoTestsSources.Equals_Source))]
        public bool Equals_Test(CurrencyInfo @this, object obj)
            => @this.Equals(obj);

        [TestCase(ExpectedResult = true)]
        public bool CurrentCurrency_Test()
            => CurrencyInfo.CurrentCurrency == CurrencyInfo.FromRegion(RegionInfo.CurrentRegion);

        [Test]
        [CurrencyTestCaseSource(nameof(CurrencyInfoTestsSources.Compare_Source))]
        public int Compare_Test(CurrencyInfo left, CurrencyInfo right)
            => CurrencyInfo.Compare(left, right);

        [Test]
        [CurrencyTestCaseSource(nameof(CurrencyInfoTestsSources.CompareNumeric_Source))]
        public int CompareNumeric_Test(CurrencyInfo left, CurrencyInfo right)
            => CurrencyInfo.CompareNumeric(left, right);

        [Test]
        [CurrencyTestCaseSource(nameof(CurrencyInfoTestsSources.op_Inequality_Source))]
        [SuppressMessage("Style", "IDE1006:命名样式", Justification = "<挂起>")]
        public bool op_Inequality_Test(CurrencyInfo left, CurrencyInfo right)
            => left != right;

        [Test]
        public void Currencies_Test()
        {
            Assert.IsTrue(CurrencyInfo.Currencies.Any());
        }

        private static class CurrencyInfoTestsSources
        {
            public static IEnumerable<TestCaseData> TryFromCode_ReadOnlyMemory_Source()
            {
                yield return new TestCaseData("CNY".AsMemory()).Returns(true);
                yield return new TestCaseData("DAD".AsMemory()).Returns(false);
                yield return new TestCaseData(ReadOnlyMemory<char>.Empty).Returns(false);
            }

            public static IEnumerable<TestCaseData> TryFromNumeric_ReadOnlyMemory_Source()
            {
                yield return new TestCaseData("156".AsMemory()).Returns(true);
                yield return new TestCaseData("123".AsMemory()).Returns(false);
                yield return new TestCaseData(ReadOnlyMemory<char>.Empty).Returns(false);
            }

            public static IEnumerable<TestCaseData> FromCode_ReadOnlyMemory_Source()
            {
                yield return new TestCaseData("CNY".AsMemory(), null).Returns(CurrencyInfo.FromCode("CNY"));
                yield return new TestCaseData(ReadOnlyMemory<char>.Empty, typeof(InvalidCurrencyCodeException)).Returns(null);
            }

            public static IEnumerable<TestCaseData> FromNumeric_ReadOnlyMemory_Source()
            {
                yield return new TestCaseData("156".AsMemory(), null).Returns(CurrencyInfo.FromCode("CNY"));
                yield return new TestCaseData(ReadOnlyMemory<char>.Empty, typeof(InvalidCurrencyNumericException)).Returns(null);
            }

            public static IEnumerable<TestCaseData> TryFromRegion_Source()
            {
                yield return new TestCaseData(new RegionInfo("CN"), null).Returns(true);
                yield return new TestCaseData(null, typeof(ArgumentNullException)).Returns(false);
            }

            public static IEnumerable<TestCaseData> TryFromCulture_Source()
            {
                yield return new TestCaseData(CultureInfo.GetCultureInfo("zh-CN"), null).Returns(true);
                yield return new TestCaseData(CultureInfo.InvariantCulture, typeof(ArgumentException)).Returns(false);
                yield return new TestCaseData(CultureInfo.GetCultureInfo("aa"), typeof(ArgumentException)).Returns(false);
                yield return new TestCaseData(null, typeof(ArgumentNullException)).Returns(false);
            }

            public static IEnumerable<TestCaseData> FromCode_Source()
            {
                yield return new TestCaseData("CNY", null).Returns(CurrencyInfo.FromCode("CNY"));
                yield return new TestCaseData("fd", typeof(InvalidCurrencyCodeException)).Returns(null);
            }

            public static IEnumerable<TestCaseData> FromNumeric_Source()
            {
                yield return new TestCaseData("156", null).Returns(CurrencyInfo.FromCode("CNY"));
                yield return new TestCaseData("fds", typeof(InvalidCurrencyNumericException)).Returns(null);
            }

            public static IEnumerable<TestCaseData> FromRegion_Source()
            {
                yield return new TestCaseData(new RegionInfo("CN")).Returns(CurrencyInfo.FromCode("CNY"));
            }

            public static IEnumerable<TestCaseData> FromRegion_String_Source()
            {
                yield return new TestCaseData("CN").Returns(CurrencyInfo.FromCode("CNY"));
            }

            public static IEnumerable<TestCaseData> FromCulture_Source()
            {
                yield return new TestCaseData(CultureInfo.GetCultureInfo("zh-CN")).Returns(CurrencyInfo.FromCode("CNY"));
            }

            public static IEnumerable<TestCaseData> CurrencyEnglishName_Source()
            {
                yield return new TestCaseData(CurrencyInfo.FromCode("CNY")).Returns("Yuan Renminbi");
            }

            public static IEnumerable<TestCaseData> CurrencyDecimalDigits_Source()
            {
                yield return new TestCaseData(CurrencyInfo.FromCode("CNY")).Returns(2);
            }

            public static IEnumerable<TestCaseData> CurrencyMajorUnit_Source()
            {
                yield return new TestCaseData(CurrencyInfo.FromCode("CNY")).Returns(1M);
            }

            public static IEnumerable<TestCaseData> CurrencyMinorUnit_Source()
            {
                yield return new TestCaseData(CurrencyInfo.FromCode("cny")).Returns(0.01M);
                yield return new TestCaseData(CurrencyInfo.FromCode("CLP")).Returns(1M);
            }

            public static IEnumerable<TestCaseData> CurrencySymbol_Source()
            {
                yield return new TestCaseData(CurrencyInfo.FromCode("CNY")).Returns("¥");
            }

            public static IEnumerable<TestCaseData> CurrencyIsFund_Source()
            {
                yield return new TestCaseData(CurrencyInfo.FromCode("CNY")).Returns(false);
            }

            public static IEnumerable<TestCaseData> CompareTo_Source()
            {
                yield return new TestCaseData(CurrencyInfo.FromCode("CNY"), null, null).Returns(1);
                yield return new TestCaseData(CurrencyInfo.FromCode("CNY"), CurrencyInfo.FromCode("CLP"), null).Returns(1);
                yield return new TestCaseData(CurrencyInfo.FromCode("CNY"), CurrencyInfo.FromCode("COP"), null).Returns(-1);
                yield return new TestCaseData(CurrencyInfo.FromCode("CNY"), CurrencyInfo.FromCode("CNY"), null).Returns(0);
                yield return new TestCaseData(CurrencyInfo.FromCode("CNY"), 1, typeof(ArgumentException)).Returns(0);
            }

            public static IEnumerable<TestCaseData> Equals_Source()
            {
                yield return new TestCaseData(CurrencyInfo.FromCode("CNY"), CurrencyInfo.FromCode("CNY")).Returns(true);
                yield return new TestCaseData(CurrencyInfo.FromCode("CNY"), 1).Returns(false);
            }

            public static IEnumerable<TestCaseData> Compare_Source()
            {
                yield return new TestCaseData(CurrencyInfo.FromCode("CNY"), CurrencyInfo.FromCode("CLP")).Returns(1);
                yield return new TestCaseData(CurrencyInfo.FromCode("CNY"), CurrencyInfo.FromCode("COP")).Returns(-1);
                yield return new TestCaseData(CurrencyInfo.FromCode("CNY"), CurrencyInfo.FromCode("CNY")).Returns(0);
            }

            public static IEnumerable<TestCaseData> CompareNumeric_Source()
            {
                yield return new TestCaseData(CurrencyInfo.FromCode("CNY"), CurrencyInfo.FromCode("CLP")).Returns(1);
                yield return new TestCaseData(CurrencyInfo.FromCode("CNY"), CurrencyInfo.FromCode("COP")).Returns(-1);
                yield return new TestCaseData(CurrencyInfo.FromCode("CNY"), CurrencyInfo.FromCode("CNY")).Returns(0);
            }

            [SuppressMessage("Style", "IDE1006:命名样式", Justification = "<挂起>")]
            public static IEnumerable<TestCaseData> op_Inequality_Source()
            {
                yield return new TestCaseData(CurrencyInfo.FromCode("CNY"), CurrencyInfo.FromCode("CNY")).Returns(false);
            }
        }

        [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
        private sealed class CurrencyTestCaseSourceAttribute : TestCaseSourceAttribute
        {
            public CurrencyTestCaseSourceAttribute(string sourceName)
                : base(typeof(CurrencyInfoTestsSources), sourceName)
            {
            }

            //public CurrencyTestCaseSourceAttribute(string sourceName, object[] methodParams)
            //    : base(typeof(CurrencyInfoTestsSources), sourceName, methodParams)
            //{
            //}
        }
    }
}
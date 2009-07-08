using System;
using NUnit.Framework;
using Ruhe.Utilities;

namespace Ruhe.Tests {
    [TestFixture]
    public class StringUtilitiesTests {
        [Test]
        public void Contains() {
            "this test".Contains("test").MustBeTrue();
            "this test".Contains("TEST").MustBeFalse();
            "this test".Contains("foo").MustBeFalse();
        }

        [Test]
        public void ContainsIgnoreCase() {
            "this test is neat".ContainsIgnoreCase("TEST").MustBeTrue();
            "this test is neat".ContainsIgnoreCase("rat").MustBeFalse();
        }

        [Test]
        public void CsvQuote() {
            Assert.AreEqual(String.Empty, ((string) null).CsvQuote());
            Assert.AreEqual(String.Empty, String.Empty.CsvQuote());
            Assert.AreEqual("\"foo,bar\"", "foo,bar".CsvQuote(), "should wrap in quotes if a comma is present");
            Assert.AreEqual("\"\"\"foo,bar\"\"\"", "\"foo,bar\"".CsvQuote(),
                            "should esacpe double quotes by doubling them");
        }

        [Test]
        public void EqualsIgnoreCase() {
            "test".EqualsIgnoreCase("TEST").MustBeTrue();
            "test".EqualsIgnoreCase("rat").MustBeFalse();
        }

        [Test]
        public void ForcePrefix() {
            Assert.AreEqual("rattest", "rat".WithPrefix("test"));
            Assert.AreEqual("rattest", "rat".WithPrefix("rattest"));
        }

        [Test]
        public void ForceSuffix() {
            Assert.AreEqual("rattest", "rat".WithSuffix("test"));
            Assert.AreEqual("rattest", "rattest".WithSuffix("test"));
        }

        [Test]
        public void IsEmpty() {
            Assert.IsTrue(StringUtilities.IsEmpty(null));
            Assert.IsTrue(string.Empty.IsEmpty());
            Assert.IsFalse("foo".IsEmpty());
        }

        [Test]
        public void IsNumeric() {
            Assert.IsTrue("1".IsNumeric());
            Assert.IsTrue("1,000.00".IsNumeric());
            Assert.IsTrue(" 1 ".IsNumeric());
            Assert.IsTrue("-1".IsNumeric());
            Assert.IsTrue("1.".IsNumeric());
            Assert.IsTrue("1.0".IsNumeric());
            Assert.IsTrue(".0".IsNumeric());
            Assert.IsFalse("1a".IsNumeric());
            Assert.IsFalse("1.0.0".IsNumeric());
            Assert.IsFalse("(1.0)".IsNumeric());
            Assert.IsFalse("$1.0".IsNumeric());
            Assert.IsFalse(string.Empty.IsNumeric());
        }

        [Test]
        public void NullToEmpty() {
            Assert.AreEqual(string.Empty, ((string) null).NullToEmpty());
            Assert.AreEqual(string.Empty, string.Empty.NullToEmpty());
            Assert.AreEqual("test", "test".NullToEmpty());
        }

        [Test]
        public void RemovePrefix() {
            Assert.AreEqual("test", "ratstest".WithoutPrefix("rats"));
            Assert.AreEqual("myratstest", "myratstest".WithoutPrefix("rats"), "should ignore missing prefix");
        }

        [Test]
        public void RemovePrefixByPattern() {
            Assert.AreEqual("test", "ratstest".WithoutPrefixPattern("RAT."));
            Assert.AreEqual("ratstest", "ratstest".WithoutPrefixPattern("test"));
        }

        [Test]
        public void RemoveSuffixByPattern() {
            Assert.AreEqual("test", "testrat".WithoutSuffixPattern("rAt"));
            Assert.AreEqual("testrat", "testrat".WithoutSuffixPattern("rrAt"));
        }

        [Test]
        public void StringAfter() {
            Assert.AreEqual("extension", "file.name.extension".StringAfterLast("."));
            Assert.AreEqual("file.name.extension", "file.name.extension".StringAfterLast(@"\"));
        }

        [Test]
        public void StringAfterFirst() {
            Assert.AreEqual("?foo?bar", "foo?foo?bar".StringAfterFirst("foo"));
            Assert.AreEqual(string.Empty, "foo".StringAfterFirst("foo"));
            Assert.AreEqual("foo?foo?bar", "foo?foo?bar".StringAfterFirst("zoinks"));
        }

        [Test]
        public void StringBeforeFirst() {
            Assert.AreEqual(string.Empty, "foo?foo?bar".StringBeforeFirst("foo"));
            Assert.AreEqual("foo?foo?", "foo?foo?bar".StringBeforeFirst("bar"));
            Assert.AreEqual("foo?foo?bar", "foo?foo?bar".StringBeforeFirst("zoinks"), "should ignore missing token");
        }

        [Test]
        public void StringBeforeLast() {
            Assert.AreEqual("foo?", "foo?foo?bar".StringBeforeLast("foo"));
            Assert.AreEqual("foo?", "foo?foo?bar".StringBeforeLast("foo"));
            Assert.AreEqual("foo?foo?bar", "foo?foo?bar".StringBeforeLast("zoinks"), "should ignore missing token");
        }

        [Test]
        public void TrimToEmpty() {
            Assert.AreEqual(String.Empty, StringUtilities.TrimToEmpty(null));
            Assert.AreEqual(String.Empty, String.Empty.TrimToEmpty());
            Assert.AreEqual("paul", "  paul ".TrimToEmpty());
        }

        [Test]
        public void TrimToNull() {
            Assert.IsNull(StringUtilities.TrimToNull(null));
            Assert.IsNull(string.Empty.TrimToNull());
            Assert.IsNull(" ".TrimToNull());
            Assert.AreEqual("v", " v ".TrimToNull());
        }
    }
}
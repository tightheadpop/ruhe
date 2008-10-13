using System;
using NUnit.Framework;
using Ruhe.Common.Utilities;

namespace Ruhe.Tests.Common {
    [TestFixture]
    public class StringUtilitiesTests {
        [Test]
        public void Compare() {
            Assert.IsTrue(StringUtilities.Compare("test", "TEST"));
            Assert.IsFalse(StringUtilities.Compare("test", "rat"));
        }

        [Test]
        public void Contains() {
            Assert.IsTrue(StringUtilities.Contains("this test is neat", "TEST"));
            Assert.IsFalse(StringUtilities.Contains("this test is neat", "rat"));
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
            Assert.AreEqual("test", "ratstest".WithoutPrefix("RAT."));
            Assert.AreEqual("ratstest", "ratstest".WithoutPrefix("test"));
        }

        [Test]
        public void RemoveSuffix() {
            Assert.AreEqual("test", "testrat".WithoutSuffix("rAt"));
            Assert.AreEqual("testrat", "testrat".WithoutSuffix("rrAt"));
        }

        [Test]
        public void StringAfter() {
            Assert.AreEqual("extension", "file.name.extension".StringAfter("."));
            Assert.AreEqual("file.name.extension", "file.name.extension".StringAfter(@"\"));
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
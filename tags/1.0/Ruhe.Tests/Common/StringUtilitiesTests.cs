using System;
using NUnit.Framework;
using Ruhe.Common;

namespace Ruhe.Tests.Common {
	[TestFixture]
	public class StringUtilitiesTests {
		[Test]
		public void NullToEmpty() {
			Assert.AreEqual(string.Empty, StringUtilities.NullToEmpty((string) null));
			Assert.AreEqual(string.Empty, StringUtilities.NullToEmpty(string.Empty));
			Assert.AreEqual("test", StringUtilities.NullToEmpty("test"));
		}

		[Test]
		public void Contains() {
			Assert.IsTrue(StringUtilities.Contains("this test is neat", "TEST"));
			Assert.IsFalse(StringUtilities.Contains("this test is neat", "rat"));
		}

		[Test]
		public void Compare() {
			Assert.IsTrue(StringUtilities.Compare("test", "TEST"));
			Assert.IsFalse(StringUtilities.Compare("test", "rat"));
		}

		[Test]
		public void IsNumeric() {
			Assert.IsTrue(StringUtilities.IsNumeric("1"));
			Assert.IsTrue(StringUtilities.IsNumeric("1,000.00"));
			Assert.IsTrue(StringUtilities.IsNumeric(" 1 "));
			Assert.IsTrue(StringUtilities.IsNumeric("-1"));
			Assert.IsTrue(StringUtilities.IsNumeric("1."));
			Assert.IsTrue(StringUtilities.IsNumeric("1.0"));
			Assert.IsTrue(StringUtilities.IsNumeric(".0"));
			Assert.IsFalse(StringUtilities.IsNumeric("1a"));
			Assert.IsFalse(StringUtilities.IsNumeric("1.0.0"));
			Assert.IsFalse(StringUtilities.IsNumeric("(1.0)"));
			Assert.IsFalse(StringUtilities.IsNumeric("$1.0"));
			Assert.IsFalse(StringUtilities.IsNumeric(string.Empty));
		}

		[Test]
		public void RemovePrefix() {
			Assert.AreEqual("test", StringUtilities.RemovePrefix("ratstest", "RAT."));
			Assert.AreEqual("ratstest", StringUtilities.RemovePrefix("ratstest", "test"));
		}

		[Test]
		public void RemoveSuffix() {
			Assert.AreEqual("test", StringUtilities.RemoveSuffix("testrat", "rAt"));
			Assert.AreEqual("testrat", StringUtilities.RemoveSuffix("testrat", "rrAt"));
		}

		[Test]
		public void ForcePrefix() {
			Assert.AreEqual("rattest", StringUtilities.ForcePrefix("rat", "test"));
			Assert.AreEqual("rattest", StringUtilities.ForcePrefix("rat", "rattest"));
		}

		[Test]
		public void ForceSuffix() {
			Assert.AreEqual("rattest", StringUtilities.ForceSuffix("rat", "test"));
			Assert.AreEqual("rattest", StringUtilities.ForceSuffix("rattest", "test"));
		}

		[Test]
		public void StringAfter() {
			Assert.AreEqual("extension", StringUtilities.StringAfter("file.name.extension", "."));
			Assert.AreEqual("file.name.extension", StringUtilities.StringAfter("file.name.extension", @"\"));
		}

		[Test]
		public void TrimToEmpty() {
			Assert.AreEqual(String.Empty, StringUtilities.TrimToEmpty(null));
			Assert.AreEqual(String.Empty, StringUtilities.TrimToEmpty(String.Empty));
			Assert.AreEqual("paul", StringUtilities.TrimToEmpty("  paul "));
		}

		[Test]
		public void CsvQuote() {
			Assert.AreEqual(String.Empty, StringUtilities.CsvQuote((string) null));
			Assert.AreEqual(String.Empty, StringUtilities.CsvQuote(String.Empty));
			Assert.AreEqual("\"foo,bar\"", StringUtilities.CsvQuote("foo,bar"), "should wrap in quotes if a comma is present");
			Assert.AreEqual("\"\"\"foo,bar\"\"\"", StringUtilities.CsvQuote("\"foo,bar\""),
			                "should esacpe double quotes by doubling them");
		}
	}
}
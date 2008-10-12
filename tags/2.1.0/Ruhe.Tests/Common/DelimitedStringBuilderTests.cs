using NUnit.Framework;
using Ruhe.Common;

namespace Ruhe.Tests.Common {
    [TestFixture]
    public class DelimitedStringBuilderTests {
        [Test]
        public void AppendTest() {
            DelimitedStringBuilder builder = new DelimitedStringBuilder(", ");
            builder.Append("test");
            builder.Append("test");
            builder.Append("test");
            builder.Append("test");
            string expected = "test, test, test, test";
            string actual = builder.ToString();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Clear() {
            DelimitedStringBuilder builder = new DelimitedStringBuilder(", ");
            builder.Append("foo");
            builder.Clear();
            Assert.AreEqual(string.Empty, builder.ToString());
        }
    }
}
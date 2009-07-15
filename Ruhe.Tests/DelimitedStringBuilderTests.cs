using NUnit.Framework;

namespace Ruhe.Tests {
    [TestFixture]
    public class DelimitedStringBuilderTests {
        [Test]
        public void AppendTest() {
            var builder = new DelimitedStringBuilder(", ");
            builder.Append("test");
            builder.Append("test");
            builder.Append("test");
            builder.Append("test");
            var expected = "test, test, test, test";
            var actual = builder.ToString();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Clear() {
            var builder = new DelimitedStringBuilder(", ");
            builder.Append("foo");
            builder.Clear();
            Assert.AreEqual(string.Empty, builder.ToString());
        }
    }
}
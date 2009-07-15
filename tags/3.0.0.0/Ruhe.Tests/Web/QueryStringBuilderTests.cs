using NUnit.Framework;
using Ruhe.Web;

namespace Ruhe.Tests.Web {
    [TestFixture]
    public class QueryStringBuilderTests {
        [Test]
        public void Decoding() {
            var builder = QueryStringBuilder.Parse("x=1%2&x=7");

            Assert.AreEqual(1, builder.Keys.Count, "Incorrect count of keys");
            Assert.AreEqual("x=1%252&x=7", builder.ToString(), "Incorrect concatenation");
        }

        [Test]
        public void EqualsInValue() {
            var builder = QueryStringBuilder.Parse("x=7=7");

            Assert.AreEqual("x=7%3d7", builder.ToString());
        }

        [Test]
        public void IgnoresInitialQuestionMark() {
            var builder = QueryStringBuilder.Parse("?x=1%2&?x=7");
            Assert.AreEqual("x=1%252&%3fx=7", builder.ToString());
        }

        [Test]
        public void ParseTest() {
            var builder = QueryStringBuilder.Parse("x=1%2c&x=+&y=3%3d%3d3");

            Assert.AreEqual(2, builder.Keys.Count, "Incorrect count of keys");
            Assert.AreEqual("x=1%2c&x=+&y=3%3d%3d3", builder.ToString(), "Incorrect concatenation");
        }

        [Test]
        public void ToStringTest() {
            var builder = new QueryStringBuilder {{"x", "1,"}, {"x", " "}, {"y", "3==3"}};

            Assert.AreEqual("x=1%2c&x=+&y=3%3d%3d3", builder.ToString(), "Incorrect concatenation");
        }

        [Test]
        public void ZeroLength() {
            Assert.AreEqual(string.Empty, new QueryStringBuilder().ToString());
        }
    }
}
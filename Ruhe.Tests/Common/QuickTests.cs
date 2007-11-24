using NUnit.Framework;
using Ruhe.Common;

namespace Ruhe.Tests.Common {
    [TestFixture]
    public class QuickTests {
        [Test]
        public void ListFromIndividualItems() {
            Assert.AreEqual(new string[] {"a", "b", "c"}, Quick.List("a", "b", "c"));
        }

        [Test]
        public void ListFromEnumerable() {
            Assert.AreEqual(new string[] {"a", "b", "c"}, Quick.List(new string[] {"a", "b", "c"}));
        }
    }
}
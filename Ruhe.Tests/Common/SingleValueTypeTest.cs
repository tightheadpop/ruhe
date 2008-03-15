using NUnit.Framework;
using Ruhe.Common;

namespace Ruhe.Tests.Common {
    [TestFixture]
    public class SingleValueTypeTest {
        [Test]
        public void EqualityOperators() {
            Assert.IsTrue(new CustomType(1) == new CustomType(1));
            Assert.IsTrue(new CustomType(1) != new CustomType(2));
            Assert.IsFalse(new CustomType(1) == new OtherCustomType(1));
        }

        [Test]
        public void Equals() {
            Assert.IsTrue(new CustomType(1).Equals(new CustomType(1)));
            Assert.IsFalse(new CustomType(1).Equals(new CustomType(2)));
            Assert.IsFalse(new CustomType(1).Equals(new OtherCustomType(1)));
        }

        [Test]
        public void HashCodeIsEqualToHashCodeOfUnderlyingString() {
            Assert.AreEqual(1f.GetHashCode(), new CustomType(1).GetHashCode());
        }

        [Test]
        public void ToSingleIsEqualToTheUnderlyingSingle() {
            Assert.AreEqual(1f, new CustomType(1f).ToSingle());
        }

        [Test]
        public void ToStringIsEqualToTheUnderlyingString() {
            Assert.AreEqual("1", new CustomType(1).ToString());
        }

        private class CustomType : SingleValueType {
            public CustomType(float i) : base(i) { }
        }

        private class OtherCustomType : SingleValueType {
            public OtherCustomType(float i) : base(i) { }
        }
    }
}
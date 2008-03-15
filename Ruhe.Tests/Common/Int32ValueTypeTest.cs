using NUnit.Framework;
using Ruhe.Common;

namespace Ruhe.Tests.Common {
    [TestFixture]
    public class Int32ValueTypeTest {
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
            Assert.AreEqual(1.GetHashCode(), new CustomType(1).GetHashCode());
        }

        [Test]
        public void ToInt32IsEqualToTheUnderlyingInt32() {
            Assert.AreEqual(1, new CustomType(1).ToInt32());
        }

        [Test]
        public void ToStringIsEqualToTheUnderlyingString() {
            Assert.AreEqual("1", new CustomType(1).ToString());
        }

        private class CustomType : Int32ValueType {
            public CustomType(int i) : base(i) {}
        }

        private class OtherCustomType : Int32ValueType {
            public OtherCustomType(int i) : base(i) {}
        }
    }
}
using System;
using NUnit.Framework;
using Ruhe.Common;

namespace Ruhe.Tests.Common {
    [TestFixture]
    public class StringValueTypeTest {
        [Test]
        public void EqualityOperators() {
            Assert.IsTrue(new CustomType("foo") == new CustomType("foo"));
            Assert.IsTrue(new CustomType("foo") != new CustomType("bar"));
            Assert.IsFalse(new CustomType("foo") == new OtherCustomType("foo"));
        }

        [Test]
        public void Equals() {
            Assert.IsTrue(new CustomType("foo").Equals(new CustomType("foo")));
            Assert.IsFalse(new CustomType("foo").Equals(new CustomType("bar")));
            Assert.IsFalse(new CustomType("foo").Equals(new OtherCustomType("foo")));
        }

        [Test]
        public void HashCodeIsEqualToHashCodeOfUnderlyingString() {
            Assert.AreEqual("foo".GetHashCode(), new CustomType("foo").GetHashCode());
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void MustHaveNonNullUnderlyingValue() {
            new CustomType(null);
        }

        [Test]
        public void ToStringIsEqualToTheUnderlyingString() {
            Assert.AreEqual("foo", new CustomType("foo").ToString());
        }

        private class CustomType : StringValueType {
            public CustomType(string s) : base(s) {}
        }

        private class OtherCustomType : StringValueType {
            public OtherCustomType(string s)
                : base(s) {}
        }
    }
}
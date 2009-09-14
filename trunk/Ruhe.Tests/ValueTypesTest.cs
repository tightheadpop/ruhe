using System;
using NUnit.Framework;
using LiquidSyntax.ForTesting;

namespace Ruhe.Tests {
    [TestFixture]
    public class ValueTypesTest {
        [Test]
        public void EqualityOperators() {
            Assert.IsTrue(new CustomFloat(1) == new CustomFloat(1));
            Assert.IsTrue(new CustomFloat(1) != new CustomFloat(2));
        }

        [Test]
        public void Equals() {
            Assert.IsTrue(new CustomFloat(1).Equals(new CustomFloat(1)));
            Assert.IsFalse(new CustomFloat(1).Equals(new CustomFloat(2)));
            Assert.IsFalse(new CustomFloat(1).Equals(new OtherCustomFloat(1)));
        }

        [Test]
        public void HashCodeIsEqualToHashCodeOfUnderlyingString() {
            Assert.AreEqual(1f.GetHashCode(), new CustomFloat(1).GetHashCode());
        }

        [Test]
        public void RequiresNonNullConstructorArgument() {
            try {
                new CustomString(null);
                Assert.Fail();
            }
            catch (ArgumentException) {
            }
        }

        [Test]
        public void ShouldCreateNonNullInstanceUsingFactoryMethod() {
            CustomString.From("foo").Should(Be.EqualTo(new CustomString("foo")));
        }

        [Test]
        public void ShouldCreateNullInstanceUsingFactoryMethodIfValueIsNull() {
            CustomString.From(null).Should(Be.Null);
        }

        [Test]
        public void ValueIsEqualToTheUnderlyingValue() {
            Assert.AreEqual(1f, new CustomFloat(1f).Value);
        }

        [Test]
        public void ValueStringIsEqualToTheUnderlyingValueString() {
            Assert.AreEqual("1", new CustomFloat(1).ToString());
        }

        private class CustomFloat : ValueType<float, CustomFloat> {
            public CustomFloat(float i) : base(i) {}
        }

        private class CustomString : ValueType<string, CustomString> {
            public CustomString(string value) : base(value) {}
        }

        private class OtherCustomFloat : ValueType<float, OtherCustomFloat> {
            public OtherCustomFloat(float i) : base(i) {}
        }
    }
}
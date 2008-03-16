using System;
using NUnit.Framework;
using Ruhe.Common;

namespace Ruhe.Tests.Common {
    [TestFixture]
    public class ValueTypesTest {
//        [Test]
//        public void CreateInt32ValueType() {
//            Assert.AreEqual(5, ValueTypes.Create<CustomInt32>(5).Value);
//            Assert.IsNull(ValueTypes.Create<CustomInt32>((int?) null));
//        }
//
//        [Test]
//        public void CreateSingleValueType() {
//            Assert.AreEqual(5.6f, ValueTypes.Create<CustomFloat>(5.6f).Value);
//            Assert.IsNull(ValueTypes.Create<CustomFloat>((float?)null));
//        }
//
//        [Test]
//        public void CreateStringValueType() {
//            Assert.AreEqual("moo", ValueTypes.Create<CustomString>("moo").ToString());
//            Assert.IsNull(ValueTypes.Create<CustomString>((string) null));
//        }

        [Test]
        public void EqualityOperators() {
            Assert.IsTrue(new CustomFloat(1) == new CustomFloat(1));
            Assert.IsTrue(new CustomFloat(1) != new CustomFloat(2));
            Assert.IsFalse(new CustomFloat(1) == new OtherCustomFloat(1));
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
        [ExpectedException(typeof(ArgumentException))]
        public void RequiresNonNullConstructorArgument() {
            new CustomString(null);
        }

        [Test]
        public void ValueIsEqualToTheUnderlyingValue() {
            Assert.AreEqual(1f, new CustomFloat(1f).Value);
        }

        [Test]
        public void ValueStringIsEqualToTheUnderlyingValueString() {
            Assert.AreEqual("1", new CustomFloat(1).ToString());
        }

        private class CustomFloat : ValueType<float> {
            public CustomFloat(float i) : base(i) {}
        }

//        private class CustomInt32 : ValueType<int> {
//            public CustomInt32(int value) : base(value) {}
//        }
//
        private class CustomString : ValueType<string> {
            public CustomString(string value) : base(value) {}
        }

        private class OtherCustomFloat : ValueType<float> {
            public OtherCustomFloat(float i) : base(i) {}
        }
    }
}
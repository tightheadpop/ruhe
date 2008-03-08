using System;
using NUnit.Framework;
using Ruhe.Common;

namespace Ruhe.Tests.Common {
    [TestFixture]
    public class ValidateTests {
        private const string ExpectedMessage = "doesn't matter";
        private const string ShouldNotFail = "should not fail";

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = ExpectedMessage)]
        public void HasNoNullElements() {
            Validate.HasNoNullElements(Quick.List(new object()), ShouldNotFail);
            Validate.HasNoNullElements(Quick.List<object>(1, null), ExpectedMessage);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = ExpectedMessage)]
        public void IsFalse() {
            Validate.IsFalse(false, ShouldNotFail);
            Validate.IsFalse(true, ExpectedMessage);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = ExpectedMessage)]
        public void IsNotEmpty() {
            Validate.IsNotEmpty(Quick.List(new object()), ShouldNotFail);
            Validate.IsNotEmpty(Quick.List<object>(), ExpectedMessage);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = ExpectedMessage)]
        public void IsNotEmptyDislikesNullLists() {
            Validate.IsNotEmpty(null, ExpectedMessage);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = ExpectedMessage)]
        public void IsNotNull() {
            Validate.IsNotNull(new object(), ShouldNotFail);
            Validate.IsNotNull(null, ExpectedMessage);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = ExpectedMessage)]
        public void IsNull() {
            Validate.IsNull(null, ShouldNotFail);
            Validate.IsNull(new object(), ExpectedMessage);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = ExpectedMessage)]
        public void IsTrue() {
            Validate.IsTrue(true, ShouldNotFail);
            Validate.IsTrue(false, ExpectedMessage);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = ExpectedMessage)]
        public void That() {
            Validate.That(true, ShouldNotFail);
            Validate.That(false, ExpectedMessage);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException), ExpectedMessage = ExpectedMessage)]
        public void ThrowsSpecificExceptionType() {
            ValidateOrThrow<InvalidOperationException>.That(false, ExpectedMessage);
        }
    }
}
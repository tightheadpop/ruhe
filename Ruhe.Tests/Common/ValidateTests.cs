using System;
using NUnit.Framework;
using Ruhe.Common;

namespace Ruhe.Tests.Common {
    [TestFixture]
    public class ValidateTests {
        private const string ExpectedFormattedMessage = ExpectedMessage + " 1";
        private const string ExpectedMessage = "doesn't matter";
        private const string Format = ExpectedMessage + " {0}";
        private const string ShouldNotFail = "should not fail";

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = ExpectedMessage)]
        public void HasNoNullElements() {
            Quick.List(new object()).MustHaveNoNullElements(ShouldNotFail);
            Quick.List<object>(1, null).MustHaveNoNullElements(ExpectedMessage);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void HasNoNullElementsDislikesNullLists() {
            object[] o = null;
            o.MustHaveNoNullElements(ExpectedMessage);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = ExpectedFormattedMessage)]
        public void HasNoNullElementsFormatted() {
            Quick.List<object>(1, null).MustHaveNoNullElements(Format, 1);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = ExpectedMessage)]
        public void IsFalse() {
            false.MustBeFalse(ShouldNotFail);
            true.MustBeFalse(ExpectedMessage);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = ExpectedFormattedMessage)]
        public void IsFalseFormatted() {
            true.MustBeFalse(Format, 1);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = ExpectedMessage)]
        public void IsNotEmpty() {
            Quick.List(new object()).MustNotBeEmpty(ShouldNotFail);
            Quick.List<object>().MustNotBeEmpty(ExpectedMessage);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = ExpectedMessage)]
        public void IsNotEmptyDislikesNullLists() {
            Validate.MustNotBeEmpty(null, ExpectedMessage);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = ExpectedFormattedMessage)]
        public void IsNotEmptyFormatted() {
            Validate.MustNotBeEmpty(Quick.List<object>(), Format, 1);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = ExpectedMessage)]
        public void IsNotNull() {
            new object().MustNotBeNull(ShouldNotFail);
            Validate.MustNotBeNull(null, ExpectedMessage);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = ExpectedFormattedMessage)]
        public void IsNotNullFormatted() {
            Validate.MustNotBeNull(null, Format, 1);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = ExpectedMessage)]
        public void IsTrue() {
            true.MustBeTrue(ShouldNotFail);
            false.MustBeTrue(ExpectedMessage);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = ExpectedFormattedMessage)]
        public void IsTrueFormatted() {
            false.MustBeTrue(Format, 1);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void MustEqual() {
            true.MustEqual(true);

            var o = new object();
            o.MustEqual(o);
            1.MustEqual(6 - 5);
            "p".MustEqual("p");
            "p".MustEqual("foo");
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = ExpectedMessage)]
        public void That() {
            Validate.That(true, ShouldNotFail);
            Validate.That(false, ExpectedMessage);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = ExpectedFormattedMessage)]
        public void ThatFormatted() {
            Validate.That(false, Format, 1);
        }
    }
}
using System;
using NUnit.Framework;
using LiquidSyntax.ForTesting;

namespace Ruhe.Tests {
    [TestFixture]
    public class ValidateTests {
        private const string ExpectedFormattedMessage = ExpectedMessage + " 1";
        private const string ExpectedMessage = "doesn't matter";
        private const string Format = ExpectedMessage + " {0}";
        private const string ShouldNotFail = "should not fail";

        [Test]
        public void HasNoNullElements() {
            Quick.List(new object()).MustHaveNoNullElements(ShouldNotFail);
            try {
                Quick.List<object>(1, null).MustHaveNoNullElements(ExpectedMessage);
                Assert.Fail();
            }
            catch (ArgumentException e) {
                e.Message.Should(Be.EqualTo(ExpectedMessage));
            }
        }

        [Test]
        public void HasNoNullElementsDislikesNullLists() {
            object[] o = null;
            try {
                o.MustHaveNoNullElements(ExpectedMessage);
                Assert.Fail();
            }
            catch (ArgumentException) {
            }
        }

        [Test]
        public void HasNoNullElementsFormatted() {
            try {
                Quick.List<object>(1, null).MustHaveNoNullElements(Format, 1);
                Assert.Fail();
            }
            catch (ArgumentException e) {
                e.Message.Should(Be.EqualTo(ExpectedFormattedMessage));
            }
        }

        [Test]
        public void IsFalse() {
            false.MustBeFalse(ShouldNotFail);
            try {
                true.MustBeFalse(ExpectedMessage);
                Assert.Fail();
            }
            catch (ArgumentException e) {
                e.Message.Should(Be.EqualTo(ExpectedMessage));
            }
        }

        [Test]
        public void IsFalseFormatted() {
            try {
                true.MustBeFalse(Format, 1);
                Assert.Fail();
            }
            catch (ArgumentException e) {
                e.Message.Should(Be.EqualTo(ExpectedFormattedMessage));
            }
        }

        [Test]
        public void IsNotEmpty() {
            Quick.List(new object()).MustNotBeEmpty(ShouldNotFail);
            try {
                Quick.List<object>().MustNotBeEmpty(ExpectedMessage);
                Assert.Fail();
            }
            catch (ArgumentException e) {
                e.Message.Should(Be.EqualTo(ExpectedMessage));
            }
        }

        [Test]
        public void IsNotEmptyDislikesNullLists() {
            try {
                Validate.MustNotBeEmpty(null, ExpectedMessage);
                Assert.Fail();
            }
            catch (ArgumentException e) {
                e.Message.Should(Be.EqualTo(ExpectedMessage));
            }
        }

        [Test]
        public void IsNotEmptyFormatted() {
            try {
                Validate.MustNotBeEmpty(Quick.List<object>(), Format, 1);
                Assert.Fail();
            }
            catch (ArgumentException e) {
                e.Message.Should(Be.EqualTo(ExpectedFormattedMessage));
            }
        }

        [Test]
        public void IsNotNull() {
            new object().MustNotBeNull(ShouldNotFail);
            try {
                Validate.MustNotBeNull(null, ExpectedMessage);
                Assert.Fail();
            }
            catch (ArgumentException e) {
                e.Message.Should(Be.EqualTo(ExpectedMessage));
            }
        }

        [Test]
        public void IsNotNullFormatted() {
            try {
                Validate.MustNotBeNull(null, Format, 1);
                Assert.Fail();
            }
            catch (ArgumentException e) {
                e.Message.Should(Be.EqualTo(ExpectedFormattedMessage));
            }
        }

        [Test]
        public void IsTrue() {
            true.MustBeTrue(ShouldNotFail);
            try {
                false.MustBeTrue(ExpectedMessage);
                Assert.Fail();
            }
            catch (ArgumentException e) {
                e.Message.Should(Be.EqualTo(ExpectedMessage));
            }
        }

        [Test]
        public void IsTrueFormatted() {
            try {
                false.MustBeTrue(Format, 1);
                Assert.Fail();
            }
            catch (ArgumentException e) {
                e.Message.Should(Be.EqualTo(ExpectedFormattedMessage));
            }
        }

        [Test]
        public void MustEqual() {
            true.MustEqual(true);

            var o = new object();
            o.MustEqual(o);
            1.MustEqual(6 - 5);
            "p".MustEqual("p");
            try {
                "p".MustEqual("foo");
                Assert.Fail();
            }
            catch (ArgumentException) {
            }
        }

        [Test]
        public void That() {
            Validate.That(true, ShouldNotFail);
            try {
                Validate.That(false, ExpectedMessage);
            }
            catch (ArgumentException e) {
                e.Message.Should(Be.EqualTo(ExpectedMessage));
            }
        }

        [Test]
        public void ThatFormatted() {
            try {
                Validate.That(false, Format, 1);
                Assert.Fail();
            }
            catch (ArgumentException e) {
                e.Message.Should(Be.EqualTo(ExpectedFormattedMessage));
            }
        }
    }
}
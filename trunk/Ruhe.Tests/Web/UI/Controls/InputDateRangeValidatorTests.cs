using System;
using NUnit.Framework;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Tests.Web.UI.Controls {
    [TestFixture]
    public class InputDateRangeValidatorTests {
        private TestableValidator validator;

        [SetUp]
        public void SetUp() {
            validator = new TestableValidator();
        }

        [Test]
        public void BothBlankIsOkay() {
            Assert.IsTrue(validator.Evaluate());
        }

        [Test]
        public void OnlyEndIsOkay() {
            validator.To.Value = DateTime.Today;
            Assert.IsTrue(validator.Evaluate());
        }

        [Test]
        public void OnlyStartIsOkay() {
            validator.From.Value = DateTime.Today;
            Assert.IsTrue(validator.Evaluate());
        }

        [Test]
        public void ValidatesStartIsOnOrBeforeEnd() {
            validator.To.Value = new DateTime(2000, 1, 1);
            validator.From.Value = new DateTime(2000, 1, 2);

            Assert.IsFalse(validator.Evaluate());
        }

        [Test]
        public void ValidRange() {
            validator.From.Value = DateTime.Today;
            validator.To.Value = DateTime.Today;
            Assert.IsTrue(validator.Evaluate());
        }

        private class TestableValidator : InputDateRangeValidator {
            public readonly InputDate From = new InputDate();
            public readonly InputDate To = new InputDate();

            public bool Evaluate() {
                return EvaluateIsValid();
            }

            protected override InputDate FindFromDate() {
                return From;
            }

            protected override InputDate FindToDate() {
                return To;
            }
        }
    }
}
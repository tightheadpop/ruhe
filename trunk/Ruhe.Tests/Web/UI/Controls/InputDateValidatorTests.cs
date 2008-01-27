using NUnit.Framework;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Tests.Web.UI.Controls {
    [TestFixture]
    public class InputDateValidatorTests {
        private InputDate input;
        private TestableValidator validator;

        [Test]
        public void EmptyValueIsValid() {
            Assert.IsTrue(validator.Evaluate());
        }

        [Test]
        public void InvalidInputIsCaught() {
            input.DatePattern = "dd-MM-yyyy";
            input.Text = "12-31-2005";
            Assert.IsFalse(validator.Evaluate());
        }

        [SetUp]
        public void SetUp() {
            input = new InputDate();
            validator = new TestableValidator();
            validator.Input = input;
        }

        private class TestableValidator : InputDateValidator {
            public InputDate Input;

            public bool Evaluate() {
                return EvaluateIsValid();
            }

            protected override InputDate GetControlToValidate() {
                return Input;
            }
        }
    }
}
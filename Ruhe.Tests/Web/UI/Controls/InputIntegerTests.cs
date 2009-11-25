using NUnit.Framework;
using LiquidSyntax.ForTesting;
using Ruhe.Web.UI.Controls;
using WatiN.Core;

namespace Ruhe.Tests.Web.UI.Controls {
    [TestFixture]
    public class InputIntegerTests : WatinTest<InputInteger> {

        [Test]
        public void HasNumericCssClass() {
            InputInteger.ClassName.Should(Be.EqualTo("numeric"));
        }

        [Test]
        public void IntegerShowOnlyOneValidatorAtATime() {
            InputInteger.TypeText("sdf");
            SubmitButton.ClickAndWait();
            RangeValidator.ShouldBeVisible();
            CompareValidator.ShouldNotBeVisible();
        }

        [Test]
        public void InvalidBelowLowerBoundOfRange() {
            InputInteger.TypeText("-1");
            SubmitButton.ClickAndWait();
            RangeValidator.ShouldBeVisible();
        }

        [Test]
        public void InvalidBeyondUpperBoundOfRange() {
            InputInteger.TypeText("25");
            SubmitButton.ClickAndWait();
            RangeValidator.ShouldBeVisible();
        }

        [Test]
        public void IsInvalidWithNonIntegerNumber() {
            InputInteger.TypeText("1.1");
            SubmitButton.ClickAndWait();
            RangeValidator.ShouldBeVisible();
        }

        [Test]
        public void IsValidWithInteger() {
            InputInteger.TypeText("1");
            SubmitButton.ClickAndWait();
            CompareValidator.ShouldNotBeVisible();
        }

        [Test]
        public void IsValidWithNegativeInteger() {
            InputInteger.TypeText("-1");
            SubmitButton.ClickAndWait();
            CompareValidator.ShouldNotBeVisible();
        }

        [Test]
        public void ValidWithinRange() {
            InputInteger.TypeText("0");
            SubmitButton.ClickAndWait();
            RangeValidator.ShouldNotBeVisible();
        }

        [SetUp]
        public void SetUp() {
            NavigateTo("InputIntegerTests.aspx");
        }

        private TextField InputInteger {
            get { return Browser.TextField(IdFor.It("inputNumber")); }
        }

        private WatiN.Core.Button SubmitButton {
            get { return Browser.Button(IdFor.It("submitButton")); }
        }

        private Span RangeValidator {
            get { return Browser.Span(IdFor.It("inputNumber_range")); }
        }

        private Span CompareValidator {
            get { return Browser.Span(IdFor.It("inputNumber_compare")); }
        }

    }
}
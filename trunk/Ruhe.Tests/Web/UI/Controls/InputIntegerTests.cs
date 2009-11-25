using NUnit.Framework;
using LiquidSyntax.ForTesting;
using Ruhe.Web.UI.Controls;
using WatiN.Core;

namespace Ruhe.Tests.Web.UI.Controls {
    [TestFixture]
    public class InputIntegerTests : WatinTest<InputInteger> {

        [Test]
        public void HasNumericCssClass() {
            InputPositiveInteger.ClassName.Should(Be.EqualTo("numeric positive-integer"));
            InputInteger.ClassName.Should(Be.EqualTo("numeric integer"));
        }

        [Test]
        public void IntegerShowOnlyOneValidatorAtATime() {
            InputPositiveInteger.TypeText("sdf");
            SubmitButton.ClickAndWait();
            InputPositiveIntegerRangeValidator.ShouldBeVisible();
            InputPositiveIntegerCompareValidator.ShouldNotBeVisible();
        }

        [Test]
        public void InvalidBelowLowerBoundOfRange() {
            InputPositiveInteger.TypeText("-1");
            SubmitButton.ClickAndWait();
            InputPositiveIntegerRangeValidator.ShouldBeVisible();
        }

        [Test]
        public void InvalidWhenValueIsBeyondUpperBoundOfRange() {
            InputPositiveInteger.TypeText("25");
            SubmitButton.ClickAndWait();
            InputPositiveIntegerRangeValidator.ShouldBeVisible();
        }

        [Test]
        public void IsInvalidDataTypeWithNonIntegerNumber() {
            InputPositiveInteger.TypeText("1.1");
            SubmitButton.ClickAndWait();
            InputPositiveIntegerRangeValidator.ShouldBeVisible();
        }

        [Test]
        public void IsValidDataTypeWithInteger() {
            InputPositiveInteger.TypeText("1");
            SubmitButton.ClickAndWait();
            InputPositiveIntegerCompareValidator.ShouldNotBeVisible();
        }

        [Test]
        public void IsValidDataTypeWithNegativeInteger() {
            InputPositiveInteger.TypeText("-1");
            SubmitButton.ClickAndWait();
            InputPositiveIntegerCompareValidator.ShouldNotBeVisible();
        }

        [Test]
        public void ValidWithinRange() {
            InputPositiveInteger.TypeText("0");
            SubmitButton.ClickAndWait();
            InputPositiveIntegerRangeValidator.ShouldNotBeVisible();
        }

        [Test]
        public void ShouldOnlyAcceptNumbersAsTypedInputForPositiveInteger() {
            TypeTextWithEvents(InputPositiveInteger, "-abc123");
            InputPositiveInteger.Text.Should(Be.EqualTo("123"));
        }

        [Test]
        public void ShouldOnlyAcceptNumbersAsTypedInputAfterAjaxPostbackForPositiveInteger() {
            SubmitButton.ClickAndWait();
            TypeTextWithEvents(InputPositiveInteger, "-abc123");
            InputPositiveInteger.Text.Should(Be.EqualTo("123"));
        }

        [Test]
        public void ShouldOnlyAcceptNumbersAsTypedInputForInteger() {
            TypeTextWithEvents(InputInteger, "-abc123");
            InputInteger.Text.Should(Be.EqualTo("-123"));
        }

        [Test]
        public void ShouldOnlyAcceptNumbersAsTypedInputAfterAjaxPostbackForInteger() {
            SubmitButton.ClickAndWait();
            TypeTextWithEvents(InputInteger, "-abc123");
            InputInteger.Text.Should(Be.EqualTo("-123"));
        }

        [Test]
        public void DoesNotAcceptTypedNegativeSignIfItIsAfterNumbers() {
            SubmitButton.ClickAndWait();
            TypeTextWithEvents(InputInteger, "abc1-23");
            InputInteger.Text.Should(Be.EqualTo("123"));
        }

        [SetUp]
        public void SetUp() {
            NavigateTo("InputIntegerTests.aspx");
        }

        private TextField InputPositiveInteger {
            get { return Browser.TextField(IdFor.It("inputPositiveInteger")); }
        }

        private TextField InputInteger {
            get { return Browser.TextField(IdFor.It("inputInteger")); }
        }

        private WatiN.Core.Button SubmitButton {
            get { return Browser.Button(IdFor.It("submitButton")); }
        }

        private Span InputPositiveIntegerRangeValidator {
            get { return Browser.Span(IdFor.It("inputPositiveInteger_range")); }
        }

        private Span InputPositiveIntegerCompareValidator {
            get { return Browser.Span(IdFor.It("inputPositiveInteger_compare")); }
        }

    }
}
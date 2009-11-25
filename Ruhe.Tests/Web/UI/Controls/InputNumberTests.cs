using LiquidSyntax.ForTesting;
using NUnit.Framework;
using Ruhe.Web.UI.Controls;
using WatiN.Core;

namespace Ruhe.Tests.Web.UI.Controls {
    [TestFixture]
    public class InputNumberTests : WatinTest<InputNumber> {
        [Test]
        public void DoubleShowOnlyOneValidatorAtATime() {
            InputPositiveNumber.TypeText("sdf");
            SubmitButton.ClickAndWait();
            FormatValidator.ShouldNotBeVisible();
            RangeValidator.ShouldBeVisible();
        }

        [Test]
        public void HasNumericCssClass() {
            InputPositiveNumber.ClassName.Should(Be.EqualTo("numeric number positive"));
            InputNumber.ClassName.Should(Be.EqualTo("numeric number"));
        }

        [Test]
        public void InvalidDataTypeValidation() {
            InputPositiveNumber.TypeText("1.2.2");
            SubmitButton.ClickAndWait();
            RangeValidator.ShouldBeVisible();
        }

        [Test]
        public void ValidDataTypeValidation() {
            InputPositiveNumber.TypeText("1.2");
            SubmitButton.ClickAndWait();
            FormatValidator.ShouldNotBeVisible();
        }

        [SetUp]
        public void SetUp() {
            NavigateTo("InputNumberTests.aspx");
        }

        private TextField InputPositiveNumber {
            get { return Browser.TextField(IdFor.It("inputPositiveNumber")); }
        }

        private TextField InputNumber {
            get { return Browser.TextField(IdFor.It("inputNumber")); }
        }

        private Span FormatValidator {
            get { return Browser.Span(IdFor.It("inputPositiveNumber_compare")); }
        }

        private Span RangeValidator {
            get { return Browser.Span(IdFor.It("inputPositiveNumber_range")); }
        }

        private WatiN.Core.Button SubmitButton {
            get { return Browser.Button(IdFor.It("submitButton")); }
        }
    }
}
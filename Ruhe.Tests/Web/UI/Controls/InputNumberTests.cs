using NUnit.Extensions.Asp;
using NUnit.Extensions.Asp.AspTester;
using NUnit.Framework;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Tests.Web.UI.Controls {
    [TestFixture]
    public class InputNumberTests : RuheWebTest<InputNumber> {
        private LabelTester formatErrorMessage;
        private TextBoxTester inputNumber;
        private LabelTester rangeErrorMessage;
        private ButtonTester submitButton;

        [Test]
        public void DoubleShowOnlyOneValidatorAtATime() {
            inputNumber.Text = "sdf";
            submitButton.Click();
            WebAssert.NotVisible(formatErrorMessage);
            WebAssert.Visible(rangeErrorMessage);
        }

        [Test]
        public void HasNumericCssClass() {
            StringAssert.Contains("class=\"numeric\"", Browser.CurrentPageText);
        }

        [Test]
        public void InvalidDoubleValidation() {
            inputNumber.Text = "1.2.2";
            submitButton.Click();
            WebAssert.Visible(rangeErrorMessage);
        }

        [Test]
        public void ValidDoubleValidation() {
            inputNumber.Text = "1.2";
            submitButton.Click();
            WebAssert.NotVisible(formatErrorMessage);
        }

        protected override void SetUp() {
            base.SetUp();
            LoadPage();
            inputNumber = new TextBoxTester(IdFor("inputNumber"));
            submitButton = new ButtonTester(IdFor("submitButton"));
            formatErrorMessage = new LabelTester(IdFor("inputNumber_compare"));
            rangeErrorMessage = new LabelTester(IdFor("inputNumber_range"));
        }
    }
}
using NUnit.Extensions.Asp;
using NUnit.Extensions.Asp.AspTester;
using NUnit.Framework;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Tests.Web.UI.Controls {
    [TestFixture]
    public class InputNumberTests : RuheWebTest<InputNumber> {
        private TextBoxTester inputNumber;
        private ButtonTester submitButton;
        private LabelTester formatErrorMessage;
        private LabelTester rangeErrorMessage;

        protected override void SetUp() {
            base.SetUp();
            LoadPage();
            inputNumber = new TextBoxTester(IdFor.It("inputNumber"));
            submitButton = new ButtonTester(IdFor.It("submitButton"));
            formatErrorMessage = new LabelTester(IdFor.It("inputNumber_compare"));
            rangeErrorMessage = new LabelTester(IdFor.It("inputNumber_range"));
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

        [Test]
        public void DoubleShowOnlyOneValidatorAtATime() {
            inputNumber.Text = "sdf";
            submitButton.Click();
            WebAssert.NotVisible(formatErrorMessage);
            WebAssert.Visible(rangeErrorMessage);
        }
    }
}
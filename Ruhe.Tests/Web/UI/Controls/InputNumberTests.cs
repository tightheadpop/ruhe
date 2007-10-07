using NUnit.Extensions.Asp;
using NUnit.Extensions.Asp.AspTester;
using NUnit.Framework;
using Ruhe.TestExtensions;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Tests.Web.UI.Controls {
    [TestFixture]
    public class InputNumberTests : WebFormTestCase {
        private TextBoxTester inputNumber;
        private ButtonTester submitButton;
        private LabelTester formatErrorMessage;
        private LabelTester rangeErrorMessage;

        protected override void SetUp() {
            base.SetUp();
            Browser.GetPage(ControlTesterUtilities.GetUrlPath(typeof(InputNumber)));
            inputNumber = new TextBoxTester(IdFor.It("inputNumber"));
            submitButton = new ButtonTester(IdFor.It("submitButton"));
            formatErrorMessage = new LabelTester(IdFor.It("inputNumber_numericValidator"));
            rangeErrorMessage = new LabelTester(IdFor.It("inputNumber_rangeValidator"));
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
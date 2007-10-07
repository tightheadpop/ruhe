using NUnit.Extensions.Asp;
using NUnit.Extensions.Asp.AspTester;
using NUnit.Framework;
using Ruhe.TestExtensions;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Tests.Web.UI.Controls {
    [TestFixture]
    public class InputIntegerTests : WebFormTestCase {
        private TextBoxTester inputNumber;
        private ButtonTester submitButton;
        private LabelTester formatErrorMessage;
        private LabelTester rangeErrorMessage;

        protected override void SetUp() {
            base.SetUp();
            Browser.GetPage(ControlTesterUtilities.GetUrlPath(typeof(InputInteger)));
            inputNumber = new TextBoxTester(IdFor.It("inputNumber"));
            submitButton = new ButtonTester(IdFor.It("submitButton"));
            formatErrorMessage = new LabelTester(IdFor.It("inputNumber_compare"));
            rangeErrorMessage = new LabelTester(IdFor.It("inputNumber_range"));
        }

        [Test]
        public void IsInvalidWithDouble() {
            inputNumber.Text = "1.1";
            submitButton.Click();
            WebAssert.Visible(rangeErrorMessage);
        }

        [Test]
        public void IsValidWithInteger() {
            inputNumber.Text = "1";
            submitButton.Click();
            WebAssert.NotVisible(formatErrorMessage);
        }

        [Test]
        public void IsValidWithNegativeInteger() {
            inputNumber.Text = "-1";
            submitButton.Click();
            WebAssert.NotVisible(formatErrorMessage);
        }
        [Test]
        public void InvalidBeyondUpperBoundOfRange() {
            inputNumber.Text = "25";
            submitButton.Click();
            WebAssert.Visible(rangeErrorMessage);
        }

        [Test]
        public void InvalidBelowLowerBoundOfRange() {
            inputNumber.Text = "-1";
            submitButton.Click();
            WebAssert.Visible(rangeErrorMessage);
            
        }

        [Test]
        public void ValidWithinRange() {
            inputNumber.Text = "0";
            submitButton.Click();
            WebAssert.NotVisible(rangeErrorMessage);
        }

        [Test]
        public void IntegerShowOnlyOneValidatorAtATime() {
            inputNumber.Text = "sdf";
            submitButton.Click();
            WebAssert.Visible(rangeErrorMessage);
            WebAssert.NotVisible(formatErrorMessage);
        }


    }
}
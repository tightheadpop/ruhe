using NUnit.Extensions.Asp;
using NUnit.Extensions.Asp.AspTester;
using NUnit.Framework;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Tests.Web.UI.Controls {
    [TestFixture]
    public class InputIntegerTests : RuheWebTest<InputInteger> {
        private LabelTester formatErrorMessage;
        private TextBoxTester inputNumber;
        private LabelTester rangeErrorMessage;
        private ButtonTester submitButton;

        [Test]
        public void HasNumericCssClass() {
            StringAssert.Contains("class=\"numeric\"", Browser.CurrentPageText);
        }

        [Test]
        public void IntegerShowOnlyOneValidatorAtATime() {
            inputNumber.Text = "sdf";
            submitButton.Click();
            WebAssert.Visible(rangeErrorMessage);
            WebAssert.NotVisible(formatErrorMessage);
        }

        [Test]
        public void InvalidBelowLowerBoundOfRange() {
            inputNumber.Text = "-1";
            submitButton.Click();
            WebAssert.Visible(rangeErrorMessage);
        }

        [Test]
        public void InvalidBeyondUpperBoundOfRange() {
            inputNumber.Text = "25";
            submitButton.Click();
            WebAssert.Visible(rangeErrorMessage);
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
        public void ValidWithinRange() {
            inputNumber.Text = "0";
            submitButton.Click();
            WebAssert.NotVisible(rangeErrorMessage);
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
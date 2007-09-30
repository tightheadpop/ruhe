using NUnit.Extensions.Asp;
using NUnit.Extensions.Asp.AspTester;
using NUnit.Framework;
using Ruhe.TestExtensions;
using Ruhe.Web;
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

			inputNumber = new TextBoxTester(IdFor.It("inputNumber"));
			submitButton = new ButtonTester(IdFor.It("submitButton"));
			formatErrorMessage = new LabelTester(IdFor.It("inputNumber_numericValidator"));
			rangeErrorMessage = new LabelTester(IdFor.It("inputNumber_rangeValidator"));
		}

		[Test]
		public void InvalidIntegerValidationAsText() {
			LoadPage(NumericFormat.Integer);
			inputNumber.Text = "NaN";
			submitButton.Click();
			AssertVisibility(formatErrorMessage, true);
		}

		[Test]
		public void InvalidIntegerValidationAsDouble() {
			LoadPage(NumericFormat.Integer);
			inputNumber.Text = "1.1";
			submitButton.Click();
			AssertVisibility(formatErrorMessage, true);
		}

		[Test]
		public void ValidIntegerValidation() {
			LoadPage(NumericFormat.Integer);
			inputNumber.Text = "1";
			submitButton.Click();
			AssertVisibility(formatErrorMessage, false);

			LoadPage(NumericFormat.Integer);
			inputNumber.Text = "-1";
			submitButton.Click();
			AssertVisibility(formatErrorMessage, false);
		}

		[Test]
		public void InvalidDoubleValidation() {
			LoadPage(NumericFormat.Double);
			inputNumber.Text = "1.2.2";
			submitButton.Click();
			AssertVisibility(formatErrorMessage, true);
		}

		[Test]
		public void ValidDoubleValidation() {
			LoadPage(NumericFormat.Double);
			inputNumber.Text = "1.2";
			submitButton.Click();
			AssertVisibility(formatErrorMessage, false);
		}

		[Test]
		public void InvalidRangeValidation() {
			LoadPage(NumericFormat.Integer, 0, 24);
			inputNumber.Text = "25";
			submitButton.Click();
			AssertVisibility(rangeErrorMessage, true);

			LoadPage(NumericFormat.Integer, 0, 24);
			inputNumber.Text = "-1";
			submitButton.Click();
			AssertVisibility(rangeErrorMessage, true);
		}

		[Test]
		public void ValidRangeValidation() {
			LoadPage(NumericFormat.Integer, 0, 24);
			inputNumber.Text = "0";
			submitButton.Click();
			AssertVisibility(rangeErrorMessage, false);

			LoadPage(NumericFormat.Integer, 0, 24);
			inputNumber.Text = "24";
			submitButton.Click();
			AssertVisibility(rangeErrorMessage, false);
		}

		[Test]
		public void IntegerShowOnlyOneValidatorAtATime() {
			LoadPage(NumericFormat.Integer);
			inputNumber.Text = "sdf";
			submitButton.Click();
			AssertVisibility(formatErrorMessage, true);
			AssertVisibility(rangeErrorMessage, false);
		}

		[Test]
		public void DoubleShowOnlyOneValidatorAtATime() {
			LoadPage(NumericFormat.Integer, 0, 24);
			inputNumber.Text = "sdf";
			submitButton.Click();
			AssertVisibility(formatErrorMessage, false);
			AssertVisibility(rangeErrorMessage, true);
		}

		private void LoadPage(NumericFormat format) {
			Browser.GetPage(ControlTesterUtilities.GetUrlPath(typeof(InputNumber)) + "?mode=" + format);
		}

		private void LoadPage(NumericFormat format, double minimum, double maximum) {
			QueryStringBuilder builder = new QueryStringBuilder();
			builder.Add("mode", format.ToString());
			builder.Add("min", minimum.ToString());
			builder.Add("max", maximum.ToString());
			Browser.GetPage(ControlTesterUtilities.GetUrlPath(typeof(InputNumber)) + "?" + builder);
		}
	}
}
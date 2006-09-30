using System.Xml;
using NUnit.Extensions.Asp;
using NUnit.Extensions.Asp.AspTester;
using NUnit.Framework;
using Ruhe.Common;
using Ruhe.TestExtensions;
using Ruhe.Web.UI.Controls.Validators;

namespace Ruhe.Tests.Web.UI.Controls.Validators {
	[TestFixture]
	public class ValidatorControllerTests : WebFormTestCase {
		private ValidationSummaryTester summary;
		private ButtonTester submit;
		private TextBoxTester ruheTextBox;

		protected override void SetUp() {
			base.SetUp();
			Browser.GetPage(ControlTesterUtilities.GetUrlPath(typeof(ValidatorController)));

			summary = new ValidationSummaryTester("summary", CurrentWebForm);
			submit = new ButtonTester("submit", CurrentWebForm);
			ruheTextBox = new TextBoxTester("ruheTextBox", CurrentWebForm);
		}

		[Test]
		public void InitialPageState() {
			AssertVisibility(summary, false);
			AssertVisibility(submit, true);
			AssertVisibility(ruheTextBox, true);
		}

		[Test]
		public void ValidatorSetUp() {
			submit.Click();
			AssertEquals("expected 1 error message", 1, summary.Messages.Length);

			string message = summary.Messages[0];

			Assert("the error message should be an anchor tag", message.StartsWith("<a "));
			Assert("message must end have 'in the {label text} field.'",
			       StringUtilities.Contains(message, "in the Ruhe field."));

			XmlDocument page = ControlTesterUtilities.GetXmlElement(ruheTextBox).OwnerDocument;
			XmlNodeList validationImages = page.SelectNodes("//span[@class = \"validation\"]/img");
			AssertEquals("the error icon and/or required icon is missing", 2, validationImages.Count);
		}
	}
}
using System;
using System.Xml;
using NUnit.Extensions.Asp;
using NUnit.Extensions.Asp.AspTester;
using NUnit.Framework;
using Ruhe.Common;
using Ruhe.TestExtensions;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Tests.Web.UI.Controls {
	[TestFixture]
	public class InputTextBoxTests : WebFormTestCase {
		private TextBoxTester testBox;
		private TextBoxTester aspxRequired;
		private ButtonTester submitButton;
		private ValidationSummaryTester summary;
		private LabelTester readOnly;
		private XmlDocument xmlDocument;
		private LabelTester resultLabel;

		protected override void SetUp() {
			base.SetUp();
			xmlDocument = new XmlDocument();
			testBox = new TextBoxTester("testBox", CurrentWebForm);
			aspxRequired = new TextBoxTester("aspxRequired", CurrentWebForm);
			submitButton = new ButtonTester("submitButton", CurrentWebForm);
			summary = new ValidationSummaryTester("summary", CurrentWebForm);
			readOnly = new LabelTester("testBox_readOnly", CurrentWebForm);
			resultLabel = new LabelTester("result", CurrentWebForm);
		}

		[Test]
		public void NotRequired() {
			LoadPage();
			AssertRequiredIsVisible(false);

			submitButton.Click();
			AssertVisibility(summary, false);
		}

		[Test]
		public void Required() {
			LoadPage("Required");

			AssertRequiredIsVisible(true);

			submitButton.Click();
			Assert(summary.Messages.Length == 1);

			testBox.Text = "non-empty";
			submitButton.Click();
			AssertVisibility(summary, false);
		}

		[Test]
		public void EnsureInvalidFieldStopsProcessingOfClickEventHandler() {
			LoadPage("Required");
			submitButton.Click();
			AssertEquals("click handler was executed after failed validation", String.Empty, resultLabel.Text);
		}

		[Test]
		public void NoRegexValidation() {
			LoadPage();
			testBox.Text = "12";
			submitButton.Click();
			AssertVisibility(summary, false);
		}

		[Test]
		public void RegexValidation() {
			// expression in page = \d{3}
			string[] badValues = new string[] {"12", "1234", "a123", "abc"};

			LoadPage("Regex");

			foreach (string badValue in badValues) {
				testBox.Text = badValue;
				submitButton.Click();
				Assert(summary.Messages.Length == 1);
			}

			testBox.Text = "123";
			submitButton.Click();
			AssertVisibility(summary, false);
		}

		[Test]
		public void NotReadOnly() {
			LoadPage();
			AssertVisibility(readOnly, false);
			AssertVisibility(testBox, true);
			AssertEquals(1, xmlDocument.SelectNodes("//input[@id = \"testBox\"][@class = \"test\"]").Count);
			AssertEquals(0, xmlDocument.SelectNodes("//span[@id = \"testBox_readOnly\"][@class = \"test\"]").Count);
		}

		[Test]
		public void ReadOnly() {
			LoadPage("ReadOnly");
			Console.WriteLine(Browser.CurrentPageText);
			AssertVisibility(readOnly, true);
			AssertVisibility(testBox, false);
			AssertEquals(0, xmlDocument.SelectNodes("//input[@id = \"testBox\"][@class = \"test\"]").Count);
			AssertEquals("&amp;test", xmlDocument.SelectNodes("//span[@id = \"testBox_readOnly\"][@class = \"test\"]")[0].InnerXml);
		}

		[Test]
		public void ControlCollection() {
			InputTextBox box = new InputTextBox();
			Assert(box.Controls[0] != null);
		}

		[Test]
		public void ErrorMessageFromValidatorController() {
			LoadPage("Required");
			submitButton.Click();

			Assert(StringUtilities.Contains(summary.Messages[0], "in the testBox field."));
		}

		[Test]
		public void RequiredSetInAspx() {
			LoadPage("AspxRequired");
			AssertVisibility(aspxRequired, true);
			AssertVisibility(testBox, false);

			submitButton.Click();
			Assert(summary.Messages.Length == 1);
		}

		private void LoadPage() {
			LoadPage(string.Empty);
		}

		private void LoadPage(string option) {
			string url = ControlTesterUtilities.GetUrlPath(typeof(InputTextBox));
			Browser.GetPage(string.Format("{0}?{1}=on", url, option));
			xmlDocument.LoadXml(Browser.CurrentPageText);
		}

		private void AssertRequiredIsVisible(bool visibility) {
			AssertEquals(Convert.ToInt32(visibility), xmlDocument.SelectNodes("//img[@title = \"Required\"]").Count);
		}
	}
}
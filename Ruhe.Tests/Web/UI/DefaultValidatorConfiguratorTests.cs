using System.Web.UI.WebControls;
using AjaxControlToolkit;
using NUnit.Extensions.Asp;
using NUnit.Extensions.Asp.AspTester;
using NUnit.Framework;
using Ruhe.TestExtensions;
using Ruhe.Web.UI;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Tests.Web.UI {
	[TestFixture]
	public class DefaultValidatorConfiguratorTests : WebFormTestCase {
		private ValidationSummaryTester summary;
		private ButtonTester submitButton;

		private void LoadPage() {
			Browser.GetPage(ControlTesterUtilities.GetUrlPath(typeof(InputTextBox)) + "?Required=on");
			summary = new ValidationSummaryTester(IdFor.It("summary"));
			submitButton = new ButtonTester(IdFor.It("submitButton"));
		}

		[Test]
		public void ErrorMessagesAreConfiguredProperly() {
			LoadPage();
			submitButton.Click();

			string errorMessage = summary.Messages[0];
			StringAssert.Contains("in the testBox field.", errorMessage, "the field's label text should be used in completing the validation message that appears in the summary");
			StringAssert.StartsWith("<a ", errorMessage, "The error message should start with a link");
			StringAssert.Contains("you're wrong", errorMessage, "The error message should include the original error message");
		}

		[Test]
		public void GeneratedValidationSummaryJavaScriptUsesCorrectClientId() {
			LoadPage();
			StringAssert.Contains(IdFor.It("testBox", "document.getElementById(&quot;{0}&quot;).focus();"), Browser.CurrentPageText);
		}

		[Test]
		public void RequiredValidatorHasRequiredIcon() {
			InputTextBox inputTextBox = new InputTextBox();
			inputTextBox.ID = "foo";
			inputTextBox.LabelText = "Field Name";
			inputTextBox.ErrorMessage = "you're wrong";
			DefaultValidatorConfigurator.ConfigureValidators(inputTextBox);
			Assert.AreEqual(1, ControlUtilities.FindRecursive(inputTextBox, typeof(RequiredIcon)).Count);
		}

		[Test]
		public void EachValidatorHasValidatorExtender() {
			InputTextBox inputTextBox = new InputTextBox();
			inputTextBox.ID = "foo";
			DefaultValidatorConfigurator.ConfigureValidators(inputTextBox);
			foreach (BaseValidator validator in ControlUtilities.FindRecursive(inputTextBox, typeof(BaseValidator))) {
				ValidatorCalloutExtender extender = ControlUtilities.FindRecursive(inputTextBox, validator.ID + "_callout") as ValidatorCalloutExtender;
				Assert.IsNotNull(extender);
				Assert.AreEqual(validator.ID, extender.TargetControlID);
			}
		}

		[Test]
		public void SetsValidationGroupOnAllChildValidators() {
			InputTextBox inputTextBox = new InputTextBox();
			inputTextBox.ValidationGroup = "myGroup";
			DefaultValidatorConfigurator.ConfigureValidators(inputTextBox);

			foreach (BaseValidator validator in ControlUtilities.FindRecursive(inputTextBox, typeof(BaseValidator))) {
				Assert.AreEqual("myGroup", validator.ValidationGroup);
			}
		}
	}
}
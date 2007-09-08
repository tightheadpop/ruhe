using System.Web.UI;
using System.Web.UI.WebControls;
using NUnit.Framework;
using Ruhe.Common;
using Ruhe.Web.UI;
using Ruhe.Web.UI.Controls;
using Ruhe.Web.UI.Controls.Icons;
using Ruhe.Web.UI.Controls.Validators;

namespace Ruhe.Tests.Web.UI.Controls.Validators {
	[TestFixture]
	public class ValidatorControllerTests {
		private InputTextBox textbox;

		[Test]
		public void ErrorMessagesAreSetUpCorrectly() {
			foreach (BaseValidator validator in ControlUtilities.FindControlsRecursive(textbox, typeof(BaseValidator))) {
				Assert.AreEqual(textbox.ID, validator.ControlToValidate);
				Assert.IsTrue(validator.ErrorMessage.StartsWith("<a "), "The error message should start with a link");
				Assert.IsTrue(StringUtilities.Contains(validator.ErrorMessage, "in the Field Name field."), "The error message should include the label text");
				Assert.IsTrue(StringUtilities.Contains(validator.ErrorMessage, "you're wrong"), "The error message should include the original error message");
			}
		}

		[Test]
		public void RequiredValidatorHasRequiredIcon() {
			Assert.AreEqual(1, ControlUtilities.FindControlsRecursive(textbox, typeof(RequiredIcon)).Count);
		}

		[SetUp]
		public void SetUp() {
			textbox = new InputTextBox();
			textbox.ID = "foo";
			textbox.LabelText = "Field Name";
			textbox.ErrorMessage = "you're wrong";
			NamingContainer container = new NamingContainer();
			container.Controls.Add(textbox);
			ValidatorController.InitializeValidators(textbox);
		}

		private class NamingContainer : Control, INamingContainer {}
	}
}
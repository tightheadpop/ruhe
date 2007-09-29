using NUnit.Extensions.Asp;
using NUnit.Extensions.Asp.AspTester;
using NUnit.Framework;
using Ruhe.TestExtensions;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Tests.Web.UI.Controls {
	[TestFixture]
	public class UpdateLabelTests : WebFormTestCase {
		private ButtonTester saveButton;
		private LabelTester proof;

		[Test]
		public void RetainsBehavior() {
			saveButton.Click();
			Assert.IsNotEmpty(proof.Text);
		}

		[Test]
		public void EmitsStyleScript() {
			StringAssert.Contains("document.getElementById('ajax_content_updateLabel').style.display = 'inline';", Browser.CurrentPageText);
		}

		protected override void SetUp() {
			base.SetUp();
			saveButton = new ButtonTester("ajax_content_saveButton");
			proof = new LabelTester("ajax_content_proof");
			Browser.GetPage(ControlTesterUtilities.GetUrlPath(typeof(UpdateLabel)));
		}
	}
}
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
			StringAssert.Contains(IdFor.It("updateLabel", "document.getElementById('{0}').style.display = 'inline';"), Browser.CurrentPageText);
		}

		protected override void SetUp() {
			base.SetUp();
			saveButton = new ButtonTester(IdFor.It("saveButton"));
			proof = new LabelTester(IdFor.It("proof"));
			Browser.GetPage(ControlTesterUtilities.GetUrlPath(typeof(UpdateLabel)));
		}
	}
}
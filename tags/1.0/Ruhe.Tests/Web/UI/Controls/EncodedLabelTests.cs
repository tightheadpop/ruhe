using NUnit.Extensions.Asp;
using NUnit.Extensions.Asp.AspTester;
using NUnit.Framework;
using Ruhe.TestExtensions;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Tests.Web.UI.Controls {
	[TestFixture]
	public class EncodedLabelTest : WebFormTestCase {
		private LabelTester encodedLabel;

		protected override void SetUp() {
			base.SetUp();
			string url = ControlTesterUtilities.GetUrlPath(typeof(EncodedLabel));
			Browser.GetPage(url);

			encodedLabel = new LabelTester("label", CurrentWebForm);
		}

		[Test]
		public void Encoding() {
			AssertVisibility(encodedLabel, true);
			AssertEquals("text was not HTML encoded", "test &amp; stuff", encodedLabel.Text);
		}
	}
}
using System.Web.UI.WebControls;
using NUnit.Extensions.Asp;
using NUnit.Extensions.Asp.AspTester;
using NUnit.Framework;
using Ruhe.TestExtensions;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Tests.Extensions {
	[TestFixture]
	public class ControlTesterUtilitiesTests : WebFormTestCase {
		[Test]
		public void GetUrlPathAccessesConfigFile() {
			AssertTrue(ControlTesterUtilities.GetUrlPath(typeof(EncodedLabel))
			           	.Equals("http://localhost/ruhe/Web/UI/Controls/EncodedLabelTests.aspx"));
		}

		[Test]
		public void HasChildElement() {
			Browser.GetPage(ControlTesterUtilities.GetUrlPath(typeof(Message)));
			PanelTester messageWrapper1 = new PanelTester("message1_wrapper", CurrentWebForm);
			AssertTrue(ControlTesterUtilities.HasChildElement(messageWrapper1, "message1_header"));
		}

		[Test]
		public void GetHtmlFromControl() {
			Label thing = new Label();
			thing.Text = "thing";
			string result = ControlTesterUtilities.GetHtml(thing);
			Assert.AreEqual("<span>thing</span>", result, "Html output does not match");
		}
	}
}
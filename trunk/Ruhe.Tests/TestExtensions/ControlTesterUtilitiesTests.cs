using System.Xml;
using NUnit.Extensions.Asp;
using NUnit.Extensions.Asp.AspTester;
using NUnit.Framework;
using Ruhe.TestExtensions;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Tests.Extensions {
	[TestFixture]
	public class ControlTesterUtilitiesTests : WebFormTestCase {
		[Test]
		public void GetUrlPathInNonWebContextAccessesConfigFile() {
			Assert(ControlTesterUtilities.GetUrlPath(typeof(EncodedLabel))
			       	.Equals("http://localhost/ruhe/Web/UI/Controls/EncodedLabelTests.aspx"));
		}

		[Test]
		public void GetXmlElement() {
			Browser.GetPage(ControlTesterUtilities.GetUrlPath(typeof(EncodedLabel)));
			LabelTester label = new LabelTester("label", CurrentWebForm);
			XmlElement labelElement = ControlTesterUtilities.GetXmlElement(label);
			AssertEquals("span", labelElement.Name);
		}

		[Test]
		public void HasChildElement() {
			Browser.GetPage(ControlTesterUtilities.GetUrlPath(typeof(Message)));
			PanelTester messageWrapper1 = new PanelTester("message1_wrapper", CurrentWebForm);
			Assert(ControlTesterUtilities.HasChildElement(messageWrapper1, "message1_header"));
		}

		[Test]
		public void GetUrlPathInWebContextAccessesHttpContextInstance() {
			
		}
	}
}
using System;
using NUnit.Extensions.Asp;
using NUnit.Extensions.Asp.AspTester;
using NUnit.Framework;
using Ruhe.TestExtensions;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Tests.Web.UI.Controls {
	[TestFixture]
	public class LinkButtonTests : WebFormTestCase {
		private string url;
		private LabelTester target;
		private ButtonTester button;
		private LinkButtonTester link;

		protected override void SetUp() {
			base.SetUp();
			url = ControlTesterUtilities.GetUrlPath(typeof(LinkButton));
			target = new LabelTester("target", CurrentWebForm);
			button = new ButtonTester("linkButton_button", CurrentWebForm);
			link = new LinkButtonTester("linkButton", CurrentWebForm);

			Browser.GetPage(url);
		}

		[Test]
		public void InitialState() {
			AssertVisibility(button, true);
			AssertVisibility(link, true);
			Assert.AreEqual("display:none;", new HtmlTagTester(link.AspId).Attribute("style"), "The hyperlink should be emitted with style that hides it");
			AssertEquals(String.Empty, target.Text);
		}

		[Test]
		public void ClickLink() {
			link.Click();
			AssertEquals("clicked", target.Text);
		}

		[Test]
		public void ClickButton() {
			button.Click();
			AssertEquals("clicked", target.Text);
		}
	}
}
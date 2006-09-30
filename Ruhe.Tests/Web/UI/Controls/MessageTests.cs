using NUnit.Extensions.Asp;
using NUnit.Extensions.Asp.AspTester;
using NUnit.Framework;
using Ruhe.TestExtensions;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Tests.Web.UI.Controls {
	[TestFixture]
	public class MessageTests : WebFormTestCase {
		protected PanelTester messageWrapper1;
		protected PanelTester messageHeader1;
		protected PanelTester messageBody1;
		protected LinkButtonTester dummyLink;
		protected ButtonTester addControl;
		protected LabelTester added;

		protected PanelTester messageWrapper2;
		protected PanelTester messageHeader2;
		protected PanelTester messageBody2;

		protected PanelTester messageWrapper3;
		protected PanelTester messageHeader3;
		protected PanelTester messageBody3;

		protected PanelTester messageWrapper4;
		protected PanelTester messageHeader4;
		protected PanelTester messageBody4;

		protected PanelTester messageWrapper5;
		protected PanelTester messageHeader5;
		protected PanelTester messageBody5;

		protected override void SetUp() {
			base.SetUp();
			messageWrapper1 = new PanelTester("message1_wrapper", CurrentWebForm);
			messageHeader1 = new PanelTester("message1_header", CurrentWebForm);
			messageBody1 = new PanelTester("message1", CurrentWebForm);
			dummyLink = new LinkButtonTester("message1_dummyLink", CurrentWebForm);
			addControl = new ButtonTester("addControl", CurrentWebForm);
			added = new LabelTester("message1_added", CurrentWebForm);

			messageWrapper2 = new PanelTester("message2_wrapper", CurrentWebForm);
			messageHeader2 = new PanelTester("message2_header", CurrentWebForm);
			messageBody2 = new PanelTester("message2", CurrentWebForm);

			messageWrapper3 = new PanelTester("message3_wrapper", CurrentWebForm);
			messageHeader3 = new PanelTester("message3_header", CurrentWebForm);
			messageBody3 = new PanelTester("message3", CurrentWebForm);

			messageWrapper4 = new PanelTester("message4_wrapper", CurrentWebForm);
			messageHeader4 = new PanelTester("message4_header", CurrentWebForm);
			messageBody4 = new PanelTester("message4", CurrentWebForm);

			messageWrapper5 = new PanelTester("message5_wrapper", CurrentWebForm);
			messageHeader5 = new PanelTester("message5_header", CurrentWebForm);
			messageBody5 = new PanelTester("message5", CurrentWebForm);

			Browser.GetPage(ControlTesterUtilities.GetUrlPath(typeof(Message)));
		}

		[Test]
		public void Visibility() {
			AssertVisibility(messageWrapper1, true);
			AssertVisibility(messageHeader1, true);
			AssertVisibility(messageBody1, true);
			AssertVisibility(dummyLink, true);
		}

		[Test]
		public void Containment() {
			Assert(ControlTesterUtilities.HasChildElement(messageWrapper1, "message1_header"));
			Assert(ControlTesterUtilities.HasChildElement(messageWrapper1, "message1"));
			Assert(ControlTesterUtilities.HasChildElement(messageBody1, "message1_dummyLink"));
		}

		[Test]
		public void AddControlDynamically() {
			addControl.Click();
			AssertVisibility(added, true);
			Assert("the added control must appear inside the message body",
			       ControlTesterUtilities.HasChildElement(messageBody1, "message1_added"));
		}

		[Test]
		public void NoBodyContent() {
			AssertVisibility(messageWrapper2, true);
			AssertVisibility(messageHeader2, true);
			AssertVisibility(messageBody2, false);
		}

		[Test]
		public void NoHeaderContent() {
			AssertVisibility(messageWrapper3, true);
			AssertVisibility(messageHeader3, false);
			AssertVisibility(messageBody3, true);
		}

		[Test]
		public void NoContent() {
			AssertVisibility(messageWrapper4, false);
			AssertVisibility(messageHeader4, false);
			AssertVisibility(messageBody4, false);
		}

		[Test]
		public void ClearedControlTree() {
			AssertVisibility(messageWrapper5, true);
			AssertVisibility(messageBody5, true);
			AssertVisibility(messageHeader5, true);
			Assert(ControlTesterUtilities.HasChildElement(messageBody5, "message5_replacement"));
		}
	}
}
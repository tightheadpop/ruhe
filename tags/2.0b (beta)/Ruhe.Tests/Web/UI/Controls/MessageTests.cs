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
		public void AllChildrenAreVisible() {
			WebAssert.Visible(messageWrapper1);
			WebAssert.Visible(messageHeader1);
			WebAssert.Visible(messageBody1);
			WebAssert.Visible(dummyLink);
		}

		[Test]
		public void Layout() {
			Assert.IsTrue(ControlTesterUtilities.HasChildElement(messageWrapper1, "message1_header"));
			Assert.IsTrue(ControlTesterUtilities.HasChildElement(messageWrapper1, "message1"));
			Assert.IsTrue(ControlTesterUtilities.HasChildElement(messageBody1, "message1_dummyLink"));
		}

		[Test]
		public void ControlAddedDynamicallyIsRenderedInTheBody() {
			addControl.Click();
			WebAssert.Visible(added);
			Assert.IsTrue(ControlTesterUtilities.HasChildElement(messageBody1, "message1_added"), "the added control must appear inside the message body");
		}

		[Test]
		public void BodyPanelIsNotDisplayedWhenThereIsNoBodyContent() {
			WebAssert.Visible(messageWrapper2);
			WebAssert.Visible(messageHeader2);
			WebAssert.NotVisible(messageBody2);
		}

		[Test]
		public void HeaderIsNotDisplayedWhenThereIsNoHeaderContent() {
			WebAssert.Visible(messageWrapper3);
			WebAssert.NotVisible(messageHeader3);
			WebAssert.Visible(messageBody3);
		}

		[Test]
		public void NoContent() {
			WebAssert.NotVisible(messageWrapper4);
			WebAssert.NotVisible(messageHeader4);
			WebAssert.NotVisible(messageBody4);
		}

		[Test]
		public void ClearedControlTree() {
			WebAssert.Visible(messageWrapper5);
			WebAssert.Visible(messageBody5);
			WebAssert.Visible(messageHeader5);
			Assert.IsTrue(ControlTesterUtilities.HasChildElement(messageBody5, "message5_replacement"));
		}
	}
}
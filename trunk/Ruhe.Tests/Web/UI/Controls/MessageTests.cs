using NUnit.Extensions.Asp;
using NUnit.Extensions.Asp.AspTester;
using NUnit.Framework;
using Ruhe.TestExtensions;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Tests.Web.UI.Controls {
    [TestFixture]
    public class MessageTests : RuheWebTest<Message> {
        protected ButtonTester addControl;
        protected LabelTester added;
        protected LinkButtonTester dummyLink;
        protected PanelTester messageBody1;
        protected PanelTester messageBody2;
        protected PanelTester messageBody3;
        protected PanelTester messageBody4;
        protected PanelTester messageBody5;
        protected PanelTester messageHeader1;
        protected PanelTester messageHeader2;
        protected PanelTester messageHeader3;
        protected PanelTester messageHeader4;
        protected PanelTester messageHeader5;
        protected PanelTester messageWrapper1;
        protected PanelTester messageWrapper2;
        protected PanelTester messageWrapper3;
        protected PanelTester messageWrapper4;
        protected PanelTester messageWrapper5;

        [Test]
        public void AllChildrenAreVisible() {
            WebAssert.Visible(messageWrapper1);
            WebAssert.Visible(messageHeader1);
            WebAssert.Visible(messageBody1);
            WebAssert.Visible(dummyLink);
        }

        [Test]
        public void BodyPanelIsNotDisplayedWhenThereIsNoBodyContent() {
            WebAssert.Visible(messageWrapper2);
            WebAssert.Visible(messageHeader2);
            WebAssert.NotVisible(messageBody2);
        }

        [Test]
        public void ClearedControlTree() {
            WebAssert.Visible(messageWrapper5);
            WebAssert.Visible(messageBody5);
            WebAssert.Visible(messageHeader5);
            Assert.IsTrue(messageBody5.HasChildElement(IdFor("message5_replacement")));
        }

        [Test]
        public void ControlAddedDynamicallyIsRenderedInTheBody() {
            addControl.Click();
            WebAssert.Visible(added);
            Assert.IsTrue(messageBody1.HasChildElement(IdFor("message1_added")), "the added control must appear inside the message body");
        }

        [Test]
        public void HeaderIsNotDisplayedWhenThereIsNoHeaderContent() {
            WebAssert.Visible(messageWrapper3);
            WebAssert.NotVisible(messageHeader3);
            WebAssert.Visible(messageBody3);
        }

        [Test]
        public void Layout() {
            Assert.IsTrue(messageWrapper1.HasChildElement(IdFor("message1_header")));
            Assert.IsTrue(messageWrapper1.HasChildElement(IdFor("message1")));
            Assert.IsTrue(messageBody1.HasChildElement(IdFor("message1_dummyLink")));
        }

        [Test]
        public void NoContent() {
            WebAssert.NotVisible(messageWrapper4);
            WebAssert.NotVisible(messageHeader4);
            WebAssert.NotVisible(messageBody4);
        }

        protected override void SetUp() {
            base.SetUp();
            messageWrapper1 = new PanelTester(IdFor("message1"));
            messageHeader1 = new PanelTester(IdFor("message1_header"));
            messageBody1 = new PanelTester(IdFor("message1_body"));
            dummyLink = new LinkButtonTester(IdFor("message1_dummyLink"));
            addControl = new ButtonTester(IdFor("addControl"));
            added = new LabelTester(IdFor("message1_added"));

            messageWrapper2 = new PanelTester(IdFor("message2"));
            messageHeader2 = new PanelTester(IdFor("message2_header"));
            messageBody2 = new PanelTester(IdFor("message2_body"));

            messageWrapper3 = new PanelTester(IdFor("message3"));
            messageHeader3 = new PanelTester(IdFor("message3_header"));
            messageBody3 = new PanelTester(IdFor("message3_body"));

            messageWrapper4 = new PanelTester(IdFor("message4"));
            messageHeader4 = new PanelTester(IdFor("message4_header"));
            messageBody4 = new PanelTester(IdFor("message4_body"));

            messageWrapper5 = new PanelTester(IdFor("message5"));
            messageHeader5 = new PanelTester(IdFor("message5_header"));
            messageBody5 = new PanelTester(IdFor("message5_body"));

            LoadPage();
        }
    }
}
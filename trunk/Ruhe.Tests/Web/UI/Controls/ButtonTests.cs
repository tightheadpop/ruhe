using NUnit.Extensions.Asp;
using NUnit.Extensions.Asp.AspTester;
using NUnit.Framework;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Tests.Web.UI.Controls {
    [TestFixture]
    public class ButtonTests : RuheWebTest<Button> {
        private HtmlTagTester button1;
        private HtmlTagTester button2;
        private LabelTester result;
        private ButtonTester clickableButton1;
        private ButtonTester clickableButton2;

        protected override void SetUp() {
            base.SetUp();
            LoadPage();
            button1 = new HtmlTagTester(Tests.IdFor.Format("button1", ".//button[@id='{0}']"), "button1 tag");
            button2 = new HtmlTagTester(Tests.IdFor.Format("button2", ".//button[@id='{0}']"), "button2 tag");
            result = new LabelTester(IdFor("result"));
            clickableButton1 = new ButtonTester(IdFor("button1"));
            clickableButton2 = new ButtonTester(IdFor("button2"));
        }

        [Test]
        public void EmitsAsButtonTagRatherThanInput() {
            WebAssert.Visible(button1);
        }

        [Test]
        public void AddsImageToButtonWhenImageUrlIsSet() {
            HtmlTagTester[] images = button1.ChildrenByXPath("./img");
            Assert.Greater(images.Length, 0);
            HtmlTagTester image = images[0];
            Assert.AreEqual("../../../images/foo.gif", image.Attribute("src"), "should translate ~ to relative application path");
        }

        [Test]
        public void RendersTextWithAccessKey() {
            Assert.AreEqual("s", button1.Attribute("accesskey"));
            StringAssert.Contains("<span style=\"text-decoration:underline;\">S</span>ubmit", button1.InnerHtml);
        }

        [Test]
        public void RendersTextWithoutAccessKey() {
            Assert.IsFalse(button2.HasAttribute("accesskey"));
            Assert.AreEqual("Click Here", button2.InnerHtml);
        }

        [Test]
        public void ButtonClickEventIsNotRaisedIfButtonCausesValidationAndPageIsNotValid() {
            clickableButton1.Click();
            Assert.IsEmpty(result.Text);
        }

        [Test]
        public void ButtonClickEventIsRaisedIfButtonDoesNotCauseValidation() {
            clickableButton2.Click();
            Assert.IsNotEmpty(result.Text);
        }
    }
}
using System;
using NUnit.Extensions.Asp;
using NUnit.Extensions.Asp.AspTester;
using NUnit.Framework;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Tests.Web.UI.Controls {
    [TestFixture]
    public class LinkButtonTests : RuheWebTest<LinkButton> {
        private ButtonTester button;
        private LinkButtonTester link;
        private LabelTester target;

        [Test]
        public void ClickButton() {
            button.Click();
            AssertEquals("clicked", target.Text);
        }

        [Test]
        public void ClickLink() {
            link.Click();
            AssertEquals("clicked", target.Text);
        }

        [Test]
        public void InitialState() {
            AssertVisibility(button, true);
            AssertVisibility(link, true);
            Assert.AreEqual("display:none;", new HtmlTagTester(link.AspId).Attribute("style"), "The hyperlink should be emitted with style that hides it");
            AssertEquals(String.Empty, target.Text);
        }

        protected override void SetUp() {
            base.SetUp();
            target = new LabelTester(IdFor("target"));
            button = new ButtonTester(IdFor("linkButton_button"));
            link = new LinkButtonTester(IdFor("linkButton"));

            LoadPage();
        }
    }
}
using System.Web.UI.WebControls;
using NUnit.Extensions.Asp.AspTester;
using NUnit.Framework;
using Ruhe.TestExtensions;
using Ruhe.Tests.Web.UI.Controls;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Tests.TestExtensions {
    [TestFixture]
    public class ControlTesterUtilitiesTests : RuheWebTest<ControlTesterUtilitiesTests> {
        [Test]
        public void GetHtmlFromControl() {
            Label thing = new Label();
            thing.Text = "thing";
            string result = thing.GetHtml();
            Assert.AreEqual("<span>thing</span>", result, "Html output does not match");
        }

        [Test]
        public void GetUrlPathAccessesConfigFile() {
            AssertTrue(GetUrlPath<EncodedLabel>()
                           .EndsWith("/Web/UI/Controls/EncodedLabelTests.aspx"));
        }

        [Test]
        public void HasChildElement() {
            Browser.GetPage(GetUrlPath<Message>());
            PanelTester messageWrapper1 = new PanelTester(IdFor("message1"));
            AssertTrue(messageWrapper1.HasChildElement(IdFor("message1_header")));
        }
    }
}
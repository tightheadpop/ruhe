using NUnit.Extensions.Asp.HtmlTester;
using NUnit.Framework;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Tests.Web.UI.Controls {
    [TestFixture]
    public class HyperLinkFieldTests : RuheWebTest<HyperLinkField> {
        [Test]
        public void HyperLinkField() {
            LoadPage();
            var hyperLinkField = new HtmlAnchorTester("//a[1]", "the first link on the page, which is the hyperlinkfield");
            StringAssert.EndsWith("HyperLinkField.aspx?Id=1", hyperLinkField.HRef);
            Assert.AreEqual("1", hyperLinkField.InnerHtml);
        }
    }
}
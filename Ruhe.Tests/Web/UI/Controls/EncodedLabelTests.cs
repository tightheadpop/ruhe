using NUnit.Framework;
using Ruhe.TestExtensions;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Tests.Web.UI.Controls {
    [TestFixture]
    public class EncodedLabelTest {
        [Test]
        public void HtmlEncodesText() {
            var label = new EncodedLabel("test & stuff");
            var html = label.GetHtml();
            Assert.IsTrue(html.Contains("test &amp; stuff"));
        }
    }
}
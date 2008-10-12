using NUnit.Framework;
using Ruhe.TestExtensions;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Tests.Web.UI.Controls {
    [TestFixture]
    public class EncodedLabelTest {
        [Test]
        public void HtmlEncodesText() {
            EncodedLabel label = new EncodedLabel("test & stuff");
            string html = ControlTesterUtilities.GetHtml(label);
            Assert.IsTrue(html.Contains("test &amp; stuff"));
        }
    }
}
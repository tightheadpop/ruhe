using NUnit.Framework;
using Ruhe.TestExtensions;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Tests.Web.UI.Controls {
    [TestFixture]
    public class AllLiteralControlTests {
        [Test]
        public void BreakingSpace() {
            string result = new BreakingSpace().GetHtml();
            Assert.AreEqual(" ", result);
        }

        [Test]
        public void LineBreak() {
            string result = new LineBreak().GetHtml();
            Assert.AreEqual("<br />", result);
        }

        [Test]
        public void NonBreakingSpaceDefaultRender() {
            string result = new NonBreakingSpace().GetHtml();
            Assert.AreEqual("&nbsp;", result);
        }

        [Test]
        public void NonBreakingSpaceNRepeats() {
            int n = 3;
            string result = new NonBreakingSpace(n).GetHtml();
            Assert.AreEqual("&nbsp;&nbsp;&nbsp;", result);
        }
    }
}
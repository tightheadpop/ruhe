using LiquidSyntax.ForWeb;
using NUnit.Framework;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Tests.Web.UI.Controls {
    [TestFixture]
    public class AllLiteralControlTests {
        [Test]
        public void BreakingSpace() {
            var result = new BreakingSpace().GetHtml();
            Assert.AreEqual(" ", result);
        }

        [Test]
        public void LineBreak() {
            var result = new LineBreak().GetHtml();
            Assert.AreEqual("<br />", result);
        }

        [Test]
        public void NonBreakingSpaceDefaultRender() {
            var result = new NonBreakingSpace().GetHtml();
            Assert.AreEqual("&nbsp;", result);
        }

        [Test]
        public void NonBreakingSpaceNRepeats() {
            var n = 3;
            var result = new NonBreakingSpace(n).GetHtml();
            Assert.AreEqual("&nbsp;&nbsp;&nbsp;", result);
        }
    }
}
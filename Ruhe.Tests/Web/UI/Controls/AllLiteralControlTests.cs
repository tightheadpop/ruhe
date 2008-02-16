using NUnit.Framework;
using Ruhe.TestExtensions;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Tests.Web.UI.Controls {
    [TestFixture]
    public class AllLiteralControlTests {
        [Test]
        public void BreakingSpace() {
            string result = ControlTesterUtilities.GetHtml(new BreakingSpace());
            Assert.AreEqual(" ", result);
        }

        [Test]
        public void LineBreak() {
            string result = ControlTesterUtilities.GetHtml(new LineBreak());
            Assert.AreEqual("<br />", result);
        }

        [Test]
        public void NonBreakingSpaceDefaultRender() {
            string result = ControlTesterUtilities.GetHtml(new NonBreakingSpace());
            Assert.AreEqual("&nbsp;", result);
        }

        [Test]
        public void NonBreakingSpaceNRepeats() {
            int n = 3;
            string result = ControlTesterUtilities.GetHtml(new NonBreakingSpace(n));
            Assert.AreEqual("&nbsp;&nbsp;&nbsp;", result);
        }
    }
}
using NUnit.Framework;
using Ruhe.Web.UI;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Tests.Web.UI.Controls {
	[TestFixture]
	public class AllLiteralControlTests {
		[Test]
		public void NonBreakingSpaceDefaultRender() {
			string result = ControlUtilities.GetHtml(new NonBreakingSpace());
			Assert.AreEqual("&nbsp;", result);
		}

		[Test]
		public void NonBreakingSpaceNRepeats() {
			int n = 3;
			string result = ControlUtilities.GetHtml(new NonBreakingSpace(n));
			Assert.AreEqual("&nbsp;&nbsp;&nbsp;", result);
		}

		[Test]
		public void LineBreak() {
			string result = ControlUtilities.GetHtml(new LineBreak());
			Assert.AreEqual("<br />", result);
		}

		[Test]
		public void BreakingSpace() {
			string result = ControlUtilities.GetHtml(new BreakingSpace());
			Assert.AreEqual(" ", result);
		}
	}
}
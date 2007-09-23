using NUnit.Framework;
using Ruhe.Web;

namespace Ruhe.Tests.Web {
	[TestFixture]
	public class FileStreamerTests {
		[Test]
		public void GetContentType() {
			Assert.AreEqual("application/pdf", FileStreamer.GetContentType(@"c:\system.pdf"));
			Assert.AreEqual("image/tiff", FileStreamer.GetContentType(@"c:\system.tif"));
			Assert.AreEqual("text/plain", FileStreamer.GetContentType(@"c:\system.something"));
		}
	}
}
using System.Web.UI;
using NUnit.Framework;
using Ruhe.Web;

[assembly : WebResource("Ruhe.Tests.Resources.ResourceLoaderTarget.txt", "text/plain")]

namespace Ruhe.Tests.Web {
    [TestFixture]
    public class WebResourceLoaderTests {
        [Test]
        public void GetWebResource() {
            var resource = WebResourceLoader.GetResource(GetType(), "ResourceLoaderTarget.txt");
            Assert.AreEqual("Ruhe.Tests.Resources.ResourceLoaderTarget.txt", resource.WebResource);
            Assert.AreEqual("text/plain", resource.ContentType);
        }

        [Test]
        public void GetWebResourceNameParsesAssemblyAttributesToFindTheFullName() {
            var actual = WebResourceLoader.GetFullName(GetType(), "ResourceLoaderTarget.txt");
            Assert.AreEqual("Ruhe.Tests.Resources.ResourceLoaderTarget.txt", actual);
        }
    }
}
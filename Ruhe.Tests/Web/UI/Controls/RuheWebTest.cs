using System.Text.RegularExpressions;
using NUnit.Extensions.Asp;
using NUnit.Framework;
using Ruhe.Common;
using Ruhe.Common.Utilities;
using Ruhe.TestExtensions;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Tests.Web.UI.Controls {
    public class RuheWebTest<T> : WebFormTestCase {
        private AspNetDevelopmentServer server;

        [TestFixtureSetUp]
        public virtual void TestFixtureSetUp() {
            //launches at http://localhost:4269/Ruhe.TestWeb
            server = new AspNetDevelopmentServer(4269, TestWebPath, "Ruhe.TestWeb");
        }

        ~RuheWebTest() {
            Disposer.DisposeOf(server);
        }

        private string TestWebPath {
            get {
                string executingPath = StringUtilities.RemovePrefix(GetType().Assembly.CodeBase, "file:///");
                return Regex.Replace(executingPath, string.Format("/{0}/.*", GetType().Assembly.GetName().Name), "/Ruhe.TestWeb").Replace('/', '\\');
            }
        }

        protected static string GetUrlPath<R>() {
            string subPath = StringUtilities.RemovePrefix(typeof(R).FullName, @"\w+\.").Replace(".", "/");
            return string.Format("{0}{1}Tests.aspx", "http://localhost:4269/Ruhe.TestWeb/", subPath);
        }

        protected void LoadPage() {
            Browser.GetPage(GetUrlPath<T>());
        }

        protected void LoadPage(string option) {
            Browser.GetPage(string.Format("{0}?{1}=on", GetUrlPath<T>(), option));
        }
    }
}
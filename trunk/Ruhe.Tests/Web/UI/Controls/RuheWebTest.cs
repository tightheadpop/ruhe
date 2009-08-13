using System.Text.RegularExpressions;
using LiquidSyntax;
using NUnit.Framework;
using Ruhe.Web;

namespace Ruhe.Tests.Web.UI.Controls {
    public class RuheWebTest<T> : WebFormTestCase {
        protected const string GlobalDatePattern = "dd-MMM-yyyy";
        protected const string TestUrl = "http://localhost:4269/Ruhe.TestWeb/";

        protected virtual string GetUrlPath<R>() {
            var subPath = typeof(R).FullName.WithoutPrefixPattern(@"\w+\.").Replace(".", "/");
            return string.Format("{0}{1}Tests.aspx", TestUrl, subPath);
        }

        protected static string IdFor(string partialId) {
            return Tests.IdFor.It(partialId);
        }

        protected virtual void LoadPage() {
            Browser.GetPage(GetUrlPath<T>());
        }

        protected void LoadOtherPage(string pageName) {
            Browser.GetPage(Regex.Replace(GetUrlPath<T>(), "(.*/).*", "$1") + pageName);
        }

        protected virtual void LoadPageWithOption(string option) {
            Browser.GetPage(string.Format("{0}?{1}=on", GetUrlPath<T>(), option));
        }

        protected virtual void LoadPageWithSuffix(string suffix) {
            Browser.GetPage(GetUrlPath<T>().Replace("Tests.aspx", suffix + ".aspx"));
        }

        [TestFixtureSetUp]
        public virtual void TestFixtureSetUp() {
            //launches at http://localhost:4269/Ruhe.TestWeb
            var server = new AspNetDevelopmentServer(4269, TestWebPath, "Ruhe.TestWeb");
            server.DisposeOnAppDomainUnload();
            server.Start();
        }

        private string TestWebPath {
            get {
                var executingPath = GetType().Assembly.CodeBase.WithoutPrefixPattern("file:///");
                return Regex.Replace(executingPath, string.Format("/{0}/.*", GetType().Assembly.GetName().Name), "/Ruhe.TestWeb").Replace('/', '\\');
            }
        }
    }
}
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using LiquidSyntax;
using NUnit.Framework;
using Ruhe.Web;
using WatiN.Core;
using LiquidSyntax.ForTesting;
using WatiN.Core.Native;

namespace Ruhe.Tests.Web {
    public class WatinTest<T> {
        public const string TestUrl = "http://localhost:4269/Ruhe.TestWeb/";

        protected IE Browser { get; private set; }

        /// <summary>
        /// Navigates to a specific .aspx file in a folder matching the namespace of T
        /// </summary>
        protected void NavigateTo(string aspxName) {
            Browser.DisposeQuietly();
            Browser = new IE(GetBaseUrl() + aspxName);
        }

        private string GetBaseUrl() {
            var subPath = typeof(T).Namespace.WithoutPrefixPattern(@"\w+\.").Replace(".", "/");
            return string.Format("{0}{1}/", TestUrl, subPath);
        }

        [TearDown]
        public void TearDown() {
            Browser.DisposeQuietly();
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
                var executingPath = GetType().Assembly.CodeBase.WithoutPrefix("file:///");
                return Regex.Replace(executingPath, String.Format("/{0}/.*", GetType().Assembly.GetName().Name), "/Ruhe.TestWeb").Replace('/', '\\');
            }
        }

        protected void TypeTextWithEvents(Element textField, string value) {
            Browser.BringToFront();
            textField.Focus();
            SendKeys.SendWait(value);
        }
    }
}
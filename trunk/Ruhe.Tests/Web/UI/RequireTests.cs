using System;
using System.Text.RegularExpressions;
using NUnit.Framework;
using Ruhe.Tests.Web.UI.Controls;
using Ruhe.Web.UI;

namespace Ruhe.Tests.Web.UI {
    [TestFixture]
    public class RequireTests : RuheWebTest<Require> {
        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RequireDoesNotWorkInWithoutWebContext() {
            Require.DefaultStyleSheet(GetType(), "doesn't matter");
        }

        [Test]
        public void IncludesStyleSheetBeforeOthers() {
            LoadPage();
            StringAssert.Contains("</title><link", Browser.CurrentPageText);
            StringAssert.Contains("rel=\"stylesheet\"", Browser.CurrentPageText);
            StringAssert.Contains("type=\"text/css\"", Browser.CurrentPageText);
        }

        [Test]
        public void OnlyIncludesSameStyleSheetOnce() {
            LoadPage();
            Assert.IsFalse(Regex.IsMatch(Browser.CurrentPageText, "<link.*<link"));
        }

    }
}
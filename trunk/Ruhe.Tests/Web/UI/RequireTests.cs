using System;
using System.Text.RegularExpressions;
using NUnit.Framework;
using Ruhe.Web.UI;
using LiquidSyntax.ForTesting;

namespace Ruhe.Tests.Web.UI {
    [TestFixture]
    public class RequireTests : WatinTest<Require> {
        [Test]
        [Ignore("watin does not support full HTML access")]
        public void IncludesStyleSheetAfterTitle() {
            NavigateTo("RequireTests.aspx");
            StringAssert.Contains("</title><link", Browser.Html);
            StringAssert.Contains("rel=\"stylesheet\"", Browser.Html);
            StringAssert.Contains("type=\"text/css\"", Browser.Html);
        }

        [Test]
        public void OnlyIncludesSameStyleSheetOnce() {
            NavigateTo("RequireTests.aspx");
            Assert.IsFalse(Regex.IsMatch(Browser.Html, "<link.*<link"));
        }

        [Test]
        public void RequireDoesNotWorkInWithoutWebContext() {
            try {
                Require.StyleSheet(GetType(), "doesn't matter");
                Assert.Fail();
            }
            catch (InvalidOperationException) {}
        }

        [Test]
        public void ShouldFailIfTitleIsNotFirstElementInHead() {
            NavigateTo("RequireFailsIfMissingTitleTest.aspx");
            Browser.Expect<ArgumentException>();
        }

        [Test]
        public void ShouldIncludeJQuery() {
            NavigateTo("JQueryIncludeTests.aspx");
            Browser.Span("text").Text.Should(Be.EqualTo("updated!"));
        }
    }
}
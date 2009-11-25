using System.Threading;
using LiquidSyntax.ForTesting;
using WatiN.Core;
using LiquidSyntax;

namespace Ruhe.Tests.Web {
    public static class WatinExtensions {
        public static void Expect<TException>(this Browser browser) {
            browser.Text.Should(Contain.Text(typeof(TException).Name));
        }

        public static void ShouldBeVisible(this Element element) {
            element.Exists.Should(Be.True);
        }

        public static void ShouldNotBeVisible(this Element element) {
            element.Exists.Should(Be.False);
        }

        public static void ClickAndWait(this Button button) {
            button.Click();
            Thread.Sleep(500.Milliseconds());
        }
    }
}
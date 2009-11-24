using LiquidSyntax.ForTesting;
using WatiN.Core;

namespace Ruhe.Tests.Web {
    public static class WatinExtensions {
        public static void Expect<TException>(this Browser browser) {
            browser.Text.Should(Contain.Text(typeof(TException).Name));
        }
    }
}
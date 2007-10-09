using NUnit.Extensions.Asp;
using NUnit.Framework;
using Ruhe.TestExtensions;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Tests.Web.UI.Controls {
    [TestFixture]
    public class RadioButtonListTests : WebFormTestCase {
        [Test]
        public void EmitsOnClickScriptForUseInConjunctionWithUpdatePanel() {
            Browser.GetPage(ControlTesterUtilities.GetUrlPath(typeof(RadioButtonList)));

            Assert.IsTrue(Browser.CurrentPageText.Contains(IdFor.It("postBackList", "document.getElementById('{0}_1').onclick =")), "a postback radio button list should have script that makes it work with an update panel");
            Assert.IsFalse(Browser.CurrentPageText.Contains(IdFor.It("nonPostBackList", "document.getElementById('{0}_0').onclick =")), "a non-postback radio button list doesn't need the script");
        }
    }
}
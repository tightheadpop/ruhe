using NUnit.Framework;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Tests.Web.UI.Controls {
    [TestFixture]
    public class BoundFieldTests : RuheWebTest<BoundField> {
        [Test]
        public void UsesOgnlNavigationOnBoundItem() {
            LoadPage();
            StringAssert.Contains("hi, mom!".Length.ToString(), Browser.CurrentPageText);
        }
    }
}
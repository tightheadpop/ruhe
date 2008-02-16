using NUnit.Framework;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Tests.Web.UI.Controls {
    [TestFixture]
    public class BoundFieldTests : RuheWebTest<BoundField> {
        [Test]
        public void DateBoundFieldAppliesConfiguredDateFormat() {
            LoadPage();
            StringAssert.Contains("09-Feb-2009", Browser.CurrentPageText);
        }

        [Test]
        public void DateBoundFieldAppliesUserFormatIfProvided() {
            LoadPage();
            StringAssert.Contains("from 9/17/1983", Browser.CurrentPageText);
        }

        [Test]
        public void UsesOgnlNavigationOnBoundItem() {
            LoadPage();
            StringAssert.Contains("hi, mom!".Length.ToString(), Browser.CurrentPageText);
        }
    }
}
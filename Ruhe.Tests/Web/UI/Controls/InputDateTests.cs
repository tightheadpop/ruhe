using NUnit.Extensions.Asp;
using NUnit.Framework;
using Ruhe.TestExtensions;
using Ruhe.Tests.TestExtensions.HtmlTesters;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Tests.Web.UI.Controls {
    [TestFixture]
    public class InputDateTests : WebFormTestCase {
        private HtmlImageTester calendar;
        private HtmlTagTester dateBox;

        protected override void SetUp() {
            base.SetUp();
            Browser.GetPage(ControlTesterUtilities.GetUrlPath(typeof(InputDate)));
            calendar = new HtmlImageTester(IdFor.It("date_calendar"));
            dateBox = new HtmlTagTester(IdFor.It("date"));
        }

        [Test]
        public void HasCalendarImage() {
            WebAssert.Visible(calendar);
        }

        [Test]
        public void TextBoxIsReadOnlyUntilIWorkOutValidation() {
            Assert.AreEqual("readonly", dateBox.Attribute("readonly"));
        }
    }
}
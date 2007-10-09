using System;
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

        private void LoadPage() {
            Browser.GetPage(ControlTesterUtilities.GetUrlPath(typeof(InputDate)));
            calendar = new HtmlImageTester(IdFor.It("date_calendar"));
            dateBox = new HtmlTagTester(IdFor.It("date"));
        }

        [Test]
        public void HasCalendarImage() {
            LoadPage();
            WebAssert.Visible(calendar);
        }

        [Test]
        public void TextBoxIsReadOnlyUntilIWorkOutValidation() {
            LoadPage();
            Assert.AreEqual("readonly", dateBox.Attribute("readonly"));
        }

        [Test]
        public void DefaultValueIsNull() {
            InputDate input = new InputDate();
            input.Text = string.Empty;
            Assert.IsNull(input.Value);
        }

        [Test]
        public void NonNullValueCanBeConvertedToDateTime() {
            InputDate input = new InputDate();
            DateTime expected = new DateTime(2002, 10, 21);
            input.Value = expected;
            Assert.AreEqual("10/21/2002", input.Text);
            Assert.AreEqual(expected, input.Value);
        }

        [Test]
        public void DefaultingValueToTodaySetsValue() {
            InputDate input = new InputDate();
            input.DefaultToToday = true;
            Assert.AreEqual(DateTime.Today, input.Value);
        }

        [Test]
        public void DefaultToTodayOnlySetsValueIfOneIsNotAlreadySet() {
            InputDate input = new InputDate();
            DateTime expected = new DateTime(2000, 1, 1);
            input.Value = expected;
            input.DefaultToToday = true;
            Assert.AreEqual(expected, input.Value);
        }
    }
}
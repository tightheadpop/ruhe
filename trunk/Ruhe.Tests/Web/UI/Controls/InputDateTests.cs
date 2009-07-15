using System;
using NUnit.Extensions.Asp;
using NUnit.Framework;
using Ruhe.Tests.TestExtensions.HtmlTesters;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Tests.Web.UI.Controls {
    [TestFixture]
    public class InputDateTests : RuheWebTest<InputDate> {
        private HtmlImageTester calendar;
        private HtmlImageTester readonlyCalendar;
        private HtmlTagTester readonlyDateValidator;

        [Test]
        public void DefaultingValueToTodaySetsValue() {
            var input = new InputDate();
            input.DefaultToToday = true;
            Assert.AreEqual(DateTime.Today, input.Value);
        }

        [Test]
        public void DefaultToTodayOnlySetsValueIfOneIsNotAlreadySet() {
            var input = new InputDate();
            var expected = new DateTime(2000, 1, 1);
            input.Value = expected;
            input.DefaultToToday = true;
            Assert.AreEqual(expected, input.Value);
        }

        [Test]
        public void DefaultValueIsNull() {
            var input = new InputDate();
            input.Text = string.Empty;
            Assert.IsNull(input.Value);
        }

        [Test]
        public void DoesNotEmitValidatorWhenReadOnly() {
            LoadTestPage();
            WebAssert.NotVisible(readonlyDateValidator);
        }

        [Test]
        public void DoesNotHaveCalendarImageWhenReadOnly() {
            LoadTestPage();
            WebAssert.NotVisible(readonlyCalendar);
        }

        [Test]
        public void EmitsKeystrokeFilterScript() {
            LoadTestPage();
            Assert.IsTrue(Browser.CurrentPageText.Contains("Ruhe$DATE"));
        }

        [Test]
        public void HasCalendarImage() {
            LoadTestPage();
            WebAssert.Visible(calendar);
        }

        [Test]
        public void NonNullValueCanBeConvertedToDateTime() {
            var input = new InputDate();
            input.Format = "MM/dd/yyyy";
            var expected = new DateTime(2002, 10, 21);
            input.Value = expected;
            Assert.AreEqual("10/21/2002", input.Text);
            Assert.AreEqual(expected, input.Value);
        }

        [Test]
        public void ParsesInvalidToNull() {
            var input = new InputDate();
            input.Format = "MM/dd/yyyy";
            input.Text = "21/10/2002";
            Assert.IsNull(input.Value);
        }

        [Test]
        public void ParsesValidInputToDateTime() {
            var input = new InputDate();
            input.Format = "MM/dd/yyyy";
            input.Text = "10/21/2002";
            Assert.AreEqual(new DateTime(2002, 10, 21), input.Value);
        }

        [Test]
        public void SettingDatePatternOverridesDefaultForThisInstance() {
            var newFormat = "dd-MMM-yyyy";
            var input = new InputDate();
            Assert.AreNotEqual(newFormat, input.Format);
            input.Format = newFormat;
            Assert.AreEqual(newFormat, input.Format);
        }

        [Test]
        public void ValidatorIsPresent() {
            LoadTestPage();
            StringAssert.Contains("date_dateValidator", Browser.CurrentPageText);
        }

        private void LoadTestPage() {
            LoadPage();
            calendar = new HtmlImageTester(IdFor("date_calendar"));
            readonlyCalendar = new HtmlImageTester(IdFor("readOnly_calendar"));
            readonlyDateValidator = new HtmlTagTester(IdFor("readOnly_dateValidator"));
        }
    }
}
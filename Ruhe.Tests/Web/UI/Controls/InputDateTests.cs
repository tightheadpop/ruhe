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

        [Test]
        public void DefaultValueIsNull() {
            InputDate input = new InputDate();
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
            InputDate input = new InputDate();
            input.Format = "MM/dd/yyyy";
            DateTime expected = new DateTime(2002, 10, 21);
            input.Value = expected;
            Assert.AreEqual("10/21/2002", input.Text);
            Assert.AreEqual(expected, input.Value);
        }

        [Test]
        public void ParsesInvalidToNull() {
            InputDate input = new InputDate();
            input.Format = "MM/dd/yyyy";
            input.Text = "21/10/2002";
            Assert.IsNull(input.Value);
        }

        [Test]
        public void ParsesValidInputToDateTime() {
            InputDate input = new InputDate();
            input.Format = "MM/dd/yyyy";
            input.Text = "10/21/2002";
            Assert.AreEqual(new DateTime(2002, 10, 21), input.Value);
        }

        [Test]
        public void SettingDatePatternOverridesDefaultForThisInstance() {
            string newFormat = "dd-MMM-yyyy";
            InputDate input = new InputDate();
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
using System;
using NUnit.Framework;
using Ruhe.Web.UI.Controls;
using WatiN.Core;

namespace Ruhe.Tests.Web.UI.Controls {
    [TestFixture]
    public class InputDateTests : WatinTest<InputDate> {
        [Test]
        public void DefaultingValueToTodaySetsValue() {
            var input = new InputDate {DefaultToToday = true};
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
            var input = new InputDate {Text = string.Empty};
            Assert.IsNull(input.Value);
        }

        [Test]
        public void DoesNotEmitTextBoxOrValidatorWhenReadOnly() {
            LoadTestPage();
            ReadOnlyDate.ShouldNotBeVisible();
            ReadOnlyDateValidator.ShouldNotBeVisible();
        }

        [Test]
        public void DoesNotHaveCalendarImageWhenReadOnly() {
            LoadTestPage();
            ReadOnlyDateImage.ShouldNotBeVisible();
        }

        [Test]
        public void HasCalendarImage() {
            LoadTestPage();
            InputDateImage.ShouldBeVisible();
        }

        [Test]
        public void NonNullValueCanBeConvertedToDateTime() {
            var input = new InputDate {Format = "MM/dd/yyyy"};
            var expected = new DateTime(2002, 10, 21);
            input.Value = expected;
            Assert.AreEqual("10/21/2002", input.Text);
            Assert.AreEqual(expected, input.Value);
        }

        [Test]
        public void ParsesInvalidToNull() {
            var input = new InputDate {Format = "MM/dd/yyyy", Text = "21/10/2002"};
            Assert.IsNull(input.Value);
        }

        [Test]
        public void ParsesValidInputToDateTime() {
            var input = new InputDate {Format = "MM/dd/yyyy", Text = "10/21/2002"};
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
        public void ValidatesInvalideDataType() {
            LoadTestPage();
            InputDate.TypeText("this is not a date");
            SubmitButton.ClickAndWait();
            InputDateValidator.ShouldBeVisible();
        }

        private void LoadTestPage() {
            NavigateTo("InputDateTests.aspx");
        }

        private TextField InputDate {
            get { return Browser.TextField(IdFor.It("date")); }
        }

        private Image InputDateImage {
            get { return Browser.Image(IdFor.It("date_calendar")); }
        }

        private Span InputDateValidator {
            get { return Browser.Span(IdFor.It("date_dateValidator")); }
        }

        private TextField ReadOnlyDate {
            get { return Browser.TextField(IdFor.It("readOnly")); }
        }

        private Image ReadOnlyDateImage {
            get { return Browser.Image(IdFor.It("readOnly_calendar")); }
        }

        private Span ReadOnlyDateValidator {
            get { return Browser.Span(IdFor.It("readOnly_dateValidator")); }
        }

        private WatiN.Core.Button SubmitButton {
            get { return Browser.Button(IdFor.It("submitButton")); }
        }
    }
}
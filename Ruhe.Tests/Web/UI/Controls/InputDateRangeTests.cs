using System;
using System.Linq;
using System.Web.UI.WebControls;
using LiquidSyntax;
using LiquidSyntax.ForWeb;
using NUnit.Extensions.Asp;
using NUnit.Extensions.Asp.AspTester;
using NUnit.Framework;
using Ruhe.Web.UI.Controls;
using LiquidSyntax.ForTesting;

namespace Ruhe.Tests.Web.UI.Controls {
    [TestFixture]
    public class InputDateRangeTests : RuheWebTest<InputDateRange> {
        private TextBoxTester from;
        private ValidatorTester inputRangeValidator;
        private LabelTester inputReadOnlyLabel;
        private LabelTester inputRequiredLabel;
        private ValidatorTester inputRequiredValidator;

        private TextBoxTester readOnlyFrom;
        private LabelTester readOnlyLabel;
        private LabelTester readOnlyRequiredLabel;
        private TextBoxTester readOnlyTo;

        private ButtonTester submit;
        private TextBoxTester to;

        [Test]
        public void GetAndSetDateRangeValue() {
            var input = new InputDateRange();
            var oneWeek = new DateRange(DateTime.Today, DateTime.Today.AddDays(7));
            input.DateRange = oneWeek;

            Assert.AreEqual(oneWeek, input.DateRange);
        }

        [Test]
        public void InitialValueIsNull() {
            Assert.IsNull(new InputDateRange().DateRange);
        }

        [Test]
        public void ShouldHaveTwoInputDateControls() {
            new InputDateRange().FindAll<InputDate>().Count().Should(Be.EqualTo(2));
        }

        [Test]
        public void SettingWidthActsOnChildInputDateControls() {
            var range = new InputDateRange();
            var expected = Unit.Parse("8em");
            range.Width = expected;
            range.FindAll<InputDate>().ForEach(o => o.Width.Should(Be.EqualTo(expected)));
        }

        [Test]
        public void StartOccursAfterEnd() {
            LoadPage();
            from.Text = "01-Jan-2004";
            to.Text = "31-Dec-2003";
            WebAssert.NotVisible(inputRangeValidator);
            submit.Click();
            WebAssert.Visible(inputRangeValidator);
        }

        [Test]
        public void WhenReadOnly() {
            LoadPage();
            WebAssert.NotVisible(readOnlyFrom);
            WebAssert.NotVisible(readOnlyTo);
            WebAssert.NotVisible(readOnlyRequiredLabel);
            WebAssert.Visible(readOnlyLabel);
            var expected = new DateRange(DateTime.Today, DateTime.Today.AddDays(3));
            Assert.AreEqual(expected.ToString("M/d/yyyy"), readOnlyLabel.Text);
        }

        [Test]
        public void WhenRequired() {
            LoadPage();
            WebAssert.Visible(from);
            WebAssert.Visible(to);
            WebAssert.NotVisible(inputReadOnlyLabel);
            WebAssert.Visible(inputRequiredLabel);

            WebAssert.NotVisible(inputRequiredValidator);
            submit.Click();
            WebAssert.Visible(inputRequiredValidator);
        }

        protected override void SetUp() {
            base.SetUp();
            from = new TextBoxTester(IdFor("input_from"));
            to = new TextBoxTester(IdFor("input_to"));
            inputReadOnlyLabel = new LabelTester(IdFor("input_readOnly"));
            inputRequiredLabel = new LabelTester(IdFor("input_requiredLabel"));
            inputRequiredValidator = new ValidatorTester(IdFor("input_groupValidator"));
            inputRangeValidator = new ValidatorTester(IdFor("input_rangeValidator"));

            readOnlyFrom = new TextBoxTester(IdFor("readOnlyInput_from"));
            readOnlyTo = new TextBoxTester(IdFor("readOnlyInput_to"));
            readOnlyLabel = new LabelTester(IdFor("readOnlyInput_readOnly"));
            readOnlyRequiredLabel = new LabelTester(IdFor("readOnlyInput_requiredLabel"));

            submit = new ButtonTester(IdFor("submit"));
        }
    }
}
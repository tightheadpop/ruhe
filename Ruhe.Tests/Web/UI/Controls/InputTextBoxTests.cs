using System;
using NUnit.Extensions.Asp;
using NUnit.Extensions.Asp.AspTester;
using NUnit.Framework;
using Ruhe.Tests.TestExtensions.HtmlTesters;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Tests.Web.UI.Controls {
    [TestFixture]
    public class InputTextBoxTests : RuheWebTest<InputTextBox> {
        private TextBoxTester testBox;
        private TextBoxTester aspxRequired;
        private ButtonTester submitButton;
        private ValidationSummaryTester summary;
        private LabelTester readOnly;
        private LabelTester resultLabel;
        private HtmlImageTester requiredImage;

        protected override void SetUp() {
            base.SetUp();
            testBox = new TextBoxTester(IdFor.It("testBox"));
            aspxRequired = new TextBoxTester(IdFor.It("aspxRequired"));
            submitButton = new ButtonTester(IdFor.It("submitButton"));
            summary = new ValidationSummaryTester(IdFor.It("summary"));
            readOnly = new LabelTester(IdFor.It("testBox_readOnly"));
            resultLabel = new LabelTester(IdFor.It("result"));
            requiredImage = new HtmlImageTester(IdFor.It("testBox_requiredLabel"));
        }

        [Test]
        public void RequiredIndicatorDoesNotAppearWhenFieldIsNotRequired() {
            LoadPage();
            WebAssert.NotVisible(requiredImage);
        }

        [Test]
        public void RequiredIndicatorAppearsWhenFieldIsRequired() {
            LoadPage("Required");
            WebAssert.Visible(requiredImage);
        }

        [Test]
        public void InvalidFieldStopsProcessingOfClickEventHandler() {
            LoadPage("Required");
            submitButton.Click();
            Assert.AreEqual(String.Empty, resultLabel.Text, "click handler was executed after failed validation");
        }

        [Test]
        public void NoRegexValidationIsAppliedIfTheValidationExpressionPropertyIsNotSet() {
            LoadPage();
            testBox.Text = "12";
            submitButton.Click();
            Console.Write(Browser.CurrentPageText);
            Assert.AreEqual(string.Empty, new HtmlTagTester(summary.AspId).InnerHtml.Trim());
        }

        [Test]
        public void RegexValidation() {
            // expression in page = \d{3}
            string[] badValues = new string[] {"12", "1234", "a123", "abc"};

            LoadPage("Regex");

            foreach (string badValue in badValues) {
                testBox.Text = badValue;
                submitButton.Click();
                AssertTrue(summary.Messages[0].Length > 0);
            }

            testBox.Text = "123";
            submitButton.Click();
            Assert.AreEqual(string.Empty, new HtmlTagTester(summary.AspId).InnerHtml.Trim());
        }

        [Test]
        public void NotReadOnly() {
            LoadPage();
            WebAssert.Visible(testBox);
            WebAssert.NotVisible(readOnly);
        }

        [Test]
        public void ReadOnly() {
            LoadPage("ReadOnly");
            WebAssert.NotVisible(testBox);
            WebAssert.Visible(readOnly);
        }

        [Test]
        public void ControlCollection() {
            InputTextBox box = new InputTextBox();
            AssertTrue(box.Controls[0] != null);
        }

        [Test]
        public void MarkerIsVisibleWhenRequiredIsSetInAspxFile() {
            LoadPage("AspxRequired");
            AssertVisibility(aspxRequired, true);
            AssertVisibility(testBox, false);

            submitButton.Click();
            AssertTrue(summary.Messages.Length == 1);
        }
    }
}
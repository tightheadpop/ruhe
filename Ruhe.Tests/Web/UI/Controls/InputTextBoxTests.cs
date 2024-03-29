using System;
using NUnit.Extensions.Asp;
using NUnit.Extensions.Asp.AspTester;
using NUnit.Framework;
using Ruhe.Tests.TestExtensions.HtmlTesters;
using Ruhe.Web.UI.Controls;
using LiquidSyntax.ForTesting;
using System.Linq;

namespace Ruhe.Tests.Web.UI.Controls {
    [TestFixture]
    public class InputTextBoxTests : RuheWebTest<InputTextBox> {
        private TextBoxTester aspxRequired;
        private LabelTester readOnly;
        private HtmlImageTester requiredImage;
        private LabelTester resultLabel;
        private ButtonTester submitButton;
        private ValidationSummaryTester summary;
        private TextBoxTester testBox;

        [Test]
        public void ControlCollection() {
            var box = new InputTextBox();
            AssertTrue(box.Controls[0] != null);
        }

        [Test]
        public void InvalidFieldStopsProcessingOfClickEventHandler() {
            LoadPageWithOption("Required");
            submitButton.Click();
            Assert.AreEqual(String.Empty, resultLabel.Text, "click handler was executed after failed validation");
        }

        [Test]
        public void MarkerIsVisibleWhenRequiredIsSetInAspxFile() {
            LoadPageWithOption("AspxRequired");
            AssertVisibility(aspxRequired, true);
            AssertVisibility(testBox, false);

            submitButton.Click();
            AssertTrue(summary.Messages.Length == 1);
        }

        [Test]
        public void NoRegexValidationIsAppliedIfTheValidationExpressionPropertyIsNotSet() {
            LoadPage();
            testBox.Text = "12";
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
            LoadPageWithOption("ReadOnly");
            WebAssert.NotVisible(testBox);
            WebAssert.Visible(readOnly);
        }

        [Test]
        public void RegexValidation() {
            // expression in page = \d{3}
            var badValues = new[] {"12", "1234", "a123", "abc"};

            LoadPageWithOption("Regex");

            foreach (var badValue in badValues) {
                testBox.Text = badValue;
                submitButton.Click();
                AssertTrue(summary.Messages[0].Length > 0);
            }

            testBox.Text = "123";
            submitButton.Click();
            Assert.AreEqual(string.Empty, new HtmlTagTester(summary.AspId).InnerHtml.Trim());
        }

        [Test]
        public void RequiredIndicatorAppearsWhenFieldIsRequired() {
            LoadPageWithOption("Required");
            WebAssert.Visible(requiredImage);
        }

        [Test]
        public void RequiredIndicatorDoesNotAppearWhenFieldIsNotRequired() {
            LoadPage();
            WebAssert.NotVisible(requiredImage);
        }

        [Test]
        public void ShouldAddParsedEmbeddedValidatorToChildControls() {
            LoadPageWithSuffix("EmbeddedValidator");
            submitButton.Click();
            summary.Messages.First().Should(Be.EqualTo("you're wrong."));
        }

        protected override void SetUp() {
            base.SetUp();
            testBox = new TextBoxTester(IdFor("testBox"));
            aspxRequired = new TextBoxTester(IdFor("aspxRequired"));
            submitButton = new ButtonTester(IdFor("submitButton"));
            summary = new ValidationSummaryTester(IdFor("summary"));
            readOnly = new LabelTester(IdFor("testBox_readOnly"));
            resultLabel = new LabelTester(IdFor("result"));
            requiredImage = new HtmlImageTester(IdFor("testBox_requiredLabel"));
        }
    }
}
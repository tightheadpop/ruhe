//using NUnit.Extensions.Asp;
//using NUnit.Extensions.Asp.AspTester;
//using NUnit.Framework;
//using Ruhe.TestExtensions;
//using Ruhe.Web.UI.Controls;
//
//namespace Ruhe.Tests.Web.UI.Controls {
//    [TestFixture]
//    public class ValidationSummaryTests : WebFormTestCase {
//        private ValidationSummaryTester summary;
//        private ButtonTester submitButton;
//
//        private void LoadPage() {
//            Browser.GetPage(ControlTesterUtilities.GetUrlPath(typeof(InputTextBox)) + "?Required=on");
//            summary = new ValidationSummaryTester(IdFor("summary"));
//            submitButton = new ButtonTester(IdFor("submitButton"));
//        }
//
//        [Test]
//        public void ErrorMessagesAreFormattedProperly() {
//            LoadPage();
//            submitButton.Click();
//
//            string errorMessage = summary.Messages[0];
//            StringAssert.Contains("in the testBox field.", errorMessage, "the field's label text should be used in completing the validation message that appears in the summary");
//            StringAssert.StartsWith("<a ", errorMessage, "The error message should start with a link");
//            StringAssert.Contains("you're wrong", errorMessage, "The error message should include the original error message");
//        }
//
//        [Test]
//        public void GeneratedValidationSummaryJavaScriptUsesCorrectClientId() {
//            LoadPage();
//            StringAssert.Contains(IdFor("testBox", "document.getElementById(&quot;{0}&quot;).focus();"), Browser.CurrentPageText);
//        }
//
//    }
//}

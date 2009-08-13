using NUnit.Framework;
using Ruhe.Web.UI.Controls;
using WatiN.Core;
using LiquidSyntax;
using LiquidSyntax.ForTesting;

namespace Ruhe.Tests.Web.UI.Controls {
    [TestFixture]
    public class InputTextBoxMultiLineMaxLengthTests : RuheWebTest<InputTextBox> {
        [Test]
        [Ignore("Watin does not manipulate keystrokes in a manner that triggers behavior script")]
        public void ShouldLimitUserInputWhenMaxLengthIsSpecifiedOnTextArea() {
            using (var ie = new IE(GetUrlPath<InputTextBox>().Replace("InputTextBoxTests", "InputTextBoxMultiLineMaxLength"))) {
                var textField = ie.TextField(IdFor("limitedInput"));
                textField.AppendText(11.Times("a"));
                textField.Text.Should(Be.EqualTo(10.Times("a")));
            }
        }

        [Test]
        public void ShouldAtLeastHaveTheMaxlengthAndStyleAttributes() {
            using (var ie = new IE(GetUrlPath<InputTextBox>().Replace("InputTextBoxTests", "InputTextBoxMultiLineMaxLength"))) {
                var textField = ie.TextField(IdFor("limitedInput"));
                textField.GetAttributeValue("maxlength").Should(Be.EqualTo("10"));
                textField.Style.GetAttributeValue("behavior").ShouldNot(Be.Null);
            }
        }
    }
}
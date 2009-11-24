using LiquidSyntax;
using LiquidSyntax.ForTesting;
using NUnit.Framework;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Tests.Web.UI.Controls {
    [TestFixture]
    public class InputTextBoxMultiLineMaxLengthTests : WatinTest<InputTextBox> {
        [Test]
        public void ShouldLimitUserInputWhenMaxLengthIsSpecifiedOnTextArea() {
            NavigateTo("InputTextBoxMultiLineMaxLength.aspx");
            var textField = Browser.TextField(IdFor.It("limitedInput"));
            TypeTextWithEvents(textField, 11.Times("a"));
            textField.Text.Should(Be.EqualTo(10.Times("a")));
        }

        [Test]
        public void ShouldAtLeastHaveTheMaxlengthAndStyleAttributes() {
            NavigateTo("InputTextBoxMultiLineMaxLength.aspx");
            var textField = Browser.TextField(IdFor.It("limitedInput"));
            textField.GetAttributeValue("maxlength").Should(Be.EqualTo("10"));
            textField.Style.GetAttributeValue("behavior").ShouldNot(Be.Null);
        }
    }
}
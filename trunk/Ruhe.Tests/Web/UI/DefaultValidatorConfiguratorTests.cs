using System.Linq;
using System.Web.UI.WebControls;
using LiquidSyntax.ForWeb;
using NUnit.Framework;
using Ruhe.Web.UI;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Tests.Web.UI {
    [TestFixture]
    public class DefaultValidatorConfiguratorTests : WebFormTestCase {
        [Test]
        public void RequiredValidatorHasRequiredIcon() {
            var inputTextBox = new InputTextBox {ID = "foo", LabelText = "Field Name", ErrorMessage = "you're wrong"};
            new DefaultValidatorConfigurator().ConfigureControl(inputTextBox);
            Assert.AreEqual(1, inputTextBox.FindAll<RequiredIcon>().Count());
        }

        [Test]
        public void SetsValidationGroupOnAllChildValidators() {
            var inputTextBox = new InputTextBox {ValidationGroup = "myGroup"};
            new DefaultValidatorConfigurator().ConfigureControl(inputTextBox);

            foreach (var validator in inputTextBox.FindAll<BaseValidator>()) {
                Assert.AreEqual("myGroup", validator.ValidationGroup);
            }
        }
    }
}
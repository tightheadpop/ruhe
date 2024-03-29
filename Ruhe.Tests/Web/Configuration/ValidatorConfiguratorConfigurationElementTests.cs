using System.Web.UI.WebControls;
using NUnit.Framework;
using Ruhe.Configuration;
using Ruhe.Web.UI;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Tests.Web.Configuration {
    [TestFixture]
    public class ValidatorConfiguratorConfigurationElementTests {
        [Test]
        public void DefaultsToDefaultValidatorConfigurator() {
            Assert.AreEqual(typeof(DefaultValidatorConfigurator).FullName, new ValidatorConfiguratorConfigurationElement().Type);
        }

        [Test]
        public void YieldsNewlyChosenType() {
            var element = new ValidatorConfiguratorConfigurationElement();
            element.Type = typeof(TestValidatorConfigurator).FullName;
            Assert.AreEqual(typeof(TestValidatorConfigurator).FullName, element.Type);
        }

        private class TestValidatorConfigurator : IValidatorConfigurator {
            public void ConfigureControl(IInputControl inputControl) {}
            public void ConfigureValidator(BaseValidator validator, IInputControl control) {}
        }
    }
}
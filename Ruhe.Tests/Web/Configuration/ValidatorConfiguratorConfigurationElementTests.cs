using NUnit.Framework;
using Ruhe.Web.Configuration;
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
            ValidatorConfiguratorConfigurationElement element = new ValidatorConfiguratorConfigurationElement();
            element.Type = typeof(TestValidatorConfigurator).FullName;
            Assert.AreEqual(typeof(TestValidatorConfigurator).FullName, element.Type);
        }

        private class TestValidatorConfigurator : IValidatorConfigurator {
            public void Configure(IInputControl inputControl) {}
        }
    }
}
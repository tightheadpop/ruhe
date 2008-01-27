using System.Configuration;
using NUnit.Framework;
using Ruhe.Web.Configuration;
using Ruhe.Web.UI;

namespace Ruhe.Tests.Web.Configuration {
    [TestFixture]
    public class ValidatorConfiguratorFactoryTests {
        [Test]
        public void CreatesDefaultConfiguratorWhenNoConfigurationIsPresent() {
            Assert.IsInstanceOfType(typeof(DefaultValidatorConfigurator), ValidatorConfiguratorFactory.Create());
        }

//        [Test]
//        public void UsesConfiguredValidatorConfigurator() {
//            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
//            RuheConfigurationSection section = new RuheConfigurationSection();
//            section.ValidatorConfiguratorElement.Type = typeof(TestConfigurator);
//            config.Sections.Add("ruhe", section);
//            config.Save(ConfigurationSaveMode.Full);
//
//            Assert.IsInstanceOfType(typeof(TestConfigurator), ValidatorConfiguratorFactory.Create());
//        }

        [SetUp]
        [TearDown]
        public void TearDown() {
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.Sections.Remove("ruhe");
            config.Save(ConfigurationSaveMode.Full);
        }

//        private class TestConfigurator : IValidatorConfigurator {
//            public void ConfigureControl(IInputControl inputControl) {
//                throw new System.NotImplementedException();
//            }
//
//            public void ConfigureValidator(BaseValidator validator, IInputControl control) {
//                throw new System.NotImplementedException();
//            }
//        }
    }
}
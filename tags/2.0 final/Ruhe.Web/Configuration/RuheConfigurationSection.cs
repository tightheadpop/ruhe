using System.Configuration;

namespace Ruhe.Web.Configuration {
    public class RuheConfigurationSection : ConfigurationSection {
        private static readonly ConfigurationProperty configuratorElement =
            new ConfigurationProperty(
                "validatorConfigurator",
                typeof(ValidatorConfiguratorConfigurationElement));

        [ConfigurationProperty("validatorConfigurator")]
        public ValidatorConfiguratorConfigurationElement ValidatorConfiguratorElement {
            get { return (ValidatorConfiguratorConfigurationElement)base[configuratorElement]; }
        }
    }
}
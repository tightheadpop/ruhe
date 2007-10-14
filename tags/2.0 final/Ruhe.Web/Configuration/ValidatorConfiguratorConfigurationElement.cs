using System.Configuration;
using Ruhe.Web.UI;

namespace Ruhe.Web.Configuration {
    public class ValidatorConfiguratorConfigurationElement : ConfigurationElement {
        private static readonly ConfigurationProperty type =
            new ConfigurationProperty(
                "type",
                typeof(string),
                typeof(DefaultValidatorConfigurator).FullName,
                ConfigurationPropertyOptions.None);

        [ConfigurationProperty("type")]
        public string Type {
            get { return (string) base[type]; }
            set { base[type] = value; }
        }
    }
}
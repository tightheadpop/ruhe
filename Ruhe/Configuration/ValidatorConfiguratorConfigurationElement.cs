using System.Configuration;
using Ruhe.Utilities;
using Ruhe.Web.UI;

namespace Ruhe.Configuration {
    public class ValidatorConfiguratorConfigurationElement : ConfigurationElement {
        [ConfigurationProperty("type")]
        public string Type {
            get { return ((string) base["type"]).TrimToNull() ?? typeof(DefaultValidatorConfigurator).FullName; }
            set { base["type"] = value; }
        }
    }
}
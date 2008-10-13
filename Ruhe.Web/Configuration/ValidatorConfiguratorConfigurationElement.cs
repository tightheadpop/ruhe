using System.Configuration;
using Ruhe.Common.Utilities;
using Ruhe.Web.UI;

namespace Ruhe.Web.Configuration {
    public class ValidatorConfiguratorConfigurationElement : ConfigurationElement {
        [ConfigurationProperty("type")]
        public string Type {
            get { return ((string) base["type"]).TrimToNull() ?? typeof(DefaultValidatorConfigurator).FullName; }
            set { base["type"] = value; }
        }
    }
}
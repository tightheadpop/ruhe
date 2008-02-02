using System.Configuration;

namespace Ruhe.Web.Configuration {
    public class RuheConfigurationSection : ConfigurationSection {
        [ConfigurationProperty("validatorConfigurator")]
        public ValidatorConfiguratorConfigurationElement ValidatorConfiguratorElement {
            get { return (ValidatorConfiguratorConfigurationElement)base["validatorConfigurator"]; }
        }

        [ConfigurationProperty("dateFormat")]
        public DateFormatConfigurationElement DateFormat {
            get { return (DateFormatConfigurationElement)base["dateFormat"]; }
        }

        [ConfigurationProperty("images")]
        public ImageUrlConfigurationCollection Images {
            get { return (ImageUrlConfigurationCollection)base["images"]; }
        }

        public static RuheConfigurationSection GetCurrent() {
            return (RuheConfigurationSection) (ConfigurationManager.GetSection("ruhe") ?? new RuheConfigurationSection());
        }
    }
}
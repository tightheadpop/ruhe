using System.Configuration;

namespace Ruhe.Configuration {
    public class RuheConfigurationSection : ConfigurationSection {
        [ConfigurationProperty("dateFormat")]
        public DateFormatConfigurationElement DateFormat {
            get { return (DateFormatConfigurationElement) base["dateFormat"]; }
        }

        [ConfigurationProperty("images")]
        public ImageUrlConfigurationCollection Images {
            get { return (ImageUrlConfigurationCollection) base["images"]; }
        }

        [ConfigurationProperty("validatorConfigurator")]
        public ValidatorConfiguratorConfigurationElement ValidatorConfiguratorElement {
            get { return (ValidatorConfiguratorConfigurationElement) base["validatorConfigurator"]; }
        }

        [ConfigurationProperty("developmentServer")]
        public DevelopmentServerConfigurationElement DevelopmentServer {
            get { return (DevelopmentServerConfigurationElement)base["developmentServer"]; }
        }

        public static RuheConfigurationSection GetCurrent() {
            return (RuheConfigurationSection) (ConfigurationManager.GetSection("ruhe") ?? new RuheConfigurationSection());
        }
    }
}
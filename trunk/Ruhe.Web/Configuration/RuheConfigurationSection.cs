using System.Configuration;

namespace Ruhe.Web.Configuration {
    public class RuheConfigurationSection : ConfigurationSection {
        private static readonly ConfigurationProperty configuratorElement =
            new ConfigurationProperty(
                "validatorConfigurator",
                typeof(ValidatorConfiguratorConfigurationElement));

        private static readonly ConfigurationProperty dateFormatElement =
            new ConfigurationProperty(
                "dateFormat",
                typeof(DateFormatConfigurationElement));

        private static readonly ConfigurationProperty imagesElement =
            new ConfigurationProperty(
                "images",
                typeof(ImageUrlConfigurationCollection));

        [ConfigurationProperty("validatorConfigurator")]
        public ValidatorConfiguratorConfigurationElement ValidatorConfiguratorElement {
            get { return (ValidatorConfiguratorConfigurationElement) base[configuratorElement]; }
        }

        [ConfigurationProperty("dateFormat")]
        public DateFormatConfigurationElement DateFormat {
            get { return (DateFormatConfigurationElement) base[dateFormatElement]; }
        }

        [ConfigurationProperty("images")]
        public ImageUrlConfigurationCollection Images {
            get { return (ImageUrlConfigurationCollection)base[imagesElement]; }
        }

        public static RuheConfigurationSection GetCurrent() {
            return (RuheConfigurationSection) (ConfigurationManager.GetSection("ruhe") ?? new RuheConfigurationSection());
        }
    }
}
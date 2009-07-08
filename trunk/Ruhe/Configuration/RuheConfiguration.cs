using System;
using Ruhe.Web;
using Ruhe.Web.UI;

namespace Ruhe.Configuration {
    public class RuheConfiguration {
        public static string DateFormat {
            get { return RuheConfigurationSection.GetCurrent().DateFormat.Value; }
        }

        public static string DateFormatText {
            get { return RuheConfigurationSection.GetCurrent().DateFormat.FormatText; }
        }

        public static IValidatorConfigurator ValidatorConfigurator {
            get {
                var section = RuheConfigurationSection.GetCurrent();
                return (IValidatorConfigurator) Activator.CreateInstance(Type.GetType(section.ValidatorConfiguratorElement.Type));
            }
        }

        public static string ImageUrlFor<T>(string defaultResourceName) {
            var imageConfig = RuheConfigurationSection.GetCurrent().Images[typeof(T).Name];
            if (imageConfig == null)
                return WebResourceLoader.GetResourceUrl(typeof(T), defaultResourceName);
            return imageConfig.Url;
        }
    }
}
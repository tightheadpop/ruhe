using System;
using Ruhe.Web.UI;

namespace Ruhe.Web.Configuration {
    public class RuheConfiguration {
        public static IValidatorConfigurator ValidatorConfigurator {
            get {
                RuheConfigurationSection section = RuheConfigurationSection.GetCurrent();
                return (IValidatorConfigurator)Activator.CreateInstance(Type.GetType(section.ValidatorConfiguratorElement.Type));
            }
        }

        public static string DateFormat {
            get { return RuheConfigurationSection.GetCurrent().DateFormat.Value; }
        }

        public static string ImageUrlFor<T>() {
            ImageUrlElement imageConfig = RuheConfigurationSection.GetCurrent().Images[typeof(T).Name];
            return imageConfig == null ? null : imageConfig.Url;
        }
    }
}
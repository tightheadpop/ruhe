using System;
using Ruhe.Web;
using Ruhe.Web.Resources;
using Ruhe.Web.UI;
using System.Linq;

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

        public static string DevelopmentServerPath {
            get { return RuheConfigurationSection.GetCurrent().DevelopmentServer.Path ?? @"C:\Program Files\Common Files\Microsoft Shared\DevServer\9.0\WebDev.WebServer.EXE"; }
        }

        public static string ImageUrlFor<T>() {
            var defaultResourceNameAttribute = (DefaultImageResourceAttribute)typeof(T).GetCustomAttributes(typeof(DefaultImageResourceAttribute), true).FirstOrDefault();
            defaultResourceNameAttribute.MustNotBeNull(typeof(T).Name + " must have a declared default image resource.");

            var defaultResourceName = defaultResourceNameAttribute.ResourceFileName;
            var imageConfig = RuheConfigurationSection.GetCurrent().Images[typeof(T).Name];
            if (imageConfig == null)
                return WebResourceLoader.GetResourceUrl(typeof(T), defaultResourceName);
            return imageConfig.Url;
        }
    }
}
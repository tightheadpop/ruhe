using System.Configuration;
using System.Threading;

namespace Ruhe.Web.Configuration {
    public class DateFormatConfigurationElement : ConfigurationElement {
        private static readonly ConfigurationProperty formatValue =
            new ConfigurationProperty(
                "value",
                typeof(string),
                null,
                ConfigurationPropertyOptions.None);

        [ConfigurationProperty("value")]
        public string Value {
            get {
                string configuredFormat = (string)base[formatValue];
                if (string.IsNullOrEmpty(configuredFormat))
                    return Thread.CurrentThread.CurrentUICulture.DateTimeFormat.ShortDatePattern;
                return configuredFormat;
            }
            set { base[formatValue] = value; }
        }
    }
}
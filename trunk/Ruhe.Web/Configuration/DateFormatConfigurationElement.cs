using System.Configuration;
using System.Threading;

namespace Ruhe.Web.Configuration {
    public class DateFormatConfigurationElement : ConfigurationElement {
        [ConfigurationProperty("formatText")]
        public string FormatText {
            get { return (string) this["formatText"]; }
            set { this["formatText"] = value; }
        }

        [ConfigurationProperty("value")]
        public string Value {
            get {
                string configuredFormat = (string) base["value"];
                if (string.IsNullOrEmpty(configuredFormat))
                    return Thread.CurrentThread.CurrentUICulture.DateTimeFormat.ShortDatePattern;
                return configuredFormat;
            }
            set { base["value"] = value; }
        }
    }
}
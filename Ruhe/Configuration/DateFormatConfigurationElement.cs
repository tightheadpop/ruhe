using System.Configuration;
using System.Threading;
using LiquidSyntax;

namespace Ruhe.Configuration {
    public class DateFormatConfigurationElement : ConfigurationElement {
        [ConfigurationProperty("formatText")]
        public string FormatText {
            get { return (string) this["formatText"]; }
            set { this["formatText"] = value; }
        }

        [ConfigurationProperty("value")]
        public string Value {
            get {
                var configuredFormat = (string) base["value"];
                if (configuredFormat.IsEmpty())
                    return Thread.CurrentThread.CurrentUICulture.DateTimeFormat.ShortDatePattern;
                return configuredFormat;
            }
            set { base["value"] = value; }
        }
    }
}
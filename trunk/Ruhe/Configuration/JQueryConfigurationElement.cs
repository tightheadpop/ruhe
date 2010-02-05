using System.Configuration;

namespace Ruhe.Configuration {
    public class JQueryConfigurationElement : ConfigurationElement {
        [ConfigurationProperty("jQuery-script-path")]
        public string JQueryScriptPath {
            get { return (string)this["jQuery-script-path"]; }
            set { this["jQuery-script-path"] = value; }
        }
    }
}
using System.Configuration;
using LiquidSyntax;

namespace Ruhe.Configuration {
    public class DevelopmentServerConfigurationElement : ConfigurationElement {
        [ConfigurationProperty("path")]
        public string Path {
            get { return ((string)base["path"]).TrimToNull(); }
            set { base["path"] = value; }
        }
    }
}
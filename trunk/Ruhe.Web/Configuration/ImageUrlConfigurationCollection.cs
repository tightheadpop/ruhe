using System.Configuration;

namespace Ruhe.Web.Configuration {
    public class ImageUrlConfigurationCollection : ConfigurationElementCollection {
        protected override ConfigurationElement CreateNewElement() {
            return new ImageUrlElement();
        }

        protected override object GetElementKey(ConfigurationElement element) {
            return ((ImageUrlElement) element).Control;
        }

        public new ImageUrlElement this[string controlTypeName] {
            get { return (ImageUrlElement) BaseGet(controlTypeName); }
        }

        public override ConfigurationElementCollectionType CollectionType {
            get { return ConfigurationElementCollectionType.AddRemoveClearMap; }
        }

        public class ImageUrlElement : ConfigurationElement {
            [ConfigurationProperty("control", IsRequired = true)]
            public string Control {
                get { return this["control"] as string; }
            }

            [ConfigurationProperty("url", IsRequired = true)]
            public string Url {
                get { return this["url"] as string; }
            }
        }
    }
}
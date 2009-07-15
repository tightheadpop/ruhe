using System.Configuration;

namespace Ruhe.Configuration {
    public class ImageUrlConfigurationCollection : ConfigurationElementCollection {
        public override ConfigurationElementCollectionType CollectionType {
            get { return ConfigurationElementCollectionType.AddRemoveClearMap; }
        }

        public new ImageUrlElement this[string controlTypeName] {
            get { return (ImageUrlElement) BaseGet(controlTypeName); }
        }

        protected override ConfigurationElement CreateNewElement() {
            return new ImageUrlElement();
        }

        protected override object GetElementKey(ConfigurationElement element) {
            return ((ImageUrlElement) element).Control;
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
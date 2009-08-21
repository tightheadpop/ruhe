using System;

namespace Ruhe.Web.Resources {
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class DefaultImageResourceAttribute : Attribute {
        public DefaultImageResourceAttribute(string resourceFileName) {
            ResourceFileName = resourceFileName;
        }

        public string ResourceFileName { get; private set; }
    }
}
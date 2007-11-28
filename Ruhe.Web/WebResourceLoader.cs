using System;
using System.Web.UI;
using Ruhe.Common.Utilities;

namespace Ruhe.Web {
    public class WebResourceLoader {
        public static string GetFullName(Type typeInAssemblyWithResource, string partialName) {
            WebResourceAttribute resource = GetResource(typeInAssemblyWithResource, partialName);
            return resource.WebResource;
        }

        public static WebResourceAttribute GetResource(Type typeInAssemblyWithResource, string partialName) {
            object[] attributes = typeInAssemblyWithResource.Assembly.GetCustomAttributes(typeof(WebResourceAttribute), true);
            return Collections.First<WebResourceAttribute>(
                attributes,
                delegate(WebResourceAttribute a) { return a.WebResource.EndsWith(partialName); }
                );
        }
    }
}
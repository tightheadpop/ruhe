using System;
using System.Web;
using System.Web.UI;
using Ruhe.Utilities;

namespace Ruhe.Web {
    public class WebResourceLoader {
        public static string GetFullName(Type typeInAssemblyWithResource, string partialName) {
            WebResourceAttribute resource = GetResource(typeInAssemblyWithResource, partialName);
            return resource.WebResource;
        }

        private static Page GetPage() {
            HttpContext context = HttpContext.Current;
            if (context == null || !(context.Handler is Page))
                throw new InvalidOperationException(typeof(WebResourceLoader).Name + " can only be used in the context of a Page.");
            return (Page) context.Handler;
        }

        public static WebResourceAttribute GetResource(Type typeInAssemblyWithResource, string partialName) {
            object[] attributes = typeInAssemblyWithResource.Assembly.GetCustomAttributes(typeof(WebResourceAttribute), true);
            return attributes.First(delegate(WebResourceAttribute a) { return a.WebResource.EndsWith(partialName); });
        }

        public static string GetResourceUrl(Type typeInAssemblyWithResource, string partialName) {
            Page page = GetPage();
            return page.ClientScript.GetWebResourceUrl(typeInAssemblyWithResource, GetResource(typeInAssemblyWithResource, partialName).WebResource);
        }
    }
}
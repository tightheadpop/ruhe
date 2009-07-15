using System;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Ruhe.Web {
    public class WebResourceLoader {
        public static string GetFullName(Type typeInAssemblyWithResource, string partialName) {
            var resource = GetResource(typeInAssemblyWithResource, partialName);
            return resource.WebResource;
        }

        private static Page GetPage() {
            var context = HttpContext.Current;
            if (context == null || !(context.Handler is Page))
                throw new InvalidOperationException(typeof(WebResourceLoader).Name + " can only be used in the context of a Page.");
            return (Page) context.Handler;
        }

        public static WebResourceAttribute GetResource(Type typeInAssemblyWithResource, string partialName) {
            var attributes = typeInAssemblyWithResource.Assembly.GetCustomAttributes(typeof(WebResourceAttribute), true);
            return (WebResourceAttribute) attributes.First(attribute => ((WebResourceAttribute) attribute).WebResource.EndsWith(partialName));
        }

        public static string GetResourceUrl(Type typeInAssemblyWithResource, string partialName) {
            var page = GetPage();
            return page.ClientScript.GetWebResourceUrl(typeInAssemblyWithResource, GetResource(typeInAssemblyWithResource, partialName).WebResource);
        }
    }
}
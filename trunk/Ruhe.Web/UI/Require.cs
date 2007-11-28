using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using Ruhe.Common;

namespace Ruhe.Web.UI {
    public class Require {
        public static void DefaultStyleSheet(Type type, string name) {
            IHttpHandler handler = Context.Handler;
            if (handler is Page) {
                Page page = (Page) handler;
                string registrationKey = "stylesheet" + name;

                if (!page.ClientScript.IsStartupScriptRegistered(type, registrationKey)) {
                    page.ClientScript.RegisterStartupScript(type, registrationKey, string.Empty);

                    HtmlLink stylesheetLink = new HtmlLink();
                    WebResourceAttribute resource = WebResourceLoader.GetResource(type, name);
                    stylesheetLink.Attributes["href"] = page.ClientScript.GetWebResourceUrl(type, resource.WebResource);
                    stylesheetLink.Attributes["rel"] = "stylesheet";
                    stylesheetLink.Attributes["type"] = resource.ContentType;

                    foreach (Control control in page.Header.Controls) {
                        if (Reflector.IsA<HtmlTitle>(control)) {
                            page.Header.Controls.AddAt(page.Header.Controls.IndexOf(control) + 1, stylesheetLink);
                            return;
                        }
                    }
                }
            }
        }

        private static HttpContext Context {
            get {
                HttpContext context = HttpContext.Current;
                if (context == null)
                    throw new InvalidOperationException("Web context is required");
                return context;
            }
        }
    }
}
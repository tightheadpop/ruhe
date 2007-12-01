using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using Ruhe.Common;

namespace Ruhe.Web.UI {
    public class Require {
        public static void DefaultStyleSheet(Type type, string name) {
            string registrationKey = "stylesheet-" + name;
            Page page = GetPage();
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

        private static Page GetPage() {
            HttpContext context = HttpContext.Current;
            if (context == null || !Reflector.IsA<Page>(context.Handler))
                throw new InvalidOperationException(typeof(Require).Name + " can only be used in the context of a Page.");
            return (Page) context.Handler;
        }
    }
}
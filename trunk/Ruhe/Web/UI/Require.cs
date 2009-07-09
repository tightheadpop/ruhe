using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace Ruhe.Web.UI {
    public class Require {
        public static void DefaultStyleSheet(Type type, string name) {
            var registrationKey = "stylesheet-" + name;
            var page = GetPage();
            if (!page.ClientScript.IsStartupScriptRegistered(type, registrationKey)) {
                page.ClientScript.RegisterStartupScript(type, registrationKey, string.Empty);

                var stylesheetLink = new HtmlLink();
                var resource = WebResourceLoader.GetResource(type, name);
                stylesheetLink.Attributes["href"] = page.ClientScript.GetWebResourceUrl(type, resource.WebResource);
                stylesheetLink.Attributes["rel"] = "stylesheet";
                stylesheetLink.Attributes["type"] = resource.ContentType;

                foreach (Control control in page.Header.Controls) {
                    if (control is HtmlTitle) {
                        page.Header.Controls.AddAt(page.Header.Controls.IndexOf(control) + 1, stylesheetLink);
                        return;
                    }
                }
            }
        }

        private static Page GetPage() {
            var context = HttpContext.Current;
            if (context == null || !(context.Handler is Page))
                throw new InvalidOperationException(typeof(Require).Name + " can only be used in the context of a Page.");
            return (Page) context.Handler;
        }
    }
}
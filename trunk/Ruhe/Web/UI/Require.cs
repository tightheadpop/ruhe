using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace Ruhe.Web.UI {
    public class Require {
        public static void StyleSheet(Type type, string name) {
            EnsureIncluded(type, "stylesheet-" + name,
                           page => {
                               var stylesheetLink = BuildStylesheetLink(name, page, type);
                               AddAsFirstElementAfterTitle(page, stylesheetLink);
                           });
        }

        private static void EnsureIncluded(Type type, string registrationKey, Action<Page> action) {
            var page = GetPage();
            if (HasBeenIncluded(page, type, registrationKey)) return;
            action(page);
            RegisterIncluded(page, type, registrationKey);
        }

        private static Page GetPage() {
            var context = HttpContext.Current;
            if (context == null || !(context.Handler is Page))
                throw new InvalidOperationException(typeof(Require).Name + " can only be used in the context of a Page.");
            return (Page) context.Handler;
        }

        private static bool HasBeenIncluded(Page page, Type type, string registrationKey) {
            return page.ClientScript.IsStartupScriptRegistered(type, registrationKey);
        }

        private static void RegisterIncluded(Page page, Type type, string registrationKey) {
            page.ClientScript.RegisterStartupScript(type, registrationKey, String.Empty);
        }

        private static HtmlLink BuildStylesheetLink(string name, Page page, Type type) {
            var stylesheetLink = new HtmlLink();
            var resource = WebResourceLoader.GetResource(type, name);
            stylesheetLink.Attributes["href"] = page.ClientScript.GetWebResourceUrl(type, resource.WebResource);
            stylesheetLink.Attributes["rel"] = "stylesheet";
            stylesheetLink.Attributes["type"] = resource.ContentType;
            return stylesheetLink;
        }

        private static void AddAsFirstElementAfterTitle(Page page, Control control) {
            ValidateThatTitleIsFirstElementInHeadOfDocument(page);
            page.Header.Controls.AddAt(1, control);
        }

        private static void ValidateThatTitleIsFirstElementInHeadOfDocument(Page page) {
            const string titleValidationMessage = "You must include a TITLE as the first element in HEAD.";

            Validate.That(page.Header.Controls.Count > 0, titleValidationMessage);
            page.Header.Controls[0].GetType().MustEqual(typeof(HtmlTitle), titleValidationMessage);
        }

        public static void DefaultStyleSheet() {
            StyleSheet(typeof(Require), "ruhe.css");
        }

        public static void JQuery() {
            Script(typeof(Require), "jquery-1.3.2.min.js");
            Script(typeof(Require), "jquery-ui-1.7.2.custom.min.js");
        }

        public static void Script(Type type, string resourceName) {
            var page = GetPage();
            if (page.ClientScript.IsClientScriptIncludeRegistered(type, resourceName))
                return;
            var url = WebResourceLoader.GetResourceUrl(type, resourceName);
            page.ClientScript.RegisterClientScriptInclude(type, resourceName, url);
        }
    }
}
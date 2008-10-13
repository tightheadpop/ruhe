using System.IO;
using System.Web.UI;
using NUnit.Extensions.Asp;

namespace Ruhe.TestExtensions {
    //TODO move to Ruhe.Tests as helper class specific to this project
    public static class ControlTesterUtilities {
        public static string GetHtml(this Control control) {
            var stringWriter = new StringWriter();
            var htmlTextWriter = new HtmlTextWriter(stringWriter);
            control.RenderControl(htmlTextWriter);
            return stringWriter.ToString();
        }

        public static bool HasChildElement(this ControlTester tester, string id) {
            return new WebControlTester(id, tester).Visible;
        }
    }
}
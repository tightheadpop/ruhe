using System.IO;
using System.Web.UI;
using NUnit.Extensions.Asp;

namespace Ruhe.TestExtensions {
    //TODO move to Ruhe.Tests as helper class specific to this project
    public class ControlTesterUtilities {
        public static bool HasChildElement(ControlTester tester, string id) {
            return new WebControlTester(id, tester).Visible;
        }

        public static string GetHtml(Control control) {
            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
            control.RenderControl(htmlTextWriter);
            return stringWriter.ToString();
        }
    }
}
using System;
using System.Configuration;
using System.IO;
using System.Web.UI;
using NUnit.Extensions.Asp;
using Ruhe.Common;

namespace Ruhe.TestExtensions {
    //TODO move to Ruhe.Tests as helper class specific to this project
    public class ControlTesterUtilities {
        public static string GetUrlPath(Type controlType) {
            string path = StringUtilities.RemovePrefix(controlType.FullName, @"\w+\.").Replace(".", "/");
            return String.Format("{0}{1}Tests.aspx", TestSite, path);
        }

        /// <summary>
        /// Yields the Url for the test site as specified in the .config file by the key "Test.Url"
        /// </summary>
        public static string TestSite {
            get {
                string result = ConfigurationManager.AppSettings["Test.Url"];
                result = StringUtilities.ForcePrefix("http://", result);
                result = StringUtilities.ForceSuffix(result, "/");
                return result;
            }
        }

        public static bool HasChildElement(ControlTester tester, string id) {
            return new GeneralControlTester(id, tester).Visible;
        }

        public static string GetHtml(Control control) {
            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
            control.RenderControl(htmlTextWriter);
            return stringWriter.ToString();
        }

        private class GeneralControlTester : ControlTester {
            public GeneralControlTester(string id, ControlTester container) : base(id, container) {}
        }
    }
}
using System;
using System.Configuration;
using System.Reflection;
using System.Xml;
using NUnit.Extensions.Asp;
using Ruhe.Common;

namespace Ruhe.TestExtensions {
	public class ControlTesterUtilities {
		public static string GetUrlPath(Type controlType) {
			string path = StringUtilities.RemovePrefix(controlType.FullName, @"\w+\.").Replace(".", "/");
			return String.Format("{0}{1}Tests.aspx", TestSite, path);
		}

		public static XmlElement GetXmlElement(ControlTester tester) {
			HtmlTag tag = (HtmlTag) Reflector.GetPropertyValue(tester, "Tag", BindingFlags.NonPublic | BindingFlags.Instance);
			return (XmlElement) Reflector.GetPropertyValue(tag, "Element", BindingFlags.NonPublic | BindingFlags.Instance);
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
			XmlElement element = GetXmlElement(tester);
			return element.SelectSingleNode(String.Format(".//*[@id=\"{0}\"]", id)) != null;
		}
	}
}
using NUnit.Extensions.Asp.HtmlTester;

namespace Ruhe.Tests.TestExtensions.HtmlTesters {
	public class HtmlImageTester : HtmlControlTester {
		public HtmlImageTester(string htmlId) : base(htmlId) {}

		public string Title {
			get { return Attribute("title"); }
		}

		public string SourceUrl {
			get { return Attribute("src");  }
		}
	}
}
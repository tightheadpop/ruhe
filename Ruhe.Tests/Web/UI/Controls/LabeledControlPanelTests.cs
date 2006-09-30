using System;
using System.Xml;
using NUnit.Extensions.Asp;
using NUnit.Extensions.Asp.AspTester;
using NUnit.Framework;
using Ruhe.Common;
using Ruhe.TestExtensions;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Tests.Web.UI.Controls {
	[TestFixture]
	public class LabeledControlPanelTests : WebFormTestCase {
		private string url;
		private LabelTester formatLabelTester;
		private LabelTester nameLabelTester;
		private TextBoxTester textBoxTester;
		private XmlDocument xmlDocument = new XmlDocument();

		protected override void SetUp() {
			base.SetUp();
			url = ControlTesterUtilities.GetUrlPath(typeof(LabeledControlPanel));
			formatLabelTester = new LabelTester("textbox_format", CurrentWebForm);
			nameLabelTester = new LabelTester("textbox_label", CurrentWebForm);
			textBoxTester = new TextBoxTester("textbox", CurrentWebForm);
		}

		[Test]
		public void Visiblity() {
			Browser.GetPage(url);

			Console.WriteLine(Browser.CurrentPageText);
			AssertVisibility(formatLabelTester, true);
			AssertVisibility(nameLabelTester, true);
			AssertVisibility(textBoxTester, true);
		}

		[Test]
		public void LabelLeft() {
			Browser.GetPage(url);
			xmlDocument.LoadXml(Browser.CurrentPageText);

			AssertNotNull(Table);
			AssertEquals(1, Rows.Count);
			AssertEquals(2, AllCells.Count);
			AssertEquals(1, Table.SelectNodes("tr[1]/td[1]//span[@id = \"textbox_label\"]").Count);
			AssertEquals(1, Table.SelectNodes("tr[1]/td[2]//span[@id = \"textbox_format\"]").Count);
			AssertEquals(1, Table.SelectNodes("tr[1]/td[2]//input[@id = \"textbox\"]").Count);

			Assert("class does not contain 'left'",
			       StringUtilities.Contains(AllCells[0].Attributes["class"].Value, "left"));
			Assert("class does not contain 'label'",
			       StringUtilities.Contains(AllCells[0].Attributes["class"].Value, "label"));

			AssertEquals(AllCells[1].Attributes["class"].Value, "labeled");
		}

		[Test]
		public void LabelAbove() {
			Browser.GetPage(url + "?Above=on");
			xmlDocument.LoadXml(Browser.CurrentPageText);
			Console.WriteLine(Browser.CurrentPageText);

			AssertEquals(1, Table.SelectNodes("tr[1]/td[1]//span[@id = \"textbox_label\"]").Count);
			AssertEquals(1, Table.SelectNodes("tr[1]/td[1]//span[@id = \"textbox_format\"]").Count);
			AssertEquals(1, Table.SelectNodes("tr[2]/td[1]//input[@id = \"textbox\"]").Count);

			Assert("class does not contain 'above'",
			       StringUtilities.Contains(AllCells[0].Attributes["class"].Value, "above"));
			Assert("class does not contain 'label'",
			       StringUtilities.Contains(AllCells[0].Attributes["class"].Value, "label"));
			AssertNotNull(Table);
			AssertEquals(2, Rows.Count);
			AssertEquals(2, AllCells.Count);
			AssertEquals(1, Table.SelectNodes("tr[1]/td").Count);
			AssertEquals(1, Table.SelectNodes("tr[2]/td").Count);
		}

		private XmlNode Table {
			get {
				XmlNode node = xmlDocument.SelectSingleNode("//table[@id = \"panel_layoutTable\"]");
				return node;
			}
		}

		private XmlNodeList Rows {
			get { return Table.SelectNodes("tr"); }
		}

		private XmlNodeList AllCells {
			get { return Table.SelectNodes(".//td"); }
		}
	}
}
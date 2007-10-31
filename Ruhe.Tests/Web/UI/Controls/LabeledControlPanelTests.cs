using NUnit.Extensions.Asp;
using NUnit.Extensions.Asp.AspTester;
using NUnit.Framework;
using Ruhe.Common.Utilities;
using Ruhe.TestExtensions;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Tests.Web.UI.Controls {
    [TestFixture]
    public class LabeledControlPanelTests : WebFormTestCase {
        private string url;
        private HtmlTagTester table;
        private LabelTester format;

        protected override void SetUp() {
            base.SetUp();
            url = ControlTesterUtilities.GetUrlPath(typeof(LabeledControlPanel));
            table = new HtmlTagTester(IdFor.It("panel_layoutTable"));
            format = new LabelTester(IdFor.It("textbox_format"));
        }

        [Test]
        public void LabelLeftLayoutAndCssClasses() {
            Browser.GetPage(url);

            Assert.IsTrue(table.Visible);
            Assert.AreEqual(1, table.Children("tr").Length, "should have one row of output");
            HtmlTagTester[] cells = table.ChildrenByXPath(".//td");
            Assert.AreEqual(2, cells.Length, "should have 2 cells");
            Assert.AreEqual(1, cells[0].ChildrenByXPath(IdFor.It("textbox_label", ".//span[@id='{0}']")).Length, "first cell should contain the label");
            Assert.AreEqual(1, cells[1].ChildrenByXPath(IdFor.It("textbox_format", ".//span[@id='{0}']")).Length, "second cell should contain the format text");
            Assert.AreEqual(1, cells[1].ChildrenByXPath(IdFor.It("textbox", ".//input[@id='{0}']")).Length, "second cell should contain the control");

            Assert.IsTrue(StringUtilities.Contains(cells[0].Attribute("class"), "left"), "class does not contain 'left'");
            Assert.IsTrue(StringUtilities.Contains(cells[0].Attribute("class"), "label"), "class does not contain 'label'");

            Assert.AreEqual("labeled", cells[1].Attribute("class"), "control cell should have css class of 'labeled'");
        }

        [Test]
        public void LabelAboveLayoutAndCssClasses() {
            Browser.GetPage(url + "?Above=on");

            Assert.AreEqual(2, table.Children("tr").Length, "should have two rows of output");
            Assert.AreEqual(1, table.ChildrenByXPath(IdFor.It("textbox_label", "tr[1]/td[1]//span[@id = \"{0}\"]")).Length, "label should be in the first row");
            Assert.AreEqual(1, table.ChildrenByXPath(IdFor.It("textbox_format", "tr[1]/td[1]//span[@id = \"{0}\"]")).Length, "format text should be in the first row");
            Assert.AreEqual(1, table.ChildrenByXPath(IdFor.It("textbox", "tr[2]/td[1]//input[@id = \"{0}\"]")).Length, "control should be in the second row");

            HtmlTagTester[] cells = table.ChildrenByXPath(".//td");
            Assert.IsTrue(StringUtilities.Contains(cells[0].Attribute("class"), "above"), "label cell css class should contain 'above'");
            Assert.IsTrue(StringUtilities.Contains(cells[0].Attribute("class"), "label"), "label cell css class should contain 'label'");
        }

        [Test]
        public void PermitsSuperTypeTextInFormat() {
            Browser.GetPage(url);
            Assert.AreEqual("(×10<sup>6</sup>)", format.Text, "should parse input and emit as HTML");
        }
    }
}
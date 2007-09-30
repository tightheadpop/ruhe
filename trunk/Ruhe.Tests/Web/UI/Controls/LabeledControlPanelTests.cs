using NUnit.Extensions.Asp;
using NUnit.Framework;
using Ruhe.Common;
using Ruhe.TestExtensions;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Tests.Web.UI.Controls {
    [TestFixture]
    public class LabeledControlPanelTests : WebFormTestCase {
        private string url;
        private HtmlTagTester tableTester;

        protected override void SetUp() {
            base.SetUp();
            url = ControlTesterUtilities.GetUrlPath(typeof(LabeledControlPanel));
            tableTester = new HtmlTagTester(IdFor.It("panel_layoutTable"));
        }

        [Test]
        public void LabelLeftLayoutAndCssClasses() {
            Browser.GetPage(url);

            Assert.IsTrue(tableTester.Visible);
            Assert.AreEqual(1, tableTester.Children("tr").Length, "should have one row of output");
            HtmlTagTester[] cells = tableTester.ChildrenByXPath(".//td");
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

            Assert.AreEqual(2, tableTester.Children("tr").Length, "should have two rows of output");
            Assert.AreEqual(1, tableTester.ChildrenByXPath(IdFor.It("textbox_label", "tr[1]/td[1]//span[@id = \"{0}\"]")).Length, "label should be in the first row");
            Assert.AreEqual(1, tableTester.ChildrenByXPath(IdFor.It("textbox_format", "tr[1]/td[1]//span[@id = \"{0}\"]")).Length, "format text should be in the first row");
            Assert.AreEqual(1, tableTester.ChildrenByXPath(IdFor.It("textbox", "tr[2]/td[1]//input[@id = \"{0}\"]")).Length, "control should be in the second row");

            HtmlTagTester[] cells = tableTester.ChildrenByXPath(".//td");
            Assert.IsTrue(StringUtilities.Contains(cells[0].Attribute("class"), "above"), "label cell css class should contain 'above'");
            Assert.IsTrue(StringUtilities.Contains(cells[0].Attribute("class"), "label"), "label cell css class should contain 'label'");
        }
    }
}
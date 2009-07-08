using System.Web.UI.WebControls;
using NUnit.Extensions.Asp;
using NUnit.Extensions.Asp.AspTester;
using NUnit.Framework;
using Ruhe.Utilities;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Tests.Web.UI.Controls {
    [TestFixture]
    public class LabeledControlPanelTests : RuheWebTest<LabeledControlPanel> {
        private LabelTester format;
        private LabelTester myEncodedLabel;
        private HtmlTagTester table;

        [Test]
        public void LabelAboveLayoutAndCssClasses() {
            LoadPageWithOption("Above");

            table.Children("tr").Length.MustEqual(8, "should have two rows of output for each control");
            Assert.AreEqual(1, table.ChildrenByXPath(Tests.IdFor.Format("textbox_label", "tr[1]/td[1]//span[@id = \"{0}\"]")).Length, "label should be in the first row");
            Assert.AreEqual(1, table.ChildrenByXPath(Tests.IdFor.Format("textbox_format", "tr[1]/td[1]//span[@id = \"{0}\"]")).Length, "format text should be in the first row");
            Assert.AreEqual(1, table.ChildrenByXPath(Tests.IdFor.Format("textbox", "tr[2]/td[1]//input[@id = \"{0}\"]")).Length, "control should be in the second row");

            HtmlTagTester[] cells = table.ChildrenByXPath(".//td");
            Assert.IsTrue(cells[0].Attribute("class").ContainsIgnoreCase("above"), "label cell css class should contain 'above'");
            Assert.IsTrue(cells[0].Attribute("class").ContainsIgnoreCase("label"), "label cell css class should contain 'label'");
        }

        [Test]
        public void LabelLeftLayoutAndCssClassesIncludingLayoutContainer() {
            LoadPage();

            Assert.IsTrue(table.Visible);
            Assert.AreEqual(4, table.Children("tr").Length, "should have one row of output per control");
            HtmlTagTester[] cells = table.ChildrenByXPath(".//td");
            Assert.AreEqual(8, cells.Length, "should have 2 cells per control");
            Assert.AreEqual(1, cells[0].ChildrenByXPath(Tests.IdFor.Format("textbox_label", ".//span[@id='{0}']")).Length, "first cell should contain the label");
            Assert.AreEqual(1, cells[1].ChildrenByXPath(Tests.IdFor.Format("textbox_format", ".//span[@id='{0}']")).Length, "second cell should contain the format text");
            Assert.AreEqual(1, cells[1].ChildrenByXPath(Tests.IdFor.Format("textbox", ".//input[@id='{0}']")).Length, "second cell should contain the control");

            Assert.IsTrue(cells[0].Attribute("class").ContainsIgnoreCase("left"), "class does not contain 'left'");
            Assert.IsTrue(cells[0].Attribute("class").ContainsIgnoreCase("label"), "class does not contain 'label'");

            Assert.AreEqual("labeled", cells[1].Attribute("class"), "control cell should have css class of 'labeled'");
        }

        [Test]
        public void PermitsSuperTypeTextInFormat() {
            LoadPage();
            Assert.AreEqual("(×10<sup>6</sup>)", format.Text, "should parse input and emit as HTML");
        }

        [Test]
        public void RendersEncodedLabelCorrectly() {
            LoadPage();
            WebAssert.Visible(myEncodedLabel);
        }

        [Test]
        public void SettingValidationGroupSetsOnAllContainedControlsWithValidationGroupProperty() {
            var panel = new LabeledControlPanel();
            var iinputControlChild = new InputTextBox();
            var childWithoutProperty = new Label();
            var nonIInputControlChild = new TextBox();
            panel.Controls.Add(iinputControlChild);
            panel.Controls.Add(childWithoutProperty);
            panel.Controls.Add(nonIInputControlChild);

            const string groupName = "foo";
            panel.ValidationGroup = groupName;

            Assert.AreEqual(groupName, panel.ValidationGroup);
            Assert.AreEqual(groupName, iinputControlChild.ValidationGroup);
            Assert.AreEqual(groupName, nonIInputControlChild.ValidationGroup);
        }

        [Test]
        public void SupportsUserControlAsLayoutContainer() {
            LoadPage();
            WebAssert.Visible(new TextBoxTester(IdFor("userControl_anotherTextBox")));
            WebAssert.Visible(new TextBoxTester(IdFor("userControl_anotherDate")));
        }

        protected override void SetUp() {
            base.SetUp();
            table = new HtmlTagTester(IdFor("panel_layoutTable"));
            format = new LabelTester(IdFor("textbox_format"));
            myEncodedLabel = new LabelTester(IdFor("myEncodedLabel"));
        }
    }
}
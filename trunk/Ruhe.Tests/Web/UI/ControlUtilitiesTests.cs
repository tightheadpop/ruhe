using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using NUnit.Framework;
using Ruhe.Web.UI;

namespace Ruhe.Tests.Web.UI {
    [TestFixture]
    public class ControlUtilitiesTests {
        private Panel firstChild;
        private Label grandChild;
        private Panel parentControl;
        private GenericNamingContainer secondChild;

        [SetUp]
        public void SetUp() {
            parentControl = new Panel();
            parentControl.ID = "parent";

            firstChild = new Panel();
            firstChild.ID = "first";
            parentControl.Controls.Add(firstChild);

            secondChild = new GenericNamingContainer();
            secondChild.ID = "second";
            parentControl.Controls.Add(secondChild);

            grandChild = new Label();
            grandChild.ID = "grandchild";
            secondChild.Controls.Add(grandChild);
        }

        [Test]
        public void FindByIdAcrossNamingContainers() {
            Control result = ControlUtilities.FindRecursive(parentControl, "grandchild");
            Assert.AreEqual(grandChild, result, "should find exactly one grand child based on id");
            Assert.IsNull(ControlUtilities.FindRecursive(parentControl, "not gonna find it"), "found non-existent control");
        }

        [Test]
        public void FindByInterface() {
            List<INamingContainer> result = ControlUtilities.FindRecursive<INamingContainer>(parentControl);
            Assert.AreEqual(1, result.Count);
            Assert.IsTrue(result.Contains(secondChild), "result set does not contain second child INamingContainer");
        }

        [Test]
        public void FindByType() {
            List<Panel> result = ControlUtilities.FindRecursive<Panel>(parentControl);
            Assert.AreEqual(3, result.Count);
            Assert.IsTrue(result.Contains(parentControl), "result set does not contain parent panel");
            Assert.IsTrue(result.Contains(firstChild), "result set does not contain first child panel");
            Assert.IsTrue(result.Contains(secondChild), "result set does not contain second child panel");
        }

        [Test]
        public void FindByTypeStopsRecursing() {
            List<Panel> result = ControlUtilities.FindRecursive<Panel>(parentControl, delegate(Control c) { return !(c is INamingContainer); });
            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result.Contains(parentControl), "result set should contain parent panel");
            Assert.IsTrue(result.Contains(firstChild), "result set should contain first child panel");
        }

        private class GenericNamingContainer : Panel, INamingContainer {}
    }
}
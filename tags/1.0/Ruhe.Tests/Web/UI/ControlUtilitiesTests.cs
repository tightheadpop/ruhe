using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;
using NUnit.Framework;
using Ruhe.Web.UI;

namespace Ruhe.Tests.Web.UI {
	[TestFixture]
	public class ControlUtilitiesTests {
		private Panel parentControl;
		private Panel firstChild;
		private GenericNamingContainer secondChild;
		private Label grandChild;

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
			Control result = ControlUtilities.FindControlRecursive(parentControl, "grandchild");
			Assert.AreEqual(grandChild, result, "should find exactly one grand child based on id");
			Assert.IsNull(ControlUtilities.FindControlRecursive(parentControl, "not gonna find it"), "found non-existent control");
		}

		[Test]
		public void FindByType() {
			ArrayList result = ControlUtilities.FindControlsRecursive(parentControl, typeof(Panel));
			Assert.IsTrue(result.Contains(parentControl), "result set does not contain parent panel");
			Assert.IsTrue(result.Contains(firstChild), "result set does not contain first child panel");
			Assert.IsTrue(result.Contains(secondChild), "result set does not contain second child panel");
			Assert.IsFalse(result.Contains(grandChild), "result contains non-panel control");
		}

		[Test]
		public void FindByInterface() {
			ArrayList result = ControlUtilities.FindControlsRecursive(parentControl, typeof(INamingContainer));
			Assert.IsTrue(result.Contains(secondChild), "result set does not contain second child INamingContainer");
			Assert.IsFalse(result.Contains(parentControl), "result contains non-namingcontainer parent control");
			Assert.IsFalse(result.Contains(firstChild), "result contains non-namingcontainer first child control");
			Assert.IsFalse(result.Contains(grandChild), "result contains non-namingcontainer grandchild control");
		}

		[Test]
		public void GetHtmlFromControl() {
			Label thing = new Label();
			thing.Text = "thing";
			string result = ControlUtilities.GetHtml(thing);
			Assert.AreEqual("<span>thing</span>", result, "Html output does not match");
		}

		private class GenericNamingContainer : Panel, INamingContainer {}
	}
}
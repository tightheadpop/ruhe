using System;
using System.Collections;
using System.Web.UI;

namespace Ruhe.Web.UI {
	public sealed class ControlUtilities {
		private ControlUtilities() {}

		public static Control FindControlRecursive(Control parent, string childId) {
			if (parent.ID == childId)
				return parent;
			foreach (Control child in parent.Controls) {
				Control result = FindControlRecursive(child, childId);
				if (result != null)
					return result;
			}
			return null;
		}

		public static ArrayList FindControlsRecursive(Control parent, Type childTypeToFind) {
			ArrayList result = new ArrayList();
			if (childTypeToFind.IsInstanceOfType(parent)) {
				result.Add(parent);
			}
			foreach (Control child in parent.Controls) {
				result.AddRange(FindControlsRecursive(child, childTypeToFind));
			}
			return result;
		}

		public static string GetRandomName() {
			return "x" + Guid.NewGuid().ToString().Replace("-", String.Empty);
		}

		public static void SetInitialFocus(Control container, Type typeOfFirstControlToRecieveFocus) {
			ArrayList controls = FindControlsRecursive(container, typeOfFirstControlToRecieveFocus);
			if (controls.Count > 0)
				container.Page.SetFocus((Control) controls[0]);
		}
	}
}
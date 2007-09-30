using System;
using System.Collections;
using System.Web.UI;

namespace Ruhe.Web.UI {
	public class ControlUtilities {
		public static Control FindRecursive(Control parent, string childId) {
			if (parent.ID == childId)
				return parent;
			foreach (Control child in parent.Controls) {
				Control result = FindRecursive(child, childId);
				if (result != null)
					return result;
			}
			return null;
		}

		public static ArrayList FindRecursive(Control parent, Type childTypeToFind) {
			ArrayList result = new ArrayList();
			if (childTypeToFind.IsInstanceOfType(parent)) {
				result.Add(parent);
			}
			foreach (Control child in parent.Controls) {
				result.AddRange(FindRecursive(child, childTypeToFind));
			}
			return result;
		}
	}
}
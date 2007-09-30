using System.Collections.Generic;
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

        public static List<T> FindRecursive<T>(Control parent) {
            List<T> result = new List<T>();
            if (typeof(T).IsInstanceOfType(parent)) {
                result.Add((T) (object) parent);
            }
            foreach (Control child in parent.Controls) {
                result.AddRange(FindRecursive<T>(child));
            }
            return result;
        }
    }
}
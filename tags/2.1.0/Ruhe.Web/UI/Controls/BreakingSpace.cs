using System.Web.UI;

namespace Ruhe.Web.UI.Controls {
    /// <summary>
    /// Renders as an HTML non-breaking space (&amp;nbsp;). Intended for use within
    /// control code that builds HTML dynamically
    /// </summary>
    public class BreakingSpace : LiteralControl {
        public BreakingSpace() : base(" ") {}
    }
}
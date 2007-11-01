using System.Web.UI;

namespace Ruhe.Web.UI.Controls {
    /// <summary>
    /// Renders as an HTML line break <c>&lt;br /&gt;</c>. Intended for use within
    /// control code that builds HTML dynamically
    /// </summary>
    public class LineBreak : LiteralControl {
        public LineBreak() : base("<br />") {}
    }
}
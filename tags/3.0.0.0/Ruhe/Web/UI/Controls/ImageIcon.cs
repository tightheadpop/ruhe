using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ruhe.Web.UI.Controls {
    public abstract class ImageIcon : Image, IIcon {
        public ImageIcon() {
            EnableViewState = false;
            ImageAlign = ImageAlign.AbsMiddle;
            BorderWidth = Unit.Pixel(0);
            ToolTip = Name;
        }

        public ImageIcon(string toolTip) : this() {
            ToolTip = toolTip;
        }

        public abstract string Description { get; }
        public abstract string Name { get; }

        protected override void Render(HtmlTextWriter writer) {
            AlternateText = ToolTip;
            base.Render(writer);
        }
    }
}
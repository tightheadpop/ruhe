using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ruhe.Web.UI.Controls.Icons {
	public abstract class ImageIcon : Image, IIcon {
		public abstract string Name { get; }
		public abstract string Description { get; }
		public abstract string SourcePath { get; }

		public ImageIcon() {
			EnableViewState = false;
			ImageAlign = ImageAlign.AbsMiddle;
			BorderWidth = Unit.Pixel(0);
			ToolTip = Name;
		}

		public ImageIcon(string toolTip) : this() {
			ToolTip = toolTip;
		}

		protected override void Render(HtmlTextWriter writer) {
			AlternateText = ToolTip;
			ImageUrl = Path.Combine(Page.Request.ApplicationPath, SourcePath);
			base.Render(writer);
		}
	}
}
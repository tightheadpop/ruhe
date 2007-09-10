using System.Web.UI;

namespace Ruhe.Web.UI.Controls.Icons {
	public class RequiredIcon : ImageIcon {
		public RequiredIcon() {
			ImageUrl = "~/images/required.gif";
		}
		public RequiredIcon(string toolTip) : base(toolTip) {
			ImageUrl = "~/images/required.gif";
		}

		public override string Name {
			get { return "Required"; }
		}

		public override string Description {
			get { return "The marked field requires a value."; }
		}

		protected override void Render(HtmlTextWriter writer) {
			writer.AddAttribute(HtmlTextWriterAttribute.Class, "validation");
			writer.RenderBeginTag(HtmlTextWriterTag.Span);
			base.Render(writer);
			writer.RenderEndTag();
		}
	}
}
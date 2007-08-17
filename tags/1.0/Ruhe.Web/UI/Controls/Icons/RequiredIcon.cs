using System.Web.UI;

namespace Ruhe.Web.UI.Controls.Icons {
	public class RequiredIcon : ImageIcon {
		public RequiredIcon() {}
		public RequiredIcon(string toolTip) : base(toolTip) {}

		public override string Name {
			get { return "Required"; }
		}

		public override string Description {
			get { return "The marked field requires a value."; }
		}

		public override string SourcePath {
			get { return "/images/required.gif"; }
		}

		protected override void Render(HtmlTextWriter writer) {
			writer.AddAttribute(HtmlTextWriterAttribute.Class, "validation");
			writer.RenderBeginTag(HtmlTextWriterTag.Span);
			base.Render(writer);
			writer.RenderEndTag();
		}
	}
}
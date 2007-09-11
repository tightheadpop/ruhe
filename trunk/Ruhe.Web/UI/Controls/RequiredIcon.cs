using System.Web.UI;

namespace Ruhe.Web.UI.Controls {
	public class RequiredIcon : ImageIcon {
		public RequiredIcon() {}

		public RequiredIcon(string toolTip) : base(toolTip) {}

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

		protected override void CreateChildControls() {
			base.CreateChildControls();
			ImageUrl = Page.ClientScript.GetWebResourceUrl(GetType(), "Ruhe.Web.Resources.required.gif");
		}
	}
}
using System.Web.UI;

namespace Ruhe.Web.UI.Controls {
	public class ResetButton : Button {
		public ResetButton() {
			Text = "&Reset";
			CausesValidation = false;
			UseSubmitBehavior = false;
		}

		protected override void CreateChildControls() {
			base.CreateChildControls();
			ImageUrl = Page.ClientScript.GetWebResourceUrl(GetType(), "Ruhe.Web.Resources.reset.png");
		}

		protected override void AddAttributesToRender(HtmlTextWriter writer) {
			writer.AddAttribute(HtmlTextWriterAttribute.Type, "reset");
			writer.AddAttribute(HtmlTextWriterAttribute.Id, ClientID);
			writer.AddAttribute(HtmlTextWriterAttribute.Accesskey, AccessKey);
			writer.AddAttribute(HtmlTextWriterAttribute.Class, CssClass);
			writer.AddAttribute(HtmlTextWriterAttribute.Title, ToolTip);
		}
	}
}
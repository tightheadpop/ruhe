using System.Web.UI;
using Ruhe.Configuration;
using Ruhe.Web.Resources;

namespace Ruhe.Web.UI.Controls {
    [DefaultImageResource("reset.png")]
    public class ResetButton : Button {
        public ResetButton() {
            Text = "&Reset";
            CausesValidation = false;
            UseSubmitBehavior = false;
        }

        protected override void AddAttributesToRender(HtmlTextWriter writer) {
            writer.AddAttribute(HtmlTextWriterAttribute.Type, "reset");
            writer.AddAttribute(HtmlTextWriterAttribute.Id, ClientID);
            writer.AddAttribute(HtmlTextWriterAttribute.Accesskey, AccessKey);
            writer.AddAttribute(HtmlTextWriterAttribute.Class, CssClass);
            writer.AddAttribute(HtmlTextWriterAttribute.Title, ToolTip);
        }

        protected override void CreateChildControls() {
            base.CreateChildControls();
            ImageUrl = RuheConfiguration.ImageUrlFor<ResetButton>();
        }
    }
}
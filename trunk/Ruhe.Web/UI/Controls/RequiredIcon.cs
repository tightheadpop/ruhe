using System.Web.UI;
using Ruhe.Web.Configuration;

namespace Ruhe.Web.UI.Controls {
    public class RequiredIcon : ImageIcon {
        public RequiredIcon() {}

        public RequiredIcon(string toolTip) : base(toolTip) {}

        public override string Description {
            get { return "The marked field requires a value."; }
        }

        public override string Name {
            get { return "Required"; }
        }

        protected override void CreateChildControls() {
            base.CreateChildControls();
            ImageUrl = RuheConfiguration.ImageUrlFor<RequiredIcon>("required.gif");
        }

        protected override void Render(HtmlTextWriter writer) {
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "validation");
            writer.RenderBeginTag(HtmlTextWriterTag.Span);
            base.Render(writer);
            writer.RenderEndTag();
        }
    }
}
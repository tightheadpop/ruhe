using Ruhe.Configuration;
using Ruhe.Web.Resources;

namespace Ruhe.Web.UI.Controls {
    [DefaultImageResource("error.gif")]
    public class ErrorIcon : ImageIcon {
        public ErrorIcon() {}

        public ErrorIcon(string toolTip) : base(toolTip) {}

        public override string Description {
            get { return "The marked field has a validation error."; }
        }

        public override string Name {
            get { return "Error"; }
        }

        protected override void CreateChildControls() {
            base.CreateChildControls();
            ImageUrl = RuheConfiguration.ImageUrlFor<ErrorIcon>();
        }
    }
}
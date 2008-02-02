using Ruhe.Web.Configuration;

namespace Ruhe.Web.UI.Controls {
    public class ErrorIcon : ImageIcon {
        public ErrorIcon() {}

        public ErrorIcon(string toolTip) : base(toolTip) {}

        public override string Name {
            get { return "Error"; }
        }

        public override string Description {
            get { return "The marked field has a validation error."; }
        }

        protected override void CreateChildControls() {
            base.CreateChildControls();
            ImageUrl = RuheConfiguration.ImageUrlFor<ErrorIcon>("error.gif");
        }
    }
}
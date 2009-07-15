using Ruhe.Configuration;

namespace Ruhe.Web.UI.Controls {
    public class CancelButton : Button {
        public CancelButton() {
            CausesValidation = false;
            Text = "&Cancel";
        }

        protected override void CreateChildControls() {
            base.CreateChildControls();
            ImageUrl = RuheConfiguration.ImageUrlFor<CancelButton>("cancel.png");
        }
    }
}
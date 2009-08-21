using Ruhe.Configuration;
using Ruhe.Web.Resources;

namespace Ruhe.Web.UI.Controls {
    [DefaultImageResource("cancel.png")]
    public class CancelButton : Button {
        public CancelButton() {
            CausesValidation = false;
            Text = "&Cancel";
        }

        protected override void CreateChildControls() {
            base.CreateChildControls();
            ImageUrl = RuheConfiguration.ImageUrlFor<CancelButton>();
        }
    }
}
using Ruhe.Common.Utilities;
using Ruhe.Web.Configuration;

namespace Ruhe.Web.UI.Controls {
    public class CancelButton : Button {
        public CancelButton() {
            CausesValidation = false;
            Text = "&Cancel";
        }

        protected override void CreateChildControls() {
            base.CreateChildControls();
            ImageUrl = StringUtilities.TrimToNull(RuheConfiguration.ImageUrlFor<CancelButton>())
                ?? Page.ClientScript.GetWebResourceUrl(GetType(), "Ruhe.Web.Resources.cancel.png");
        }
    }
}
using Ruhe.Common.Utilities;
using Ruhe.Web.Configuration;

namespace Ruhe.Web.UI.Controls {
    public class SaveButton : Button {
        public SaveButton() {
            Text = "&Save";
        }

        protected override void CreateChildControls() {
            base.CreateChildControls();
            ImageUrl = StringUtilities.TrimToNull(RuheConfiguration.ImageUrlFor<SaveButton>())
                ?? Page.ClientScript.GetWebResourceUrl(GetType(), "Ruhe.Web.Resources.save.png");
        }
    }
}
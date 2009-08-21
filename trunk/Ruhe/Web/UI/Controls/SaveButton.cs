using Ruhe.Configuration;
using Ruhe.Web.Resources;

namespace Ruhe.Web.UI.Controls {
    [DefaultImageResource("save.png")]
    public class SaveButton : Button {
        public SaveButton() {
            Text = "&Save";
        }

        protected override void CreateChildControls() {
            base.CreateChildControls();
            ImageUrl = RuheConfiguration.ImageUrlFor<SaveButton>();
        }
    }
}
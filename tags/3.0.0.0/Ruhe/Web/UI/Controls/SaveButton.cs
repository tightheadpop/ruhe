using Ruhe.Configuration;

namespace Ruhe.Web.UI.Controls {
    public class SaveButton : Button {
        public SaveButton() {
            Text = "&Save";
        }

        protected override void CreateChildControls() {
            base.CreateChildControls();
            ImageUrl = RuheConfiguration.ImageUrlFor<SaveButton>("save.png");
        }
    }
}
namespace Ruhe.Web.UI.Controls {
    public class SaveButton : Button {
        public SaveButton() {
            Text = "&Save";
        }

        protected override void CreateChildControls() {
            base.CreateChildControls();
            ImageUrl = Page.ClientScript.GetWebResourceUrl(GetType(), "Ruhe.Web.Resources.save.png");
        }
    }
}
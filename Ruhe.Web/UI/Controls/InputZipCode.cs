namespace Ruhe.Web.UI.Controls {
    public class InputZipCode : InputTextBox {
        protected override void CreateChildControls() {
            base.CreateChildControls();
            ValidationExpression = @"\d{5}(-?\d{4})?";
            ErrorMessage = "Please enter a valid ZIP Code.";
            FormatText = "99999 or 99999-9999";
            LabelText = "ZIP Code";
            MaxLength = 10;
        }
    }
}
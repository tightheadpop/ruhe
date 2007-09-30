using System.Web.UI.WebControls;

namespace Ruhe.Web.UI.Controls {
    public class InputPhoneExtension : InputTextBox {
        protected override void CreateChildControls() {
            base.CreateChildControls();
            FormatText = "1234";
            LabelText = "Phone Extension";
            MaxLength = 4;
            Width = new Unit(4, UnitType.Em);
            ValidationExpression = @"\d{1,4}";
            ErrorMessage = "Please enter a valid phone extension.";
        }
    }
}
using System.Web.UI.WebControls;

namespace Ruhe.Web.UI.Controls {
    public class InputPhoneNumber : InputTextBox {
        protected override void CreateChildControls() {
            base.CreateChildControls();

            FormatText = "(999) 999-9999";
            LabelText = "Phone Number";
            MaxLength = 15;
            Width = new Unit(13, UnitType.Em);
            ErrorMessage = "Please enter a valid phone number.";
            //regexlib.com
            //ValidationExpression = @"([\(]{1}[0-9]{3}[\)]{1}[ |\-]{0,1}|[0-9]{3}[\-| ])?[0-9]{3}(\-| ){1}[0-9]{4}";
            ValidationExpression = @"((\(\d{3}\) ?)|(\d{3}[-\.]?))\d{3}[-\. ]?\d{4}";
        }
    }
}
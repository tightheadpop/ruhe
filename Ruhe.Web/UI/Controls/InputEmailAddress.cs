namespace Ruhe.Web.UI.Controls {
    public class InputEmailAddress : InputTextBox {
        protected override void CreateChildControls() {
            base.CreateChildControls();
            ValidationExpression =
                @"['\w_-]+(\.['\w_-]+)*@['\w_-]+(\.['\w_-]+)*\.[a-zA-Z]{2,4}";

            LabelText = "Email Address";
            FormatText = "yourname@example.com";
            ErrorMessage = "Please enter a valid email address";
        }
    }
}
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ruhe.Web.UI.Controls {
    public class InputDateValidator : BaseValidator {
        protected override bool EvaluateIsValid() {
            InputDate input = GetControlToValidate();
            if (string.IsNullOrEmpty(input.Text))
                return true;
            return input.Value != null;
        }

        protected override bool ControlPropertiesValid() {
            return FindControl(ControlToValidate) is InputDate;
        }

        protected virtual InputDate GetControlToValidate() {
            return (InputDate) FindControl(ControlToValidate);
        }

        protected override void AddAttributesToRender(HtmlTextWriter writer) {
            base.AddAttributesToRender(writer);
            Page.ClientScript.RegisterExpandoAttribute(ClientID, "evaluationfunction", "Ruhe_EvaluateInputDateIsValid");
        }
    }
}
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ruhe.Web.UI.Controls {
    public class InputDateValidator : BaseValidator {
        protected override void AddAttributesToRender(HtmlTextWriter writer) {
            base.AddAttributesToRender(writer);
            Page.ClientScript.RegisterExpandoAttribute(ClientID, "evaluationfunction", "Ruhe_EvaluateInputDateIsValid");
        }

        protected override bool ControlPropertiesValid() {
            return FindControl(ControlToValidate) is InputDate;
        }

        protected override bool EvaluateIsValid() {
            var input = GetControlToValidate();
            if (string.IsNullOrEmpty(input.Text))
                return true;
            return input.Value != null;
        }

        protected virtual InputDate GetControlToValidate() {
            return (InputDate) FindControl(ControlToValidate);
        }
    }
}
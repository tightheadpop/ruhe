using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ruhe.Web.UI.Controls {
    public class InputDateRangeValidator : BaseValidator {
        protected override void AddAttributesToRender(HtmlTextWriter writer) {
            base.AddAttributesToRender(writer);
            Page.ClientScript.RegisterExpandoAttribute(ClientID, "evaluationfunction", "Ruhe_EvaluateInputDateRangeIsValid");
        }

        protected override bool EvaluateIsValid() {
            InputDate to = FindToDate();
            InputDate from = FindFromDate();
            return to.Value == null || from.Value == null || from.Value.Value <= to.Value.Value;
        }

        protected virtual InputDate FindFromDate() {
            return (InputDate) FindControl(Regex.Replace(ControlToValidate, "_to$", "_from"));
        }

        protected virtual InputDate FindToDate() {
            return (InputDate) FindControl(ControlToValidate);
        }
    }
}
using System.Drawing;

namespace Ruhe.Web.UI.Controls {
    public class ValidationSummary : System.Web.UI.WebControls.ValidationSummary {
        public ValidationSummary() {
            ForeColor = Color.Empty;
            ShowSummary = true;
            ShowMessageBox = false;
            CssClass = "validation-summary";
        }
    }
}
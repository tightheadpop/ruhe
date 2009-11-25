using System.Web.UI;
using System.Web.UI.WebControls;
using LiquidSyntax;

namespace Ruhe.Web.UI.Controls {
    public class InputInteger : AbstractValueTypeInput<int> {
        protected override ValidationDataType ValidationDataType {
            get { return ValidationDataType.Integer; }
        }

        protected override void Render(HtmlTextWriter writer) {
            var oldCssClass = CssClass;
            CssClass = (CssClass + " " + GetCssClass()).Trim();
            base.Render(writer);
            CssClass = oldCssClass;
        }

        private string GetCssClass() {
            var positive = ((MinimumValue.HasValue && MinimumValue >= 0) ? "positive-" : string.Empty);
            return "numeric {0}integer".Substitute(positive);
        }
    }
}
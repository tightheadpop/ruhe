using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ruhe.Web.UI.Controls {
    public class InputInteger : AbstractValueTypeInput<int> {
        protected override string KeystrokeFilter {
            get { return string.Empty; }
        }

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
            return "numeric integer" + ((MinimumValue.HasValue && MinimumValue >= 0) ? " positive" : string.Empty);
        }
    }
}
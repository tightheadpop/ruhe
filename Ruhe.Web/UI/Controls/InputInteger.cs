using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ruhe.Web.UI.Controls {
    public class InputInteger : AbstractValueTypeInput<int> {
        protected override string KeystrokeFilter {
            get {
                if (!MinimumValue.HasValue || MinimumValue < 0)
                    return "Ruhe$INTEGER";
                return "Ruhe$POSITIVE_INTEGER";
            }
        }

        protected override ValidationDataType ValidationDataType {
            get { return ValidationDataType.Integer; }
        }

        protected override void Render(HtmlTextWriter writer) {
            string oldCssClass = CssClass;
            CssClass = (CssClass + " numeric").Trim();
            base.Render(writer);
            CssClass = oldCssClass;
        }
    }
}
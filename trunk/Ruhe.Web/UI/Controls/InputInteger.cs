using System.Web.UI.WebControls;

namespace Ruhe.Web.UI.Controls {
    public class InputInteger : AbstractValueTypeInput<int> {
        protected override ValidationDataType ValidationDataType {
            get { return ValidationDataType.Integer; }
        }

        protected override string KeystrokeFilter {
            get { return @"/\d/"; }
        }
    }
}
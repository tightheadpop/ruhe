using System.Web.UI.WebControls;

namespace Ruhe.Web.UI.Controls {
    public class InputNumber : AbstractValueTypeInput<double> {
        protected override ValidationDataType ValidationDataType {
            get { return ValidationDataType.Double; }
        }

        protected override string KeystrokeFilter {
            get {
                return @"
	function(input){
		if(input.value.indexOf('.') >= 0)
			return /[\d]/;
		else
			return /[\d.]/;
	}";
            }
        }
    }
}
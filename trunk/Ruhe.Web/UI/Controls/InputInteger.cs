using System.Web.UI.WebControls;

namespace Ruhe.Web.UI.Controls {
    public class InputInteger : AbstractValueTypeInput<int> {
        protected override ValidationDataType ValidationDataType {
            get { return ValidationDataType.Integer; }
        }

        protected override string KeystrokeFilter {
            get {
                if (!MinimumValue.HasValue || MinimumValue < 0)
                    return @"
	function(input){
        if (!document.selection)
            return /[\d-]/;
        var currentRange = document.selection.createRange();
        var wholeRange = this.createTextRange();
        if (currentRange.compareEndPoints('StartToStart', wholeRange) > 0)
	        return /[\d]/;
		return /[\d-]/;
	}";
                else
                    return @"/\d/";
            }
        }

    }
}
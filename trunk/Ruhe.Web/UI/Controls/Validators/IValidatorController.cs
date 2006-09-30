using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ruhe.Web.UI.Controls.Validators {
	public interface IValidatorController {
		void InitializeValidator(BaseValidator validator, string errorMessage);
		void InitializeValidators(IInputControl control);
		string GetValidationSummaryErrorMessage(Control controlToValidate, string errorMessage);
	}
}
using System;
using System.Collections;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Web.UI {
	public class DefaultValidatorConfigurator {
		private static void Configure(BaseValidator validator, string errorMessage) {
			validator.PreRender += GetPreRenderDelegate(errorMessage);
		}

		private static EventHandler GetPreRenderDelegate(string errorMessage) {
			return
				delegate(object sender, EventArgs e) {
					BaseValidator validator = (BaseValidator) sender;
					errorMessage = errorMessage.TrimEnd('.');
					string errorIconHoverHelp = errorMessage + ".";
					string summaryMessage;
					string summaryClickFocusElementClientId;
					Control controlToValidate = validator.FindControl(validator.ControlToValidate);
					summaryMessage = GetValidationSummaryErrorMessage(controlToValidate, errorMessage);
					summaryClickFocusElementClientId = GetClientId(controlToValidate);
					validator.Controls.Clear();
					validator.Controls.Add(new ErrorIcon(errorIconHoverHelp));
					validator.ErrorMessage = string.Format("<a href='javascript:document.getElementById(&quot;{0}&quot;).focus();'>{1}</a>",
					                                       summaryClickFocusElementClientId,
					                                       summaryMessage);
					validator.Display = ValidatorDisplay.Dynamic;
					validator.ForeColor = Color.Empty;
					validator.CssClass = "validation";
					validator.EnableViewState = false;
					validator.SetFocusOnError = true;
				};
		}

		public static void ConfigureValidators(IInputControl control) {
			ArrayList validators = ControlUtilities.FindControlsRecursive((Control) control, typeof(BaseValidator));
			foreach (BaseValidator validator in validators) {
				validator.ControlToValidate = control.ValidatedControlId;
				validator.ValidationGroup = control.ValidationGroup;
				Configure(validator, control.ErrorMessage);
			}
		}

		private static string GetValidationSummaryErrorMessage(Control controlToValidate, string errorMessage) {
			string fieldName = String.Empty;
			string returnValue;
			if (controlToValidate is IInputControl) {
				fieldName = ((IInputControl) controlToValidate).LabelText.Trim();
			}
			if (fieldName.Length > 0) {
				returnValue = string.Format("{0} in the {1} field.", errorMessage, fieldName);
			}
			else {
				returnValue = errorMessage + ".";
			}
			return returnValue;
		}

		private static string GetClientId(Control control) {
			string clientId;
			if (control is IInputControl) {
				clientId = ((IInputControl) control).DefaultElementClientId;
			}
			else {
				clientId = control.ClientID;
			}
			return clientId;
		}
	}
}
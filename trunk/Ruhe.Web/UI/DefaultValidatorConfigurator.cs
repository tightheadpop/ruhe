using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Web.UI {
	public class DefaultValidatorConfigurator {
		private static void Configure(BaseValidator validator, string errorMessage) {
			errorMessage = errorMessage.TrimEnd('.');
			validator.Controls.Clear();
			string errorIconHoverHelp = errorMessage + ".";
			validator.Controls.Add(new ErrorIcon(errorIconHoverHelp));
			SetDefaultProperties(validator);
			validator.PreRender += SetValidatorSummaryErrorMessage(errorMessage);
		}

		private static void SetDefaultProperties(BaseValidator validator) {
			validator.Display = ValidatorDisplay.Dynamic;
			validator.ForeColor = Color.Empty;
			validator.CssClass = "validation";
			validator.EnableViewState = false;
			validator.SetFocusOnError = true;
		}

		private static EventHandler SetValidatorSummaryErrorMessage(string errorMessage) {
			return
				delegate(object sender, EventArgs e) {
					BaseValidator validator = (BaseValidator) sender;
					Control controlToValidate = validator.FindControl(validator.ControlToValidate);
					string summaryMessage = CreateValidationSummaryErrorMessage(controlToValidate, errorMessage);
					string summaryClickFocusElementClientId = GetClientId(controlToValidate);
					validator.ErrorMessage = string.Format("<a href='javascript:document.getElementById(&quot;{0}&quot;).focus();'>{1}</a>",
					                                       summaryClickFocusElementClientId,
					                                       summaryMessage);
				};
		}

		public static void ConfigureValidators(IInputControl inputControl) {
			foreach (BaseValidator validator in ControlUtilities.FindRecursive<BaseValidator>((Control) inputControl)) {
				validator.ControlToValidate = inputControl.ValidatedControlId;
				validator.ValidationGroup = inputControl.ValidationGroup;
				Configure(validator, inputControl.ErrorMessage);
				AddValidatorExtender(inputControl, validator);
			}
		}

		private static void AddValidatorExtender(IInputControl control, BaseValidator validator) {
			ValidatorCalloutExtender calloutExtender = new ValidatorCalloutExtender();
			calloutExtender.ID = validator.ID + "_callout";
			calloutExtender.TargetControlID = validator.ID;
			calloutExtender.HighlightCssClass = "validation-error";
			((Control)control).Controls.Add(calloutExtender);
		}

		private static string CreateValidationSummaryErrorMessage(Control controlToValidate, string errorMessage) {
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
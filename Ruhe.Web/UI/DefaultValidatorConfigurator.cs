using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Web.UI {
    public class DefaultValidatorConfigurator : IValidatorConfigurator {
        public void Configure(IInputControl inputControl) {
            foreach (BaseValidator validator in ControlUtilities.FindRecursive<BaseValidator>((Control) inputControl)) {
                validator.ControlToValidate = inputControl.ValidatedControlId;
                validator.ValidationGroup = inputControl.ValidationGroup;
                Configure(validator, inputControl.ErrorMessage);
                AddValidatorExtender(inputControl, validator);
            }
        }

        private static void Configure(BaseValidator validator, string errorMessage) {
            errorMessage = errorMessage.TrimEnd('.');
            validator.Controls.Clear();
            string errorIconHoverHelp = errorMessage + ".";
            validator.Controls.Add(new ErrorIcon(errorIconHoverHelp));
            SetDefaultProperties(validator);
            validator.ErrorMessage = errorIconHoverHelp;
        }

        private static void SetDefaultProperties(BaseValidator validator) {
            validator.Display = ValidatorDisplay.Dynamic;
            validator.ForeColor = Color.Empty;
            validator.CssClass = "validation";
            validator.EnableViewState = false;
            validator.SetFocusOnError = true;
        }

        private static void AddValidatorExtender(IInputControl control, Control validator) {
            ValidatorCalloutExtender calloutExtender = new ValidatorCalloutExtender();
            calloutExtender.ID = validator.ID + "_callout";
            calloutExtender.TargetControlID = validator.ID;
            calloutExtender.HighlightCssClass = "validation-error";
            ((Control) control).Controls.Add(calloutExtender);
        }

    }
}
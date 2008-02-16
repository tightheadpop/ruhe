using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Web.UI {
    public class DefaultValidatorConfigurator : IValidatorConfigurator {
        protected virtual void AddValidatorExtender(BaseValidator validator, IInputControl control) {
            ValidatorCalloutExtender calloutExtender = new ValidatorCalloutExtender();
            calloutExtender.ID = validator.ID + "_callout";
            calloutExtender.TargetControlID = validator.ID;
            calloutExtender.HighlightCssClass = "validation-error";
            ((Control) control).Controls.Add(calloutExtender);
        }

        public virtual void ConfigureControl(IInputControl inputControl) {
            foreach (BaseValidator validator in ControlUtilities.FindRecursive<BaseValidator>((Control) inputControl)) {
                validator.ValidationGroup = inputControl.ValidationGroup;
                ConfigureValidator(validator, inputControl);
                AddValidatorExtender(validator, inputControl);
            }
        }

        public virtual void ConfigureValidator(BaseValidator validator, IInputControl control) {
            string errorMessage = control.ErrorMessage.TrimEnd('.');
            validator.Controls.Clear();
            string errorIconHoverHelp = errorMessage + ".";
            validator.Controls.Add(new ErrorIcon(errorIconHoverHelp));
            SetDefaultProperties(validator);
            validator.ErrorMessage = errorIconHoverHelp;
        }

        protected virtual void SetDefaultProperties(BaseValidator validator) {
            validator.Display = ValidatorDisplay.Dynamic;
            validator.ForeColor = Color.Empty;
            validator.CssClass = "validation";
            validator.EnableViewState = false;
            validator.SetFocusOnError = true;
        }
    }
}
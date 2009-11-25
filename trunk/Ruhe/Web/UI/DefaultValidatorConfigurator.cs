using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquidSyntax.ForWeb;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Web.UI {
    public class DefaultValidatorConfigurator : IValidatorConfigurator {
        protected virtual void AddValidatorExtender(BaseValidator validator, IInputControl control) {}

        public virtual void ConfigureControl(IInputControl inputControl) {
            foreach (var validator in ((Control) inputControl).FindAll<BaseValidator>()) {
                validator.ValidationGroup = inputControl.ValidationGroup;
                ConfigureValidator(validator, inputControl);
                AddValidatorExtender(validator, inputControl);
            }
        }

        public virtual void ConfigureValidator(BaseValidator validator, IInputControl control) {
            var errorMessage = control.ErrorMessage.TrimEnd('.');
            validator.Controls.Clear();
            var errorIconHoverHelp = errorMessage + ".";
            validator.Controls.Add(new ErrorIcon(errorIconHoverHelp));
            SetDefaultProperties(validator);
            validator.ErrorMessage = errorIconHoverHelp;
        }

        protected virtual void SetDefaultProperties(BaseValidator validator) {
            validator.Display = ValidatorDisplay.Dynamic;
            validator.ForeColor = Color.Empty;
            validator.CssClass = "validation";
            validator.SetFocusOnError = true;
        }
    }
}
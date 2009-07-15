using System.Web.UI.WebControls;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Web.UI {
    public interface IValidatorConfigurator {
        void ConfigureControl(IInputControl inputControl);
        void ConfigureValidator(BaseValidator validator, IInputControl control);
    }
}
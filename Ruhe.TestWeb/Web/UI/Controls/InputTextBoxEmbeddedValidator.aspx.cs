using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ruhe.TestWeb.Web.UI.Controls {
    public partial class InputTextBoxEmbeddedValidator : Page {
        protected void Page_Load(object sender, EventArgs e) {}

        protected void AlwaysFail(object source, ServerValidateEventArgs args) {
            args.IsValid = false;
        }
    }
}
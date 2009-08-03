using System;
using System.Web.UI;

namespace Ruhe.TestWeb.Web.UI.Controls {
    public partial class InputDerivedTypeDropDownListTests : Page {
        protected void Page_Load(object sender, EventArgs e) {
            Change(sender, e);
        }

        protected void Change(object sender, EventArgs e) {
            label.Text = list.SelectedType.Name;
            otherLabel.Text = otherList.SelectedType.Name;
        }
    }
}
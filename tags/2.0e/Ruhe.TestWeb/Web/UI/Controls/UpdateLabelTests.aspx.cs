using System;
using System.Web.UI;

namespace Ruhe.TestWeb.Web.UI.Controls {
    public partial class UpdateLabelTests : Page {
        protected void Page_Load(object sender, EventArgs e) {}

        protected void saveButton_Click(object sender, EventArgs e) {
            proof.Text = "the light";
        }
    }
}
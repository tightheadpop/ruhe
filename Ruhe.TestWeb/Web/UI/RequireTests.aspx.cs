using System;
using System.Web.UI;
using Ruhe.Web.UI;

namespace Ruhe.TestWeb.Web.UI {
    public partial class RequireTests : Page {
        protected void Page_Load(object sender, EventArgs e) {
            Require.DefaultStyleSheet(typeof(Require), "ruhe.css");
        }
    }
}
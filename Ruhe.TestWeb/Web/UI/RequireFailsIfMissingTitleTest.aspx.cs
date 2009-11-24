using System;
using System.Web.UI;
using Ruhe.Web.UI;
using Ruhe.Web.UI.Controls;

namespace Ruhe.TestWeb.Web.UI {
    public partial class RequireFailsIfMissingTitleTest : Page {
        protected void Page_Load(object sender, EventArgs e) {
            Require.StyleSheet(typeof(Require), "ruhe.css");
        }
    }
}
using System;
using System.Web.UI;

namespace Ruhe.Web.UI.Controls {
    public class UpdateLabel : UpdatePanel {
        protected override void OnPreRender(EventArgs e) {
            ScriptManager.RegisterStartupScript(this, GetType(), ClientID,
                                                string.Format("document.getElementById('{0}').style.display = 'inline';", ClientID), true);
            base.OnPreRender(e);
        }
    }
}
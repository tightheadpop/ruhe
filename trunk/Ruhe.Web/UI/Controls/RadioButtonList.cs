using System;

namespace Ruhe.Web.UI.Controls {
    public class RadioButtonList : System.Web.UI.WebControls.RadioButtonList {
        protected override void OnPreRender(EventArgs e) {
            base.OnPreRender(e);
            if (AutoPostBack)
                Page.ClientScript.RegisterStartupScript(
                    GetType(),
                    "postback",
                    string.Format("document.getElementById('{0}_{1}').onclick = function(){{setTimeout(\"__doPostBack(\'ajax$content$list${1}\',\'\')\", 0);}};", ClientID, SelectedIndex), true);
        }
    }
}
using System;
using System.Text.RegularExpressions;

namespace Ruhe.Web.UI.Controls {
    public class RadioButtonList : System.Web.UI.WebControls.RadioButtonList {
        protected override void OnPreRender(EventArgs e) {
            base.OnPreRender(e);
            string postbackReference = Page.ClientScript.GetPostBackEventReference(this, null);
            Match match = Regex.Match(postbackReference, @"\('(?<ClientName>.*?)'");
            string clientName = match.Groups["ClientName"].Value;
            postbackReference = postbackReference.Replace(clientName, clientName + "$" + SelectedIndex);
            if (AutoPostBack)
                Page.ClientScript.RegisterStartupScript(
                    GetType(),
                    ClientID,
                    string.Format("$get('{0}_{1}').onclick = function(){{if (!this.checked) setTimeout(\"{2}\", 0);}};", ClientID, SelectedIndex, postbackReference),
                    true);
        }
    }
}
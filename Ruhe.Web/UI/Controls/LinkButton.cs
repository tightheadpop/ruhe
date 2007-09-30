using System;
using System.Web.UI;

namespace Ruhe.Web.UI.Controls {
    public class LinkButton : System.Web.UI.WebControls.LinkButton {
        private string ButtonClientID {
            get { return ClientID + "_button"; }
        }

        private string ButtonClientName {
            get { return ClientID.Replace("_", ":"); }
        }

        protected override void OnPreRender(EventArgs e) {
            base.OnPreRender(e);
            Page.ClientScript.RegisterStartupScript(GetType(), ClientID + "accessibility",
                                                    String.Format(@"
<script type='text/javascript'>
	document.getElementById('{0}').style.display = '';
	document.getElementById('{1}').style.display = 'none';
</script>", ClientID, ButtonClientID));
        }

        protected override void AddAttributesToRender(HtmlTextWriter writer) {
            Style.Add("display", "none");
            base.AddAttributesToRender(writer);
        }

        protected override void Render(HtmlTextWriter writer) {
            base.Render(writer);
            writer.AddAttribute(HtmlTextWriterAttribute.Id, ButtonClientID);
            writer.AddAttribute(HtmlTextWriterAttribute.Name, ButtonClientName);
            writer.AddAttribute(HtmlTextWriterAttribute.Value, Text);
            writer.AddAttribute(HtmlTextWriterAttribute.Type, "submit");
            writer.RenderBeginTag(HtmlTextWriterTag.Input);
            writer.RenderEndTag();
        }
    }
}
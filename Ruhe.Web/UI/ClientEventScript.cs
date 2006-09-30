using System.Web.UI;

namespace Ruhe.Web.UI {
	public sealed class ClientEventScript {
		private ClientEventScript() {}

		public static string SetFocus(Control control) {
			const string scriptId = "set focus";

			Page page = control.Page;
			if (!page.IsClientScriptBlockRegistered(scriptId)) {
				page.RegisterClientScriptBlock("set focus", @"
<script type='text/javascript' language='javascript'>
function setFocus(id) {
	if (document.getElementById(id) && document.getElementById(id).focus)
		document.getElementById(id).focus();
}
</script>");
			}
			return string.Format("function(){{setFocus('{0}');}}", control.ClientID);
		}
	}
}
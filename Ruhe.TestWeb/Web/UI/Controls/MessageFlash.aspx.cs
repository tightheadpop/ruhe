using System;
using System.Web.UI;
using Ruhe.Web.UI.Controls;

namespace Ruhe.TestWeb.Web.UI.Controls {
    public partial class MessageFlash : Page {
        protected void Page_Load(object sender, EventArgs e) {}

        protected void submit_Click(object sender, EventArgs e) {
            Message.Flash("message flashed", MessageType.Confirmation, "My Header");
            Response.Redirect(Request.Url.ToString());
        }
    }
}
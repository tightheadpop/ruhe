using System;
using System.Web.UI;
using Ruhe.Web.UI.Controls;

public partial class Sample : Page {
    protected void Page_Load(object sender, EventArgs e) {}

    protected void Save(object sender, EventArgs e) {
        Message.Flash("Thank you.", MessageType.Confirmation, "Confirmation");
        Response.Redirect("Sample.aspx");
    }

    protected void Cancel(object sender, EventArgs e) {
        Response.Redirect("Sample.aspx");
    }
}
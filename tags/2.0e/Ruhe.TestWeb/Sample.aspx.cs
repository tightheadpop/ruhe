using System;
using System.Web.UI;

public partial class Sample : Page {
    protected void Page_Load(object sender, EventArgs e) {}

    protected void Save(object sender, EventArgs e) {
        confirmationMessage.Visible = true;
    }

    protected void Cancel(object sender, EventArgs e) {
        Response.Redirect("Sample.aspx");
    }
}
using System;
using System.Web.UI;
using Ruhe.Web.UI;
using Ruhe.Web.UI.Controls;

public partial class Sample : Page {
    protected void Page_Load(object sender, EventArgs e) {}

    protected void Save(object sender, EventArgs e) {
        confirmationMessage.Visible = true;
        ControlUtilities.FindRecursive<IInputControl>(this).ForEach(
            delegate(IInputControl c) { c.Clear(); }
        );
    }

    protected void Cancel(object sender, EventArgs e) {
        Response.Redirect("Sample.aspx");
    }
}
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_UI_Controls_MessageTests : Page {
    protected void addControl_Click(object sender, EventArgs e) {
        Label added = new Label();
        added.ID = "added";
        added.Text = "control added";
        message1.Controls.Add(added);
    }

    private void Page_Load(object sender, EventArgs e) {
        Label replacement = new Label();
        replacement.ID = "replacement";
        replacement.Text = "replacement";
        message5.Controls.Clear();
        message5.Controls.Add(replacement);
    }
}
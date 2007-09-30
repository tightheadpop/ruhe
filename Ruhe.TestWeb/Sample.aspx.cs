using System;
using System.Web.UI;

public partial class Sample : Page {
    protected void Page_Load(object sender, EventArgs e) {}

    protected void saveButton_Click(object sender, EventArgs e) {
        confirmationMessage.Visible = true;
    }
}
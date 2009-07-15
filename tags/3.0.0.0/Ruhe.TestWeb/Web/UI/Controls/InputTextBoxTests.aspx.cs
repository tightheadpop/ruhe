using System;
using System.Web.UI;

public partial class Web_UI_Controls_InputTextBoxTests : Page {
    protected void Page_Load(object sender, EventArgs e) {
        if (Request["Required"] != null) {
            testBox.Required = true;
        }
        if (Request["Regex"] != null) {
            testBox.ValidationExpression = "\\d{3}";
        }
        if (Request["ReadOnly"] != null) {
            testBox.ReadOnly = true;
            testBox.Text = "&test";
        }
        if (Request["AspxRequired"] != null) {
            testBox.Visible = false;
            aspxRequired.Visible = true;
        }
        submitButton.Click += submitButton_Click;
    }

    private void submitButton_Click(object sender, EventArgs e) {
        if (Page.IsValid) {
            if (testBox.Required) {
                result.Text = "past validation";
            }
        }
    }
}
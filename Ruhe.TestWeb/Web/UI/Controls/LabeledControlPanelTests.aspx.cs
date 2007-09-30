using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ruhe.Web.UI.Controls;

public partial class Web_UI_Controls_LabeledControlPanelTests : Page {
    protected void Page_Load(object sender, EventArgs e) {
        if (Request["Above"] != null) {
            panel.LabelPosition = LabelPosition.Above;
        }
        if (Request["MultiLine"] != null) {
            textbox.TextMode = TextBoxMode.MultiLine;
        }
    }
}
using System;
using System.Web.UI;

public partial class Web_UI_Controls_InputDropDownRequired : Page {
    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack) {
            DropDownTest.DataSource = new string[] {"", "a", "b"};
            DropDownTest.DataBind();
        }
    }
}
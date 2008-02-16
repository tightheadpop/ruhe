using System;
using System.Web.UI;

public partial class Web_UI_Controls_InputDropDownPostBackIsolation : Page {
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e) {
        ByProduct1.Text = "did fire";
    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e) {
        ByProduct2.Text = "did fire";
    }

    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack) {
            string[] list1 = {"red", "blue", "green", "all the colors of the rainbow"};
            string[] list2 = {"thumb wars", "thumbtanic", "batthumb", "the blair thumb"};

            DropDownList1.DataSource = list1;
            DropDownList1.DataBind();
            DropDownList2.DataSource = list2;
            DropDownList2.DataBind();
        }
    }
}
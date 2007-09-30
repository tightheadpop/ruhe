using System;
using System.Collections.Specialized;
using System.Web.UI;

public partial class Web_UI_Controls_InputDropDownReadOnly : Page {
    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack) {
            StringCollection strings = new StringCollection();
            strings.Add("&OrgTest");
            readOnlyList.DataSource = strings;
            readOnlyList.DataBind();

            StringCollection strings2 = new StringCollection();
            strings2.Add("Org1");
            strings2.Add("Org2");
            strings2.Add("Org3");
            readOnlyTrueListMultiItem.DataSource = strings2;
            readOnlyTrueListMultiItem.DataBind();

            StringCollection strings3 = new StringCollection();
            strings3.Add("Facility1");
            strings3.Add("Facility2");
            strings3.Add("Facility3");
            readOnlyFalseListMultiItem.DataSource = strings3;
            readOnlyFalseListMultiItem.DataBind();
        }
    }
}
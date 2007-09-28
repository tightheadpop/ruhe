using System;
using System.Web.UI;

public partial class Web_UI_Controls_InputDropDownAutoPostBackDisplay : Page {
	protected void Page_Load(object sender, EventArgs e) {
		firstDropDownList.DataSource = new string[] {"Item 1", "Item 2", "Item 3", "Item 4"};
		firstDropDownList.DataBind();

		secondDropDownList.DataSource = new string[] {"Org1", "Org2", "Org3"};
		secondDropDownList.DataBind();

		thirdDropDownList.DataSource = new string[] {"Third List Item 1", "Third List Item 2", "Third List Item 3", "Third List Item 4"};
		thirdDropDownList.DataBind();

		fourthDropDownList.DataSource = new string[] {"Fourth list Org1"};
		fourthDropDownList.DataBind();
	}

	protected void firstDropDownList_SelectedIndexChanged(object sender, EventArgs e) {
		secondDropDownList.Items.Clear();
		secondDropDownList.DataSource = new String[] {"Second List Item One"};
		secondDropDownList.DataBind();
	}

	protected void thirdDropDownList_SelectedIndexChanged(object sender, EventArgs e) {
		fourthDropDownList.Items.Clear();
		fourthDropDownList.DataSource = new String[] {"Fourth List Item One", "Fourth List Item Two", "Fourth List Item Three", "Fourth List Item Four"};
		fourthDropDownList.DataBind();
	}
}
using System;
using System.Web.UI;

public partial class Web_UI_Controls_LinkButtonTests : Page {
	protected void Page_Load(object sender, EventArgs e) {}

	protected void linkButton_Click(object sender, EventArgs e) {
		target.Text = "clicked";
	}
}
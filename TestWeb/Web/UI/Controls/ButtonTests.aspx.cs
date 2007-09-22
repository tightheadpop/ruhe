using System;
using System.Web.UI;

public partial class Web_UI_Controls_ButtonTests : Page {
	protected void Page_Load(object sender, EventArgs e) {}

	protected void button1_Click(object sender, EventArgs e) {
		result.Text = "this statement should not be reached";
	}

	protected void button2_Click(object sender, EventArgs e) {
		result.Text = "this statement should be reached";
	}
}
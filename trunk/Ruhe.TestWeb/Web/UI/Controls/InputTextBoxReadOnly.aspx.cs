using System;
using System.Web.UI;

public partial class Web_UI_Controls_InputTextBoxReadOnly : Page {
	protected void Page_Load(object sender, EventArgs e) {
		if (!IsPostBack) {
			testBox1.Text = "readonly text";
			testBox2.Text = "readonly test";
		}
	}
}
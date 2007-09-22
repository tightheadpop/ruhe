using System;

public partial class MasterPage : System.Web.UI.MasterPage {
	protected void Page_Load(object sender, EventArgs e) {}

	protected override void OnInit(EventArgs e) {
		base.OnInit(e);
		ID = "master";
	}
}
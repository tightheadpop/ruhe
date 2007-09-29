using System;

namespace Ruhe.TestWeb {
	public partial class Ajax : System.Web.UI.MasterPage {
		protected void Page_Load(object sender, EventArgs e) {}
		protected override void OnInit(EventArgs e) {
			ID = "ajax";
			base.OnInit(e);
		}
	}
}
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ruhe.TestWeb.Web.UI.Controls {
	public class LinkButtonTests : Page {
		protected Ruhe.Web.UI.Controls.LinkButton linkButton;
		protected Label target;

		private void Page_Load(object sender, EventArgs e) {}

		protected override void OnInit(EventArgs e) {
			InitializeComponent();
			base.OnInit(e);
		}

		private void InitializeComponent() {
			Load += new EventHandler(Page_Load);
			linkButton.Click += new EventHandler(linkButton_Click);
		}

		private void linkButton_Click(object sender, EventArgs e) {
			target.Text = "clicked";
		}
	}
}
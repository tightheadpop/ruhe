using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ruhe.Web.UI.Controls;

namespace Ruhe.TestWeb.Web.UI.Controls {
	public class InputTextBoxReadOnly : Page {
		protected InputTextBox testBox1;
		protected InputTextBox testBox2;
		protected Button submitButton;

		private void Page_Load(object sender, EventArgs e) {
			if (!IsPostBack) {
				testBox1.Text = "readonly text";
				testBox2.Text = "readonly test";
			}
		}

		protected override void OnInit(EventArgs e) {
			InitializeComponent();
			base.OnInit(e);
		}

		private void InitializeComponent() {
			Load += new EventHandler(Page_Load);
		}
	}
}
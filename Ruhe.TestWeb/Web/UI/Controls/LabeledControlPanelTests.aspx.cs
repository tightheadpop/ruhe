using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ruhe.Web.UI.Controls;

namespace Ruhe.TestWeb.Web.UI.Controls {
	public class LabeledControlPanelTests : Page {
		protected InputTextBox textbox;
		protected LabeledControlPanel panel;

		private void Page_Load(object sender, EventArgs e) {
			if (Request["Above"] != null) {
				panel.LabelPosition = LabelPosition.Above;
			}
			if (Request["MultiLine"] != null) {
				textbox.TextMode = TextBoxMode.MultiLine;
			}
		}

		#region Web Form Designer generated code

		protected override void OnInit(EventArgs e) {
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.Load += new System.EventHandler(this.Page_Load);
		}

		#endregion
	}
}
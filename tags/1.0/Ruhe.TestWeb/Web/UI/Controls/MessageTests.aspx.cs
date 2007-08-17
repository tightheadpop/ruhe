using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Ruhe.Web.UI.Controls;

namespace Ruhe.TestWeb.Web.UI.Controls {
	public class MessageTestsPage : Page {
		protected Message message1;
		protected HtmlAnchor dummyLink;
		protected Button addControl;
		protected Message message5;

		private void Page_Load(object sender, EventArgs e) {
			Label replacement = new Label();
			replacement.ID = "replacement";
			replacement.Text = "replacement";
			message5.Controls.Clear();
			message5.Controls.Add(replacement);
		}

		private void addControl_Click(object sender, EventArgs e) {
			Label added = new Label();
			added.ID = "added";
			added.Text = "control added";
			message1.Controls.Add(added);
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
			addControl.Click += new EventHandler(addControl_Click);
		}

		#endregion
	}
}
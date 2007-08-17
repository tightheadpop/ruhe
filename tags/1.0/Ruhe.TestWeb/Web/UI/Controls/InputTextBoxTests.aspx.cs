using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Tests.Web.UI.Controls {
	public class InputTextBoxTestsPage : Page {
		protected InputTextBox testBox;
		protected InputTextBox aspxRequired;
		protected Button submitButton;
		protected Label result;

		private void Page_Load(object sender, EventArgs e) {
			if (Request["Required"] != null) {
				testBox.Required = true;
			}
			if (Request["Regex"] != null) {
				testBox.ValidationExpression = "\\d{3}";
			}
			if (Request["ReadOnly"] != null) {
				testBox.ReadOnly = true;
				testBox.Text = "&test";
			}
			if (Request["AspxRequired"] != null) {
				testBox.Visible = false;
				aspxRequired.Visible = true;
			}
			submitButton.Click += new EventHandler(submitButton_Click);
		}

		private void submitButton_Click(object sender, EventArgs e) {
			if (Page.IsValid) {
				if (testBox.Required) {
					result.Text = "past validation";
				}
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
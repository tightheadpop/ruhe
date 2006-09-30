using System;
using System.Web.UI;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Tests.Web.UI.Controls {
	public class InputDropDownRequired : Page {
		protected InputDropDownList DropDownTest;

		private void Page_Load(object sender, EventArgs e) {
			if (!IsPostBack) {
				DropDownTest.DataSource = new string[] {"", "a", "b"};
				DropDownTest.DataBind();
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
using System;
using System.Web.UI;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Tests.Web.UI.Controls {
	/// <summary>
	/// Summary description for InputDropDownListTests.
	/// </summary>
	public class InputDropDownNotRequired : Page {
		protected InputDropDownList DropDownTest;

		private void Page_Load(object sender, EventArgs e) {
			// Put user code to initialize the page here
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
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Tests.Web.UI.Controls {
	public class InputDropDownPostBackIsolation : Page {
		protected InputDropDownList DropDownList1;
		protected InputDropDownList DropDownList2;
		protected TextBox ByProduct1;
		protected TextBox ByProduct2;

		private void Page_Load(object sender, EventArgs e) {
			if (!IsPostBack) {
				string[] list1 = {"red", "blue", "green", "all the colors of the rainbow"};
				string[] list2 = {"thumb wars", "thumbtanic", "batthumb", "the blair thumb"};

				DropDownList1.DataSource = list1;
				DropDownList1.DataBind();
				DropDownList2.DataSource = list2;
				DropDownList2.DataBind();
			}
		}

		private void DropDownList1_SelectedIndexChanged(object sender, EventArgs e) {
			ByProduct1.Text = "did fire";
		}

		private void DropDownList2_SelectedIndexChanged(object sender, EventArgs e) {
			ByProduct2.Text = "did fire";
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
			this.DropDownList1.SelectedIndexChanged += new System.EventHandler(this.DropDownList1_SelectedIndexChanged);
			this.DropDownList2.SelectedIndexChanged += new System.EventHandler(this.DropDownList2_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);
		}

		#endregion
	}
}
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ruhe.TestWeb.Tests.Extensions.AspTesters {
	/// <summary>
	/// Summary description for GridTesterTests.
	/// </summary>
	public class GridTesterTests : Page {
		protected DataGrid grid;

		private void Page_Load(object sender, EventArgs e) {
			if (!IsPostBack) {
				BindGrid();
			}
		}

		private void BindGrid() {
			grid.DataSource = new string[] {"One", "Two", "Three", "Four"};
			grid.DataBind();
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
			this.Load += new EventHandler(this.Page_Load);
			grid.EditCommand += new DataGridCommandEventHandler(grid_EditCommand);
			grid.CancelCommand += new DataGridCommandEventHandler(grid_CancelCommand);
		}

		#endregion

		private void grid_EditCommand(object source, DataGridCommandEventArgs e) {
			grid.EditItemIndex = e.Item.ItemIndex;
			BindGrid();
		}

		private void grid_CancelCommand(object source, DataGridCommandEventArgs e) {
			grid.EditItemIndex = -1;
			BindGrid();
		}
	}
}
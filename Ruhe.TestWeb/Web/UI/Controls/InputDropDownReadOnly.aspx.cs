using System;
using System.Collections.Specialized;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Tests.Web.UI.Controls {
	public class InputDropDownReadOnly : Page {
		protected InputDropDownList readOnlyTrueListMultiItem;
		protected InputDropDownList readOnlyFalseListMultiItem;
		protected ValidationSummary summary;
		protected Button submitButton;
		protected InputDropDownList readOnlyList;

		private void Page_Load(object sender, EventArgs e) {
			if (!IsPostBack) {
				StringCollection strings = new StringCollection();
				strings.Add("&OrgTest");
				readOnlyList.DataSource = strings;
				readOnlyList.DataBind();

				StringCollection strings2 = new StringCollection();
				strings2.Add("Org1");
				strings2.Add("Org2");
				strings2.Add("Org3");
				readOnlyTrueListMultiItem.DataSource = strings2;
				readOnlyTrueListMultiItem.DataBind();

				StringCollection strings3 = new StringCollection();
				strings3.Add("Facility1");
				strings3.Add("Facility2");
				strings3.Add("Facility3");
				readOnlyFalseListMultiItem.DataSource = strings3;
				readOnlyFalseListMultiItem.DataBind();
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
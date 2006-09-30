using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ruhe.Web.UI.Controls;

namespace Ruhe.TestWeb.Web.UI.Controls {
	public class InputNumberTestsPage : Page {
		protected InputNumber inputNumber;
		protected Button submitButton;

		private void Page_Load(object sender, EventArgs e) {
			if (Request["mode"] != null) {
				inputNumber.NumericFormat = (NumericFormat) Enum.Parse(typeof(NumericFormat), Request["mode"], true);
			}
			if (Request["max"] != null) {
				inputNumber.MinimumValue = Request["min"];
				inputNumber.MaximumValue = Request["max"];
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
			this.Load += new EventHandler(this.Page_Load);
		}

		#endregion
	}
}
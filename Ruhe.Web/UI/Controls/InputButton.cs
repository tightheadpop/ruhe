using System.Web.UI.WebControls;
using Ruhe.Common;

namespace Ruhe.Web.UI.Controls {
	public class InputButton : Button, ILabeledControl {
		public InputButton() {}

		#region ILabeledControl Members

		public string LabelText {
			get { return StringUtilities.NullToEmpty((string) ViewState["LabelText"]); }
			set { ViewState["LabelText"] = value; }
		}

		public string FormatText {
			get { return StringUtilities.NullToEmpty((string) ViewState["FormatText"]); }
			set { ViewState["FormatText"] = value; }
		}

		#endregion
	}
}
using System.Web.UI.WebControls;
using Ruhe.Common;

namespace Ruhe.Web.UI.Controls {
	public class InputCheckBox : CheckBox, IInputControl {

		public string DefaultElementClientId {
			get { return ClientID; }
		}

		public string ValidatedControlId {
			get { return ID; }
		}

		public string ErrorMessage {
			get {
				// TODO:  Add InputCheckBox.ErrorMessage getter implementation
				return null;
			}
			set {
				// TODO:  Add InputCheckBox.ErrorMessage setter implementation
			}
		}

		public bool ReadOnly {
			get {
				// TODO:  Add InputCheckBox.ReadOnly getter implementation
				return false;
			}
			set {
				// TODO:  Add InputCheckBox.ReadOnly setter implementation
			}
		}

		public bool Required {
			get {
				// TODO:  Add InputCheckBox.Required getter implementation
				return false;
			}
			set {
				// TODO:  Add InputCheckBox.Required setter implementation
			}
		}

		public bool EnableClientScript {
			get {
				// TODO:  Add InputCheckBox.EnableClientScript getter implementation
				return false;
			}
			set {
				// TODO:  Add InputCheckBox.EnableClientScript setter implementation
			}
		}

		public void Clear() {
			Checked = false;
		}

		public virtual string LabelText {
			get {
				EnsureChildControls();
				return StringUtilities.NullToEmpty((string) ViewState["LabelText"]);
			}
			set {
				EnsureChildControls();
				ViewState["LabelText"] = value;
			}
		}

		public virtual string FormatText {
			get {
				EnsureChildControls();
				return StringUtilities.NullToEmpty((string) ViewState["FormatText"]);
			}
			set {
				EnsureChildControls();
				ViewState["FormatText"] = value;
			}
		}
	}
}
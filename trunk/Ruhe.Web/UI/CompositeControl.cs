using System.ComponentModel;
using System.Web.UI;
using Ruhe.Common;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Web.UI {
	[ToolboxItem(false)]
	public abstract class CompositeControl : Control, ILabeledControl, INamingContainer {
		private string labelText;
		private string formatText;

		public override ControlCollection Controls {
			get {
				EnsureChildControls();
				return base.Controls;
			}
		}

		public string LabelText {
			get { return StringUtilities.NullToEmpty(labelText); }
			set { labelText = value; }
		}

		public string FormatText {
			get { return StringUtilities.NullToEmpty(formatText); }
			set { formatText = value; }
		}
	}
}
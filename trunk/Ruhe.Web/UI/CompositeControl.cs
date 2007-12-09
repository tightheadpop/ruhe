using System.ComponentModel;
using System.Web.UI;
using Ruhe.Common.Utilities;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Web.UI {
    [ToolboxItem(false)]
    public abstract class CompositeControl : Control, ILabeledControl, INamingContainer {
        public override ControlCollection Controls {
            get {
                EnsureChildControls();
                return base.Controls;
            }
        }

        public virtual string LabelText {
            get {
                EnsureChildControls();
                return StringUtilities.NullToEmpty((string)ViewState["LabelText"]);
            }
            set {
                EnsureChildControls();
                ViewState["LabelText"] = value;
            }
        }

        public virtual string FormatText {
            get {
                EnsureChildControls();
                return StringUtilities.NullToEmpty((string)ViewState["FormatText"]);
            }
            set {
                EnsureChildControls();
                ViewState["FormatText"] = value;
            }
        }
    }
}
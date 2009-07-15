using System.ComponentModel;
using System.Web.UI;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Web.UI {
    [ToolboxItem(false)]
    public abstract class CompositeControl : Control, ILabeledControl {
        public override ControlCollection Controls {
            get {
                EnsureChildControls();
                return base.Controls;
            }
        }

        public virtual string FormatText {
            get {
                EnsureChildControls();
                return (string) ViewState["FormatText"];
            }
            set {
                EnsureChildControls();
                ViewState["FormatText"] = value;
            }
        }

        public virtual string LabelText {
            get {
                EnsureChildControls();
                return (string) ViewState["LabelText"];
            }
            set {
                EnsureChildControls();
                ViewState["LabelText"] = value;
            }
        }
    }
}
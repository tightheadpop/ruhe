using System;
using System.Web.UI.WebControls;

namespace Ruhe.Web.UI.Controls {
    public class ControlGroup : PlaceHolder, ILabeledControl, ILayoutContainer {
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

        public bool IsLayoutContainer {
            get {
                EnsureChildControls();
                return Convert.ToBoolean(ViewState["IsLayoutContainer"]);
            }
            set {
                EnsureChildControls();
                ViewState["IsLayoutContainer"] = value;
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
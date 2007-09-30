using System;
using System.Web.UI.WebControls;
using Ruhe.Common;

namespace Ruhe.Web.UI.Controls {
    public class ControlGroup : PlaceHolder, ILabeledControl, ILayoutContainer {
        #region ILabeledControl Members

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

        #endregion

        #region ILayoutContainer Members

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

        #endregion
    }
}
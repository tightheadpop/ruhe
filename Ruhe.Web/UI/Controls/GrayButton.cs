using System;
using Ruhe.Common.Utilities;

namespace Ruhe.Web.UI.Controls {
    public class GrayButton : System.Web.UI.WebControls.Button, ILabeledControl {
        public string LabelText {
            get { return StringUtilities.NullToEmpty((string) ViewState["LabelText"]); }
            set { ViewState["LabelText"] = value; }
        }

        public string FormatText {
            get { return StringUtilities.NullToEmpty((string) ViewState["FormatText"]); }
            set { ViewState["FormatText"] = value; }
        }

        protected override void OnClick(EventArgs e) {
            if (CausesValidation && !Page.IsValid)
                return;
            base.OnClick(e);
        }
    }
}
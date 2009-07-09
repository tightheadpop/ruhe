using System;

namespace Ruhe.Web.UI.Controls {
    public class GrayButton : System.Web.UI.WebControls.Button, ILabeledControl {
        public string FormatText {
            get { return (string) ViewState["FormatText"]; }
            set { ViewState["FormatText"] = value; }
        }

        public string LabelText {
            get { return (string) ViewState["LabelText"]; }
            set { ViewState["LabelText"] = value; }
        }

        protected override void OnClick(EventArgs e) {
            if (CausesValidation && !Page.IsValid)
                return;
            base.OnClick(e);
        }
    }
}
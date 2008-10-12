using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ruhe.Web.UI.Controls {
    public class EncodedLabel : Label, ILabeledControl {
        public EncodedLabel() : this(String.Empty, String.Empty) {}
        public EncodedLabel(string text) : this(text, String.Empty) {}

        public EncodedLabel(string text, string cssClass) {
            Text = text;
            CssClass = cssClass;
        }

        protected override void RenderContents(HtmlTextWriter writer) {
            writer.Write(HttpUtility.HtmlEncode(Text));
        }

        #region ILabeledControl Members

        public string FormatText {
            get {
                EnsureChildControls();
                return (string) ViewState["FormatText"];
            }
            set {
                EnsureChildControls();
                ViewState["FormatText"] = value;
            }
        }

        public string LabelText {
            get {
                EnsureChildControls();
                return (string) ViewState["LabelText"];
            }
            set {
                EnsureChildControls();
                ViewState["LabelText"] = value;
            }
        }

        #endregion
    }
}
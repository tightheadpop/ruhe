using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ruhe.Common;

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

        public string LabelText {
            get {
                EnsureChildControls();
                return StringUtilities.NullToEmpty((string) ViewState["LabelText"]);
            }
            set {
                EnsureChildControls();
                ViewState["LabelText"] = value;
            }
        }

        public string FormatText {
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
    }
}
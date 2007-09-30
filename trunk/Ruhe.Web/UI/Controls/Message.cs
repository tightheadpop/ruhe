using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ruhe.Common;

namespace Ruhe.Web.UI.Controls {
    public enum MessageType {
        Notice,
        Error,
        Confirmation,
        Standard,
        PageHeader
    }

    public class Message : Panel, INamingContainer {
        protected Panel wrapper;
        protected Panel header;

        public Message() {
            Type = MessageType.Standard;
        }

        public string HeaderText {
            get { return StringUtilities.NullToEmpty((string) ViewState["headertext"]); }
            set { ViewState["headertext"] = value; }
        }

        public MessageType Type {
            get { return (MessageType) Enum.Parse(typeof(MessageType), (string) ViewState["type"]); }
            set { ViewState["type"] = value.ToString(); }
        }

        protected override void CreateChildControls() {
            base.CreateChildControls();
            wrapper = new Panel();
            header = new Panel();
        }

        protected override void Render(HtmlTextWriter writer) {
            EnsureChildControls();
            if (HeaderText.Length > 0)
                header.Controls.Add(new LiteralControl(HttpUtility.HtmlEncode(HeaderText)));
            header.Visible = header.HasControls();
            bool bodyIsVisible = Visible && HasControls();
            wrapper.Visible = bodyIsVisible || header.Visible;
            CssClass = "body";

            if (wrapper.Visible) {
                RenderBeginWrapper(writer);
                RenderHeader(writer);
                if (bodyIsVisible)
                    base.Render(writer);
                RenderEndWrapper(writer);
            }
        }

        private void RenderBeginWrapper(HtmlTextWriter writer) {
            wrapper.ID = UniqueID + "_wrapper";
            wrapper.CssClass = Type.ToString().ToLower() + " wrapper";
            wrapper.RenderBeginTag(writer);
        }

        private void RenderEndWrapper(HtmlTextWriter writer) {
            wrapper.RenderEndTag(writer);
        }

        private void RenderHeader(HtmlTextWriter writer) {
            header.ID = UniqueID + "_header";
            header.CssClass = "header";
            header.RenderControl(writer);
        }
    }
}
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
        protected Panel body;
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
            body = new Panel();
            header = new Panel();
        }

        protected override void Render(HtmlTextWriter writer) {
            EnsureChildControls();
            if (HeaderText.Length > 0)
                header.Controls.Add(new LiteralControl(HttpUtility.HtmlEncode(HeaderText)));
            header.Visible = header.HasControls();
            bool bodyIsVisible = Visible && HasControls();
            if (bodyIsVisible || header.Visible) {
                string oldClass = CssClass;
                CssClass += Type.ToString().ToLower() + " wrapper";
                body.CssClass = "body";
                header.CssClass = "header";
                RenderBeginTag(writer);
                RenderHeader(writer);
                if (bodyIsVisible)
                    RenderBody(writer);
                RenderEndTag(writer);
                CssClass = oldClass;
            }
        }

        private void RenderBody(HtmlTextWriter writer) {
            body.ID = UniqueID + "_body";
            body.RenderBeginTag(writer);
            RenderContents(writer);
            body.RenderEndTag(writer);
        }

        private void RenderHeader(HtmlTextWriter writer) {
            header.ID = UniqueID + "_header";
            header.CssClass = "header";
            header.RenderControl(writer);
        }
    }
}
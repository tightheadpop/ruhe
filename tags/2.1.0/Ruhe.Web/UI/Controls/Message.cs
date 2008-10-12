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

        public bool FlashHost {
            get { return Convert.ToBoolean(ViewState["FlashHost"]); }
            set { ViewState["FlashHost"] = value; }
        }

        private FlashTransferObject? FlashMessage {
            get {
                FlashTransferObject? flashMessage = (FlashTransferObject?) Page.Session["Flash"];
                FlashMessage = null;
                return flashMessage;
            }
            set { Page.Session["Flash"] = value; }
        }

        public string HeaderText {
            get { return (string) ViewState["headertext"]; }
            set { ViewState["headertext"] = value; }
        }

        public MessageType Type {
            get { return Reflector.ConvertToEnum<MessageType>(ViewState["type"]); }
            set { ViewState["type"] = value.ToString(); }
        }

        protected override void CreateChildControls() {
            base.CreateChildControls();
            body = new Panel();
            header = new Panel();
        }

        protected override void Render(HtmlTextWriter writer) {
            EnsureChildControls();

            FlashTransferObject? flashMessage = FlashMessage;
            if (FlashHost) {
                if (!flashMessage.HasValue) return;
                Controls.Clear();
                Controls.Add(new LiteralControl(flashMessage.Value.Message));
                if (flashMessage.Value.Type.HasValue)
                    Type = flashMessage.Value.Type.Value;
                if (!string.IsNullOrEmpty(flashMessage.Value.HeaderText))
                    HeaderText = flashMessage.Value.HeaderText;
            }

            if (!string.IsNullOrEmpty(HeaderText))
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

        public static void Flash(string message) {
            Flash(message, null);
        }

        public static void Flash(string message, MessageType? messageType) {
            Flash(message, messageType, null);
        }

        public static void Flash(string message, MessageType? messageType, string headerText) {
            HttpContext context = HttpContext.Current;
            if (context == null)
                throw new InvalidOperationException("Flash can only be used in a web context");

            context.Session["Flash"] = new FlashTransferObject(message, messageType, headerText);
        }

        [Serializable]
        private struct FlashTransferObject {
            public readonly string HeaderText;
            public readonly string Message;
            public MessageType? Type;

            public FlashTransferObject(string message, MessageType? type, string headerText) {
                Message = message;
                Type = type;
                HeaderText = headerText;
            }
        }
    }
}
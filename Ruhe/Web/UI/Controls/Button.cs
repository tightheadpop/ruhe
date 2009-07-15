using System;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquidSyntax;

namespace Ruhe.Web.UI.Controls {
    /// <summary>
    /// This button class supports rich HTML content, limited currently to a single image.
    /// <para>It only raises its Click event when the page is valid, provided this button causes validation.</para>
    /// </summary>
    /// <remarks>
    /// Due to a defect in InternetExplorer, you will need to set validateRequest="false"
    /// in your web.config setting in order to use this class. In IE, the HTML content of the button
    /// is submitted as the value, rather than the 'value' attribute.
    /// </remarks>
    public class Button : GrayButton {
        private string afterAccessKey;
        private string beforeAccessKey;
        private string shortcutCharacter;

        public string ImageUrl {
            get { return (string) ViewState["ImageUrl"]; }
            set { ViewState["ImageUrl"] = value; }
        }

        protected override HtmlTextWriterTag TagKey {
            get { return HtmlTextWriterTag.Button; }
        }

        protected virtual void ConfigureImage(Image image) {
            image.ImageAlign = ImageAlign.AbsMiddle;
            image.Style[HtmlTextWriterStyle.MarginRight] = "5px";
        }

        protected override void OnPreRender(EventArgs e) {
            var match = Regex.Match(Text, @"(.*?)&(\w)(.*)");
            shortcutCharacter = match.Groups[2].Value;
            if (shortcutCharacter.IsNotEmpty()) {
                AccessKey = shortcutCharacter.ToLower();
                beforeAccessKey = match.Groups[1].Value;
                afterAccessKey = match.Groups[3].Value;
            } else {
                AccessKey = string.Empty;
                beforeAccessKey = Text;
                afterAccessKey = string.Empty;
            }
            base.OnPreRender(e);
        }

        protected override void RenderContents(HtmlTextWriter writer) {
            if (ImageUrl.IsNotEmpty()) {
                var image = new Image {ImageUrl = ImageUrl};
                ConfigureImage(image);
                image.RenderControl(writer);
            }
            writer.WriteEncodedText(beforeAccessKey);
            if (AccessKey.IsNotEmpty()) {
                writer.AddStyleAttribute(HtmlTextWriterStyle.TextDecoration, "underline");
                writer.RenderBeginTag(HtmlTextWriterTag.Span);
                writer.WriteEncodedText(shortcutCharacter);
                writer.RenderEndTag();
            }
            writer.WriteEncodedText(afterAccessKey);
        }
    }
}
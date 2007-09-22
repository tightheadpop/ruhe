using System;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ruhe.Common;

namespace Ruhe.Web.UI.Controls {
	public class Button : System.Web.UI.WebControls.Button, ILabeledControl {
		private string beforeAccessKey;
		private string afterAccessKey;

		public string LabelText {
			get { return StringUtilities.NullToEmpty((string) ViewState["LabelText"]); }
			set { ViewState["LabelText"] = value; }
		}

		public string FormatText {
			get { return StringUtilities.NullToEmpty((string) ViewState["FormatText"]); }
			set { ViewState["FormatText"] = value; }
		}

		public string ImageUrl {
			get { return (string) ViewState["ImageUrl"]; }
			set { ViewState["ImageUrl"] = value; }
		}

		protected override HtmlTextWriterTag TagKey {
			get { return HtmlTextWriterTag.Button; }
		}

		protected override void RenderContents(HtmlTextWriter writer) {
			if (StringUtilities.AreNotEmpty(ImageUrl)) {
				Image image = new Image();
				image.ImageUrl = ImageUrl;
				image.RenderControl(writer);
			}
			writer.WriteEncodedText(beforeAccessKey);
			if (StringUtilities.AreNotEmpty(AccessKey)) {
				writer.AddStyleAttribute(HtmlTextWriterStyle.TextDecoration, "underline");
				writer.RenderBeginTag(HtmlTextWriterTag.Span);
				writer.WriteEncodedText(AccessKey);
				writer.RenderEndTag();
			}
			writer.WriteEncodedText(afterAccessKey);
		}

		protected override void OnPreRender(EventArgs e) {
			Match match = Regex.Match(Text, @"(.*?)&(\w)(.*)");
			AccessKey = match.Groups[2].Value;
			if (StringUtilities.AreNotEmpty(AccessKey)) {
				beforeAccessKey = match.Groups[1].Value;
				afterAccessKey = match.Groups[3].Value;
			}
			else {
				AccessKey = string.Empty;
				beforeAccessKey = Text;
				afterAccessKey = string.Empty;
			}
			base.OnPreRender(e);
		}

		protected override void OnClick(EventArgs e) {
			if (CausesValidation && !Page.IsValid)
				return;
			base.OnClick(e);
		}
	}
}
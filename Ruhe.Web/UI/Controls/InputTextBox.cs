using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ruhe.Common;
using Ruhe.Web.UI.Controls.Icons;
using Ruhe.Web.UI.Controls.Validators;

namespace Ruhe.Web.UI.Controls {
	public class InputTextBox : TextBox, IInputControl {
		private RequiredIcon requiredLabel;
		private RequiredFieldValidator requiredValidator;
		private EncodedLabel readOnlyLabel;
		private RegularExpressionValidator regexValidator;

		protected override void CreateChildControls() {
			base.CreateChildControls();
			CreateReadOnlyLabel();
			CreateRequiredLabel();
			CreateRequiredValidator();
			CreateRegexValidator();

			SetDefaults();
		}

		private void SetDefaults() {
			Required = false;
			ReadOnly = false;
			ValidationExpression = String.Empty;
			ErrorMessage = "Please enter a valid value.";
			Width = new Unit(10, UnitType.Em);
		}

		protected override void OnInit(EventArgs e) {
			base.OnInit(e);
			EnsureChildControls();
			AssignIdsToChildControls();
			ValidatorController.InitializeValidators(this);
		}

		public override string ID {
			get { return base.ID; }
			set {
				base.ID = value;
				AssignIdsToChildControls();
			}
		}

		protected virtual void AssignIdsToChildControls() {
			EnsureChildControls();
			requiredLabel.ID = ID + "_requiredLabel";
			requiredValidator.ID = ID + "_requiredValidator";
			readOnlyLabel.ID = ID + "_readOnly";
			regexValidator.ID = ID + "_regexValidator";
		}

		public virtual bool Required {
			get {
				EnsureChildControls();
				return requiredValidator.Enabled;
			}
			set {
				EnsureChildControls();
				requiredValidator.Enabled = requiredValidator.Visible = value;
				requiredLabel.Visible = value;
			}
		}

		public override bool ReadOnly {
			get {
				EnsureChildControls();
				return readOnlyLabel.Visible;
			}
			set {
				EnsureChildControls();
				readOnlyLabel.Visible = value;
			}
		}

		public virtual string ErrorMessage {
			get {
				EnsureChildControls();
				return StringUtilities.NullToEmpty((string) ViewState["ErrorMessage"]);
			}
			set {
				EnsureChildControls();
				ViewState["ErrorMessage"] = value;
			}
		}

		public virtual string ValidationExpression {
			get {
				EnsureChildControls();
				return regexValidator.ValidationExpression;
			}
			set {
				EnsureChildControls();
				regexValidator.ValidationExpression = value;
				regexValidator.Visible = regexValidator.Enabled = (value != String.Empty);
			}
		}

		public override string CssClass {
			get {
				EnsureChildControls();
				return base.CssClass;
			}
			set {
				EnsureChildControls();
				base.CssClass = value;
				readOnlyLabel.CssClass = value;
			}
		}

		public override string Text {
			get {
				EnsureChildControls();
				return base.Text;
			}
			set {
				EnsureChildControls();
				base.Text = value;
				readOnlyLabel.Text = value;
			}
		}

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

		public virtual string DefaultElementClientId {
			get { return ClientID; }
		}

		public virtual string ValidatedControlId {
			get { return ID; }
		}

		public virtual bool EnableClientScript {
			get {
				EnsureChildControls();
				return requiredValidator.EnableClientScript;
			}
			set {
				EnsureChildControls();
				foreach (BaseValidator validator in ControlUtilities.FindControlsRecursive(this, typeof(BaseValidator))) {
					validator.EnableClientScript = value;
				}
			}
		}

		public virtual void Clear() {
			Text = String.Empty;
		}

		public override ControlCollection Controls {
			get {
				EnsureChildControls();
				return base.Controls;
			}
		}

		protected override ControlCollection CreateControlCollection() {
			return new ControlCollection(this);
		}

		protected override void AddParsedSubObject(object obj) {
			if (obj is Control) {
				Controls.Add((Control) obj);
			}
		}

		protected override void Render(HtmlTextWriter writer) {
			EnsureChildControls();
			requiredLabel.Visible = Required && !ReadOnly;
			readOnlyLabel.Text = Text;

			writer.RenderBeginTag(HtmlTextWriterTag.Nobr);
			if (!ReadOnly) {
				base.Render(writer);
			}
			RenderChildren(writer);
			writer.RenderEndTag();
		}

		protected override void AddAttributesToRender(HtmlTextWriter writer) {
			base.AddAttributesToRender(writer);
			if (!WebUtilities.BrowserIsInternetExplorer) {
				writer.AddAttribute(HtmlTextWriterAttribute.Style, "width:" + Width);
			}
			if (!TextMode.Equals(TextBoxMode.MultiLine)) {
				writer.AddAttribute("size", Width.Value.ToString());
			}
			if (MaxLength > 0 && TextMode.Equals(TextBoxMode.MultiLine)) {
				#region Create scripts

				string keyPressScript = @"
if(maxLength && value.length > maxLength-1){
		event.returnValue = false;
		maxLength = parseInt(maxLength);
}";

				string beforePasteScript = @"
if(maxLength)
		event.returnValue = false;";

				string pasteScript = @"
if(maxLength){
	event.returnValue = false;
	var textRange = document.selection.createRange();
	var insertLength = maxLength - value.length + textRange.text.length;
	var textToPaste = window.clipboardData.getData(""Text"").substr(0, insertLength);
	textRange.text = textToPaste;
}";

				#endregion

				writer.AddAttribute("onkeypress", keyPressScript);
				writer.AddAttribute("onbeforepaste", beforePasteScript);
				writer.AddAttribute("onpaste", pasteScript);
				writer.AddAttribute("maxLength", MaxLength.ToString());
			}
		}

		private void CreateRequiredLabel() {
			requiredLabel = new RequiredIcon();
			requiredLabel.EnableViewState = false;
			Controls.Add(new BreakingSpace());
			Controls.Add(requiredLabel);
		}

		private void CreateRequiredValidator() {
			requiredValidator = new RequiredFieldValidator();
			requiredValidator.EnableViewState = false;
			Controls.Add(new BreakingSpace());
			Controls.Add(requiredValidator);
		}

		private void CreateReadOnlyLabel() {
			readOnlyLabel = new EncodedLabel();
			readOnlyLabel.EnableViewState = false;
			Controls.Add(readOnlyLabel);
		}

		private void CreateRegexValidator() {
			regexValidator = new RegularExpressionValidator();
			regexValidator.EnableViewState = false;
			Controls.Add(regexValidator);
		}
	}
}
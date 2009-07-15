using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquidSyntax.ForWeb;
using Ruhe.Configuration;

namespace Ruhe.Web.UI.Controls {
    /// <summary>
    /// TextBox providing built-in validation
    /// </summary>
    public class InputTextBox : TextBox, IInputControl {
        private EncodedLabel readOnlyLabel;
        private RegularExpressionValidator regexValidator;
        private RequiredIcon requiredLabel;
        private RequiredFieldValidator requiredValidator;

        public override ControlCollection Controls {
            get {
                EnsureChildControls();
                return base.Controls;
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

        public virtual string DefaultElementClientId {
            get { return ClientID; }
        }

        public virtual bool EnableClientScript {
            get {
                EnsureChildControls();
                return requiredValidator.EnableClientScript;
            }
            set {
                EnsureChildControls();
                foreach (var validator in this.FindAll<BaseValidator>()) {
                    validator.EnableClientScript = value;
                }
            }
        }

        public virtual string ErrorMessage {
            get {
                EnsureChildControls();
                return (string) ViewState["ErrorMessage"];
            }
            set {
                EnsureChildControls();
                ViewState["ErrorMessage"] = value;
            }
        }

        public virtual string FormatText {
            get {
                EnsureChildControls();
                return (string) ViewState["FormatText"];
            }
            set {
                EnsureChildControls();
                ViewState["FormatText"] = value;
            }
        }

        public override string ID {
            get { return base.ID; }
            set {
                base.ID = value;
                AssignIdsToChildControls();
            }
        }

        public virtual string LabelText {
            get {
                EnsureChildControls();
                return (string) ViewState["LabelText"];
            }
            set {
                EnsureChildControls();
                ViewState["LabelText"] = value;
            }
        }

        /// <summary>
        /// See <see cref="IInputControl.ReadOnly"/>. Gets or sets a value indicating 
        /// whether the contents of the control can be changed.
        /// If true, the <see cref="Text"/> is displayed as a <see cref="Label"/>.
        /// </summary>
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

        public virtual string ValidatedControlId {
            get { return ID; }
        }

        public virtual string ValidationExpression {
            get {
                EnsureChildControls();
                return regexValidator.ValidationExpression;
            }
            set {
                EnsureChildControls();
                regexValidator.ValidationExpression = value;
                regexValidator.Visible = regexValidator.Enabled = !string.IsNullOrEmpty(value);
            }
        }

        public override string ValidationGroup {
            get {
                EnsureChildControls();
                return base.ValidationGroup;
            }
            set {
                EnsureChildControls();
                base.ValidationGroup = value;
                foreach (var validator in this.FindAll<BaseValidator>()) {
                    validator.ValidationGroup = value;
                }
            }
        }

        protected override void AddAttributesToRender(HtmlTextWriter writer) {
            base.AddAttributesToRender(writer);
            if (MaxLength > 0 && TextMode.Equals(TextBoxMode.MultiLine)) {
                writer.AddAttribute("maxlength", MaxLength.ToString());
            }
        }

        protected override void AddParsedSubObject(object obj) {
            if (obj is Control) {
                Controls.Add((Control) obj);
            }
        }

        protected virtual void AssignIdsToChildControls() {
            EnsureChildControls();
            requiredLabel.ID = ID + "_requiredLabel";
            requiredValidator.ID = ID + "_requiredValidator";
            readOnlyLabel.ID = ID + "_readOnly";
            regexValidator.ID = ID + "_regexValidator";
            requiredValidator.ControlToValidate = ID;
            regexValidator.ControlToValidate = ID;
        }

        public virtual void Clear() {
            Text = string.Empty;
        }

        protected override void CreateChildControls() {
            base.CreateChildControls();
            CreateReadOnlyLabel();
            CreateRequiredLabel();
            CreateRequiredValidator();
            CreateRegexValidator();

            SetDefaults();
        }

        protected override ControlCollection CreateControlCollection() {
            return new ControlCollection(this);
        }

        private void CreateReadOnlyLabel() {
            readOnlyLabel = new EncodedLabel {EnableViewState = false};
            Controls.Add(readOnlyLabel);
        }

        private void CreateRegexValidator() {
            regexValidator = new RegularExpressionValidator {EnableViewState = false};
            Controls.Add(regexValidator);
        }

        private void CreateRequiredLabel() {
            requiredLabel = new RequiredIcon {EnableViewState = false};
            Controls.Add(new BreakingSpace());
            Controls.Add(requiredLabel);
        }

        private void CreateRequiredValidator() {
            requiredValidator = new RequiredFieldValidator {EnableViewState = false};
            Controls.Add(new BreakingSpace());
            Controls.Add(requiredValidator);
        }

        protected override void OnInit(EventArgs e) {
            base.OnInit(e);
            EnsureChildControls();
            AssignIdsToChildControls();
            RuheConfiguration.ValidatorConfigurator.ConfigureControl(this);
        }

        protected override void OnPreRender(EventArgs e) {
            base.OnPreRender(e);
            Require.DefaultStyleSheet(typeof(Require), "ruhe.css");
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

        private void SetDefaults() {
            Required = false;
            ReadOnly = false;
            ValidationExpression = string.Empty;
            ErrorMessage = "Please enter a valid value.";
        }
    }
}
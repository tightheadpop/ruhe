using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ruhe.Configuration;

namespace Ruhe.Web.UI.Controls {
    public class InputListBox : ListBox, IInputControl {
        private RequiredIcon requiredLabel;
        private RequiredFieldValidator requiredValidator;

        public override ControlCollection Controls {
            get {
                EnsureChildControls();
                return base.Controls;
            }
        }

        public string DefaultElementClientId {
            get { return ClientID; }
        }

        public bool EnableClientScript {
            get {
                EnsureChildControls();
                return requiredValidator.EnableClientScript;
            }
            set {
                EnsureChildControls();
                requiredValidator.EnableClientScript = value;
            }
        }

        public string ErrorMessage {
            get {
                EnsureChildControls();
                return (string) ViewState["ErrorMessage"];
            }
            set {
                EnsureChildControls();
                ViewState["ErrorMessage"] = value;
            }
        }

        public string FormatText {
            get { return (string) ViewState["FormatText"]; }
            set { ViewState["FormatText"] = value; }
        }

        public string LabelText {
            get { return (string) ViewState["LabelText"]; }
            set { ViewState["LabelText"] = value; }
        }

        public bool ReadOnly {
            get { return !base.Enabled; }
            set { base.Enabled = !value; }
        }

        public bool Required {
            get {
                EnsureChildControls();
                return requiredValidator.Visible;
            }
            set {
                EnsureChildControls();
                requiredLabel.Visible = value;
                requiredValidator.Enabled = requiredValidator.Visible = value;
            }
        }

        public string ValidatedControlId {
            get { return ID; }
        }

        protected virtual void AssignIdsToChildControls() {
            requiredLabel.ID = ID + "_required";
            requiredValidator.ID = ID + "_requiredValidator";
            requiredValidator.ControlToValidate = ID;
        }

        public void BindList(object dataSource, string textField, string valueField) {
            DataSource = dataSource;
            DataTextField = textField;
            DataValueField = valueField;
            DataBind();
        }

        public void BindList(object dataSource) {
            BindList(dataSource, DataTextField, DataValueField);
        }

        public void Clear() {
            foreach (ListItem item in Items) {
                item.Selected = false;
            }
        }

        protected override void CreateChildControls() {
            base.CreateChildControls();
            ChildControlsCreated = true;
            CreateRequiredLabel();
            EnableClientScript = true;
            ErrorMessage = "Please select a value.";
            Required = false;
            ReadOnly = false;
            SelectionMode = ListSelectionMode.Single;
        }

        protected override ControlCollection CreateControlCollection() {
            return new ControlCollection(this);
        }

        private void CreateRequiredLabel() {
            requiredLabel = new RequiredIcon();
            requiredValidator = new RequiredFieldValidator();

            Controls.Add(new BreakingSpace());
            Controls.Add(requiredLabel);
            Controls.Add(new BreakingSpace());
            Controls.Add(requiredValidator);
        }

        protected override void OnInit(EventArgs e) {
            base.OnInit(e);
            EnsureChildControls();
            AssignIdsToChildControls();
            RuheConfiguration.ValidatorConfigurator.ConfigureControl(this);
        }

        protected override void Render(HtmlTextWriter writer) {
            EnsureChildControls();
            writer.RenderBeginTag(HtmlTextWriterTag.Nobr);
            if (!ReadOnly) {
                base.Render(writer);
            }
            RenderChildren(writer);
            writer.RenderEndTag();
        }
    }
}
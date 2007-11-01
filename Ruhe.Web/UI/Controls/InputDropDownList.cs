using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ruhe.Common.Utilities;
using Ruhe.Web.Configuration;

namespace Ruhe.Web.UI.Controls {
    /// <summary>
    /// Extended <see cref="DropDownList"/> that includes built-in validation
    /// and extra features.
    /// <para>A list with only one value is displayed as a <see cref="Label"/>,
    /// giving the user a visual cue that there are no options</para>
    /// </summary>
    public class InputDropDownList : DropDownList, IInputControl {
        private EncodedLabel readOnlyLabel;
        private RequiredIcon requiredLabel;
        private RequiredFieldValidator requiredValidator;

        protected override ControlCollection CreateControlCollection() {
            return new ControlCollection(this);
        }

        public override ControlCollection Controls {
            get {
                EnsureChildControls();
                return base.Controls;
            }
        }

        protected override void OnInit(EventArgs e) {
            base.OnInit(e);
            EnsureChildControls();
            AssignIdsToChildControls();
            ValidatorConfiguratorFactory.Create().Configure(this);
        }

        [DefaultValue(true)]
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

        public virtual void Clear() {
            SelectByValue(String.Empty);
        }

        /// <summary>
        /// Gets or sets a value indicating whether this control should emit
        /// and blank <see cref="ListItem"/> before other items. The blank item
        /// is not displayed unless there is at least one other <see cref="ListItem"/>.
        /// </summary>
        [DefaultValue(false)]
        public bool InitialBlank {
            get {
                EnsureChildControls();
                return Convert.ToBoolean(ViewState["InitialBlank"]);
            }
            set {
                EnsureChildControls();
                ViewState["InitialBlank"] = value;
            }
        }

        /// <summary>
        /// See <see cref="ILabeledControl.FormatText"/>
        /// </summary>
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

        /// <summary>
        /// See <see cref="ILabeledControl.LabelText"/>
        /// </summary>
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

        /// <summary>
        /// Gets or sets the text displayed to the user when the list contains no
        /// <see cref="ListItem"/>s.
        /// </summary>
        public string EmptyText {
            get {
                EnsureChildControls();
                return StringUtilities.NullToEmpty((string) ViewState["EmptyText"]);
            }
            set {
                EnsureChildControls();
                ViewState["EmptyText"] = value;
            }
        }

        /// <summary>
        /// The number of rows to display on-screen.
        /// </summary>
        [DefaultValue(1)]
        public short Size {
            get { return Convert.ToInt16(ViewState["Size"]); }
            set {
                if (value < 1)
                    throw new ArgumentException("Size must be greater than or equal to 1.");
                ViewState["Size"] = value;
            }
        }

        /// <summary>
        /// See <see cref="IInputControl.ValidatedControlId"/>
        /// </summary>
        public string ValidatedControlId {
            get { return ID; }
        }

        /// <summary>
        /// Selects the first <see cref="ListItem"/> with a 
        /// <see cref="ListItem.Value"/> equal to <c>value</c>.
        /// </summary>
        /// <param name="value">The integer value of the <see cref="ListItem"/> to select</param>
        public void SelectByValue(int value) {
            SelectByValue(Convert.ToString(value));
        }

        /// <summary>
        /// Selects the first <see cref="ListItem"/> with a 
        /// <see cref="ListItem.Value"/> equal to <c>value</c>.
        /// </summary>
        /// <param name="value">The long value of the <see cref="ListItem"/> to select</param>
        public void SelectByValue(long value) {
            SelectByValue(Convert.ToString(value));
        }

        /// <summary>
        /// Selects the first <see cref="ListItem"/> with a 
        /// <see cref="ListItem.Value"/> equal to <c>value</c>.
        /// </summary>
        /// <param name="value">The <see cref="Guid"/> value of the <see cref="ListItem"/> to select</param>
        public void SelectByValue(Guid value) {
            SelectByValue(Convert.ToString(value));
        }

        /// <summary>
        /// Selects the first <see cref="ListItem"/> with a 
        /// <see cref="ListItem.Value"/> equal to <c>value</c>.
        /// </summary>
        /// <param name="value">The string value of the <see cref="ListItem"/> to select</param>
        public void SelectByValue(string value) {
            SelectedIndex = Items.IndexOf(Items.FindByValue(value));
        }

        /// <summary>
        /// Selects the first <see cref="ListItem"/> with 
        /// <see cref="ListItem.Text"/> equal to <c>text</c>.
        /// </summary>
        /// <param name="text">The text of the <see cref="ListItem"/> to select</param>
        public void SelectByText(string text) {
            SelectedIndex = Items.IndexOf(Items.FindByText(text));
        }

        /// <summary>
        /// Gets or sets the currently selected <see cref="ListItem"/>
        /// based on its <see cref="ListItem.Text"/>.
        /// </summary>
        public string SelectedText {
            get {
                string result = String.Empty;
                if (SelectedItem != null) {
                    result = SelectedItem.Text;
                }
                return result;
            }

            set { SelectByText(value); }
        }

        /// <summary>
        /// Convenience method for binding a datasource to the control
        /// </summary>
        /// <param name="dataSource">the datasource to assign to <see cref="BaseDataBoundControl.DataSource"/></param>
        /// <param name="textField">the name of the <see cref="ListControl.DataTextField"/> to use in binding</param>
        /// <param name="valueField">the name of the <see cref="ListControl.DataValueField"/> to use in binding</param>
        public virtual void BindList(object dataSource, string textField, string valueField) {
            DataSource = dataSource;
            DataTextField = textField;
            DataValueField = valueField;
            DataBind();
        }

        /// <summary>
        /// Convenience method for binding a datasource to the control
        /// </summary>
        /// <param name="dataSource">the datasource to assign to <see cref="BaseDataBoundControl.DataSource"/></param>
        public virtual void BindList(object dataSource) {
            BindList(dataSource, DataTextField, DataValueField);
        }

        /// <summary>
        /// Adds another <see cref="ListItem"/> to the dropdown as the first item.
        /// </summary>
        /// <param name="initialValue">the <see cref="ListItem.Text"/> and <see cref="ListItem.Value"/> of the <see cref="ListItem"/></param>
        /// <param name="selected">whether the item is selected initially</param>
        public void AddInitialValueToList(string initialValue, bool selected) {
            AddInitialValueToList(initialValue, initialValue, selected);
        }

        /// <summary>
        /// Adds another <see cref="ListItem"/> to the dropdown as the first item.
        /// </summary>
        /// <param name="initialText">the <see cref="ListItem.Text"/> of the <see cref="ListItem"/></param>
        /// <param name="initialValue">the <see cref="ListItem.Value"/> of the <see cref="ListItem"/></param>
        /// <param name="selected">whether the item is selected initially</param>
        public void AddInitialValueToList(string initialText, string initialValue, bool selected) {
            ListItem item = new ListItem(initialText, initialValue);
            Items.Insert(0, item);
            if (selected) {
                SelectByValue(initialValue);
            }
        }

        public string ErrorMessage {
            get {
                EnsureChildControls();
                return StringUtilities.NullToEmpty((string) ViewState["ErrorMessage"]);
            }
            set {
                EnsureChildControls();
                ViewState["ErrorMessage"] = value;
            }
        }

        /// <summary>
        /// See <see cref="IInputControl.ReadOnly"/>. When true, the <see cref="SelectedText"/>
        /// is rendered as a <see cref="Label"/>.
        /// </summary>
        [DefaultValue(false)]
        public bool ReadOnly {
            get {
                EnsureChildControls();
                return Convert.ToBoolean(ViewState["ReadOnly"]) ||
                       Items.Count == 1 ||
                       Items.Count == 0;
            }
            set {
                EnsureChildControls();
                ViewState["ReadOnly"] = value;
            }
        }

        [DefaultValue(false)]
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

        protected override void CreateChildControls() {
            base.CreateChildControls();
            ChildControlsCreated = true;
            CreateReadOnlyLabel();
            CreateRequiredLabel();
            EnableClientScript = true;
            ErrorMessage = "Please select a value.";
            Required = false;
            ReadOnly = false;
        }

        protected override void AddAttributesToRender(HtmlTextWriter writer) {
            base.AddAttributesToRender(writer);
            if (Size > 1) {
                writer.AddAttribute(HtmlTextWriterAttribute.Size, Size.ToString());
            }
        }

        public string DefaultElementClientId {
            get { return ClientID; }
        }

        protected override void OnPreRender(EventArgs e) {
            base.OnPreRender(e);
            if (InitialBlank && (Items.Count > 0 && Items[0].Value.Length > 0)) {
                AddInitialValueToList(String.Empty, false);
            }
            SynchronizeLabels();
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

        private void AssignIdsToChildControls() {
            string baseId = ID + "_";
            requiredLabel.ID = baseId + "required";
            readOnlyLabel.ID = baseId + "readOnly";
            requiredValidator.ID = baseId + "requiredValidator";
        }

        private void CreateReadOnlyLabel() {
            readOnlyLabel = new EncodedLabel();
            Controls.Add(readOnlyLabel);
        }

        private void CreateRequiredLabel() {
            requiredLabel = new RequiredIcon();
            requiredValidator = new RequiredFieldValidator();

            Controls.Add(new BreakingSpace());
            Controls.Add(requiredLabel);
            Controls.Add(new BreakingSpace());
            Controls.Add(requiredValidator);
        }

        private void SynchronizeLabels() {
            readOnlyLabel.Visible = ReadOnly;
            requiredLabel.Visible = !ReadOnly && Required;
            if (IsEmpty)
                readOnlyLabel.Text = EmptyText;
            else
                readOnlyLabel.Text = SelectedText;
        }

        public bool IsEmpty {
            get { return Items.Count == 0; }
        }
    }
}
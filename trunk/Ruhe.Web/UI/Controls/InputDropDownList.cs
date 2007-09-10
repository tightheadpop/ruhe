using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ruhe.Common;
using Ruhe.Web.UI.Controls.Icons;

namespace Ruhe.Web.UI.Controls {
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
			DefaultValidatorConfigurator.ConfigureValidators(this);
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

		[DefaultValue(true)]
		public bool IsSingleItemReadOnly {
			get {
				EnsureChildControls();
				return Convert.ToBoolean(ViewState["IsSingleItemReadOnly"]);
			}
			set {
				EnsureChildControls();
				ViewState["IsSingleItemReadOnly"] = value;
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
				if (value < 1) throw new ArgumentOutOfRangeException("Size", "Size must be greater than or equal to 1.");
				ViewState["Size"] = value;
			}
		}

		public string ValidatedControlId {
			get { return ID; }
		}

		public void SelectByValue(int value) {
			SelectByValue(Convert.ToString(value));
		}

		public void SelectByValue(string value) {
			SelectedIndex = Items.IndexOf(Items.FindByValue(value));
		}

		public void SelectByValue(Guid value) {
			SelectByValue(value.ToString());
		}

		public void SelectByText(string text) {
			SelectedIndex = Items.IndexOf(Items.FindByText(text));
		}

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

		public virtual void BindList(object dataSource, string textField, string valueField) {
			DataSource = dataSource;
			DataTextField = textField;
			DataValueField = valueField;
			DataBind();
		}

		public virtual void BindList(object dataSource) {
			BindList(dataSource, DataTextField, DataValueField);
		}

		public void AddInitialValueToList(string initialValue, bool selected) {
			AddInitialValueToList(initialValue, initialValue, selected);
		}

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

		[DefaultValue(false)]
		public bool ReadOnly {
			get {
				EnsureChildControls();
				return Convert.ToBoolean(ViewState["ReadOnly"]) ||
				       Items.Count == 1 && IsSingleItemReadOnly ||
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
			IsSingleItemReadOnly = true;
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
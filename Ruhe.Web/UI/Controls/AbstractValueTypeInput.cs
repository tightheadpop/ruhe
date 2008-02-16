using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ruhe.Web.UI.Controls {
    /// <summary>
    /// Base class providing support for converting user input into a specified value type.
    /// </summary>
    /// <typeparam name="T">A value type (struct) that represents user input</typeparam>
    public abstract class AbstractValueTypeInput<T> : InputTextBox where T : struct {
        private CompareValidator compareValidator;
        private RangeValidator rangeValidator;
        protected abstract string KeystrokeFilter { get; }

        /// <summary>
        /// Gets or sets the maximum value of type T for user input
        /// </summary>
        public virtual T? MaximumValue {
            get {
                EnsureChildControls();
                return Adapt(rangeValidator.MaximumValue);
            }
            set {
                EnsureChildControls();
                if (value.HasValue) {
                    rangeValidator.MaximumValue = Adapt(value);
                    rangeValidator.Visible = true;
                    compareValidator.Visible = false;
                } else {
                    rangeValidator.Visible = false;
                    compareValidator.Visible = true;
                }
            }
        }

        /// <summary>
        /// Gets or sets the minimum value of type T for user input
        /// </summary>
        public virtual T? MinimumValue {
            get {
                EnsureChildControls();
                return Adapt(rangeValidator.MinimumValue);
            }
            set {
                EnsureChildControls();
                if (value.HasValue) {
                    rangeValidator.MinimumValue = Adapt(value);
                    rangeValidator.Visible = true;
                    compareValidator.Visible = false;
                } else {
                    rangeValidator.Visible = false;
                    compareValidator.Visible = true;
                }
            }
        }

        protected abstract ValidationDataType ValidationDataType { get; }

        /// <summary>
        /// Gets or sets the typed value for user input
        /// </summary>
        public virtual T? Value {
            get { return Adapt(Text); }
            set { Text = value.HasValue ? Adapt(value) : string.Empty; }
        }

        protected virtual T? Adapt(string value) {
            return string.IsNullOrEmpty(value) ? null : (T?) Convert.ChangeType(value, typeof(T));
        }

        protected virtual string Adapt(T? value) {
            return value.ToString();
        }

        protected override void AssignIdsToChildControls() {
            base.AssignIdsToChildControls();
            compareValidator.ID = ID + "_compare";
            rangeValidator.ID = ID + "_range";
            compareValidator.ControlToValidate = ID;
            rangeValidator.ControlToValidate = ID;
        }

        protected override void CreateChildControls() {
            base.CreateChildControls();
            CreateNumericValidator();
            CreateRangeValidator();
            rangeValidator.Type =
                compareValidator.Type = ValidationDataType;
        }

        private void CreateNumericValidator() {
            compareValidator = new CompareValidator();
            compareValidator.Operator = ValidationCompareOperator.DataTypeCheck;
            Controls.Add(compareValidator);
        }

        private void CreateRangeValidator() {
            rangeValidator = new RangeValidator();
            rangeValidator.Visible = false;
            Controls.Add(rangeValidator);
        }

        protected override void OnPreRender(EventArgs e) {
            base.OnPreRender(e);
            RegisterClientScript();
        }

        private void RegisterClientScript() {
            if (Visible && !ReadOnly) {
                Page.ClientScript.RegisterClientScriptResource(typeof(RuheScriptReference), "Ruhe.Web.Resources.ruhe.js");
                Page.ClientScript.RegisterStartupScript(GetType(), ClientID, string.Format(@"
$get('{0}').onkeypress = Ruhe_KeyPressFilter({1});
", ClientID, KeystrokeFilter), true);
            }
        }

        protected override void Render(HtmlTextWriter writer) {
            writer.RenderBeginTag(HtmlTextWriterTag.Nobr);
            base.Render(writer);
            writer.RenderEndTag();
        }
    }
}
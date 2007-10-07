using System;
using System.Web.UI.WebControls;

namespace Ruhe.Web.UI.Controls {
    public abstract class AbstractValueTypeInput<T> : InputTextBox where T : struct {
        private CompareValidator compareValidator;
        private RangeValidator rangeValidator;

        public virtual Nullable<T> Value {
            get { return Text == string.Empty ? null : (T?) Convert.ChangeType(Text, typeof(T)); }
            set { Text = value.HasValue ? value.ToString() : string.Empty; }
        }

        public virtual Nullable<T> MinimumValue {
            get {
                EnsureChildControls();
                return (T?) Convert.ChangeType(rangeValidator.MinimumValue, typeof(T));
            }
            set {
                EnsureChildControls();
                if (value.HasValue) {
                    rangeValidator.MinimumValue = value.ToString();
                    rangeValidator.Visible = true;
                    compareValidator.Visible = false;
                }
                else {
                    rangeValidator.MinimumValue = string.Empty;
                    rangeValidator.Visible = false;
                    compareValidator.Visible = true;
                }
            }
        }

        public virtual Nullable<T> MaximumValue {
            get {
                EnsureChildControls();
                return (T?) Convert.ChangeType(rangeValidator.MaximumValue, typeof(T));
            }
            set {
                EnsureChildControls();
                if (value.HasValue) {
                    rangeValidator.MaximumValue = value.ToString();
                    rangeValidator.Visible = true;
                    compareValidator.Visible = false;
                }
                else {
                    rangeValidator.MaximumValue = string.Empty;
                    rangeValidator.Visible = false;
                    compareValidator.Visible = true;
                }
            }
        }

        protected override void CreateChildControls() {
            base.CreateChildControls();
            CreateNumericValidator();
            CreateRangeValidator();
            rangeValidator.Type =
                compareValidator.Type = ValidationDataType;
        }

        protected abstract ValidationDataType ValidationDataType { get; }

        protected override void AssignIdsToChildControls() {
            base.AssignIdsToChildControls();
            compareValidator.ID = ID + "_compare";
            rangeValidator.ID = ID + "_range";
        }

        private void CreateNumericValidator() {
            compareValidator = new CompareValidator();
            compareValidator.Operator = ValidationCompareOperator.DataTypeCheck;
            compareValidator.ID = "compare";
            Controls.Add(compareValidator);
        }

        private void CreateRangeValidator() {
            rangeValidator = new RangeValidator();
            rangeValidator.Visible = false;
            rangeValidator.ID = "range";
            Controls.Add(rangeValidator);
        }

        protected override void OnPreRender(EventArgs e) {
            base.OnPreRender(e);
            RegisterClientScript();
        }

        private void RegisterClientScript() {
            Page.ClientScript.RegisterClientScriptResource(GetType(), "Ruhe.Web.Resources.ruhe.js");
            Page.ClientScript.RegisterStartupScript(GetType(), ClientID, string.Format(@"
var {0} = document.getElementById('{0}');
{0}.FILTER = {1};
{0}.onkeypress = Ruhe_KeyPressFilter;
", ClientID, KeystrokeFilter), true);
        }

        protected abstract string KeystrokeFilter { get; }
    }
}
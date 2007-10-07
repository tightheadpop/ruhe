using System;
using System.Web.UI.WebControls;

namespace Ruhe.Web.UI.Controls {
    public abstract class AbstractValueTypeInput<T> : InputTextBox where T : struct {
        private CompareValidator compareValidator;
        private RangeValidator rangeValidator;

        public virtual Nullable<T> Value {
            get { return Convert(Text); }
            set { Text = value.HasValue ? Convert(value) : string.Empty; }
        }

        public virtual Nullable<T> MinimumValue {
            get {
                EnsureChildControls();
                return Convert(rangeValidator.MinimumValue);
            }
            set {
                EnsureChildControls();
                if (value.HasValue) {
                    rangeValidator.MinimumValue = Convert(value);
                    rangeValidator.Visible = true;
                    compareValidator.Visible = false;
                }
                else {
                    rangeValidator.Visible = false;
                    compareValidator.Visible = true;
                }
            }
        }

        public virtual Nullable<T> MaximumValue {
            get {
                EnsureChildControls();
                return Convert(rangeValidator.MaximumValue);
            }
            set {
                EnsureChildControls();
                if (value.HasValue) {
                    rangeValidator.MaximumValue = Convert(value);
                    rangeValidator.Visible = true;
                    compareValidator.Visible = false;
                }
                else {
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

        protected virtual T? Convert(string value) {
            return value == string.Empty ? null : (T?)System.Convert.ChangeType(value, typeof(T));
        }

        protected virtual string Convert(T? value) {
            return value.ToString();
        }

    }
}
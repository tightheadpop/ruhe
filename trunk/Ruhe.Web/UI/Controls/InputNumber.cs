using System;
using System.Web.UI.WebControls;

namespace Ruhe.Web.UI.Controls {
    public enum NumericFormat {
        Integer,
        Double
    }

    public class InputNumber : InputTextBox {
        private CompareValidator numericValidator;
        private RangeValidator rangeValidator;

        protected override void CreateChildControls() {
            base.CreateChildControls();
            CreateNumericValidator();
            CreateRangeValidator();
            NumericFormat = NumericFormat.Double;
        }

        protected override void AssignIdsToChildControls() {
            base.AssignIdsToChildControls();
            numericValidator.ID = ID + "_numericValidator";
            rangeValidator.ID = ID + "_rangeValidator";
        }

        private void CreateNumericValidator() {
            numericValidator = new CompareValidator();
            numericValidator.Operator = ValidationCompareOperator.DataTypeCheck;
            numericValidator.ID = "numericValidator";
            Controls.Add(numericValidator);
        }

        private void CreateRangeValidator() {
            rangeValidator = new RangeValidator();
            rangeValidator.Visible = false;
            rangeValidator.Type = ValidationDataType.Double;
            rangeValidator.ID = "rangeValidator";
            Controls.Add(rangeValidator);
        }

        public NumericFormat NumericFormat {
            get {
                EnsureChildControls();
                return (NumericFormat) Enum.Parse(typeof(NumericFormat), numericValidator.Type.ToString());
            }
            set {
                EnsureChildControls();
                rangeValidator.Type =
                    numericValidator.Type = (ValidationDataType) Enum.Parse(typeof(ValidationDataType), value.ToString());
            }
        }

        public string MinimumValue {
            get {
                EnsureChildControls();
                return rangeValidator.MinimumValue;
            }
            set {
                EnsureChildControls();
                if (value != String.Empty && value != null) {
                    rangeValidator.MinimumValue = value.ToString();
                    rangeValidator.Visible = true;
                    numericValidator.Visible = false;
                }
                else {
                    rangeValidator.Visible = false;
                    numericValidator.Visible = true;
                }
            }
        }

        public string MaximumValue {
            get {
                EnsureChildControls();
                return rangeValidator.MaximumValue;
            }
            set {
                EnsureChildControls();
                if (value != String.Empty && value != null) {
                    rangeValidator.MaximumValue = value.ToString();
                    rangeValidator.Visible = true;
                    numericValidator.Visible = false;
                }
                else {
                    rangeValidator.Visible = false;
                    numericValidator.Visible = true;
                }
            }
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
", ClientID, GetKeystrokeFilter()), true);
        }

        private string GetKeystrokeFilter() {
            if (NumericFormat == NumericFormat.Integer) {
                return @"/\d/";
            }
            return @"
	function(input){
		if(input.value.indexOf('.') >= 0)
			return /[\d]/;
		else
			return /[\d.]/;
	}";
        }
    }
}
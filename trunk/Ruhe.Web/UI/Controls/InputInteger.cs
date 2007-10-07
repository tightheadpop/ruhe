using System;
using System.Web.UI.WebControls;

namespace Ruhe.Web.UI.Controls {
    public class InputInteger : InputTextBox {
        private CompareValidator numericValidator;
        private RangeValidator rangeValidator;

        protected override void CreateChildControls() {
            base.CreateChildControls();
            CreateNumericValidator();
            CreateRangeValidator();
            rangeValidator.Type =
                numericValidator.Type = ValidationDataType.Integer;
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
            rangeValidator.ID = "rangeValidator";
            Controls.Add(rangeValidator);
        }

        public string MinimumValue {
            get {
                EnsureChildControls();
                return rangeValidator.MinimumValue;
            }
            set {
                EnsureChildControls();
                if (value != String.Empty && value != null) {
                    rangeValidator.MinimumValue = value;
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
                    rangeValidator.MaximumValue = value;
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
", ClientID, @"/\d/"), true);
        }

    }
}
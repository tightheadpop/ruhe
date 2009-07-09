using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ruhe.Utilities;

namespace Ruhe.Web.UI.Controls {
    /// <summary>
    /// Requires that at least one control within a group has input.
    /// </summary>
    public class OrGroupValidator : BaseValidator {
        public string[] GroupToValidate {
            get {
                EnsureChildControls();
                return (string[]) ViewState["GroupToValidate"];
            }
            set {
                EnsureChildControls();
                ViewState["GroupToValidate"] = value;
                ControlToValidate = value.First().TrimToEmpty();
            }
        }

        protected override bool EvaluateIsValid() {
            bool result = false;

            foreach (string controlId in GroupToValidate) {
                result |= GetControlValidationValue(controlId.Trim()).Trim() != string.Empty;
            }
            return result;
        }

        protected string GetControlGroupRenderID(string[] names) {
            DelimitedStringBuilder clientIdList = new DelimitedStringBuilder(",");
            foreach (string controlName in names) {
                Control control = ControlUtilities.FindRecursive(Page, controlName);
                if (control != null) {
                    clientIdList.Append(control.ClientID);
                }
            }
            return clientIdList.ToString();
        }

        protected override void OnPreRender(EventArgs args) {
            base.OnPreRender(args);
            Page.ClientScript.RegisterClientScriptResource(typeof(RuheScriptReference), "Ruhe.Web.Resources.ruhe.js");
            Page.ClientScript.RegisterExpandoAttribute(ClientID, "evaluationfunction", "Ruhe_OrGroupValidatorEvaluateIsValid");
            if (GroupToValidate.Length > 0) {
                Page.ClientScript.RegisterExpandoAttribute(ClientID, "grouptovalidate", GetControlGroupRenderID(GroupToValidate));
            }
        }
    }
}
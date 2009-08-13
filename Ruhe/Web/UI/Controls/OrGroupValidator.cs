using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquidSyntax;
using LiquidSyntax.ForWeb;

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
            var result = false;
            foreach (var controlId in GroupToValidate) {
                result |= GetControlValidationValue(controlId.Trim()).Trim() != string.Empty;
            }
            return result;
        }

        protected string GetControlGroupRenderID(string[] names) {
            var clientIdList = new DelimitedStringBuilder(",");
            foreach (var controlName in names) {
                var control = Page.FindFirst<Control>(c => c.ID == controlName);
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
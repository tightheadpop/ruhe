using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ruhe.Common;

namespace Ruhe.Web.UI.Controls.Validators {
	public class OrGroupValidator : BaseValidator {
		public string GroupToValidate {
			get { return StringUtilities.NullToEmpty((string) ViewState["GroupToValidate"]); }
			set {
				string[] controlIds = StringUtilities.NullToEmpty(value).Split(',');
				if (controlIds.Length < 2) {
					throw new ArgumentException("You must specify at least two controls per group.", "GroupToValidate");
				}
				ViewState["GroupToValidate"] = value;
				ControlToValidate = controlIds[0].Trim();
			}
		}

		protected override bool EvaluateIsValid() {
			bool result = false;

			foreach (string controlId in GroupToValidate.Split(',')) {
				result |= GetControlValidationValue(controlId.Trim()).Trim() != string.Empty;
			}
			return result;
		}

		protected override void AddAttributesToRender(HtmlTextWriter writer) {
			base.AddAttributesToRender(writer);
			if (RenderUplevel) {
				writer.AddAttribute("evaluationfunction", "OrGroupValidatorEvaluateIsValid");
			}
			if (GroupToValidate.Length > 0) {
				writer.AddAttribute("grouptovalidate", GetControlGroupRenderID(GroupToValidate));
			}
		}

		protected override void OnPreRender(EventArgs args) {
			base.OnPreRender(args);

			if (RenderUplevel) {
				if (!Page.IsClientScriptBlockRegistered("OrGroupValidation")) {
					Page.RegisterClientScriptBlock("OrGroupValidation",
					                               @"
function OrGroupValidatorEvaluateIsValid(validator)
{
	controlList = validator.grouptovalidate.split(',');
	for (i = 0; i < controlList.length; i++) {
		control = controlList[i];
		
		//radiobuttons & checkboxes
		if (
		 (document.getElementById(control).checked) 
		
			 || 
		
			//dropdowns && listBoxes
			(typeof document.getElementById(control).selectedIndex != 'undefined' &&
			 document.getElementById(control).options[document.getElementById(control).selectedIndex].value.length > 0)
			 &&  (document.getElementById(control).type == 'select-one' || document.getElementById(control).type == 'select-multiple') 
			 
			 ||
			
		
			 //textboxes
			 ((typeof document.getElementById(control).value != 'undefined') 
			 && (document.getElementById(control).value.length > 0) 
			 && (document.getElementById(control).getAttribute('type') == 'text'))
			 
			 //custom controls
			|| 
			((document.getElementById(control).getAttribute('ValidatedValue') != null) && 
			(document.getElementById(control).getAttribute('ValidatedValue').length > 0))) {
			 
			 
			return (true);
			
			
		}	
	}
	return (false);
}

");
				}
			}
		}

		protected string GetControlGroupRenderID(string name) {
			DelimitedStringBuilder clientIdList = new DelimitedStringBuilder(",");
			foreach (string controlName in name.Split(',')) {
				Control control = ControlUtilities.FindControlRecursive(Page, controlName);
				if (control != null) {
					clientIdList.Append(control.ClientID);
				}
			}
			return clientIdList.ToString();
		}
	}
}
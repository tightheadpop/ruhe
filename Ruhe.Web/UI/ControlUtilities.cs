using System;
using System.Collections;
using System.IO;
using System.Web;
using System.Web.UI;

namespace Ruhe.Web.UI {
	public sealed class ControlUtilities {
		private ControlUtilities() {}

		public static string GetHtml(Control control) {
			StringWriter stringWriter = new StringWriter();
			HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
			control.RenderControl(htmlTextWriter);
			return stringWriter.ToString();
		}

		public static Control FindControlRecursive(Control parent, string childId) {
			if (parent.ID == childId)
				return parent;
			foreach (Control child in parent.Controls) {
				Control result = FindControlRecursive(child, childId);
				if (result != null)
					return result;
			}
			return null;
		}

		public static ArrayList FindControlsRecursive(Control parent, Type childTypeToFind) {
			ArrayList result = new ArrayList();
			if (childTypeToFind.IsInstanceOfType(parent)) {
				result.Add(parent);
			}
			foreach (Control child in parent.Controls) {
				result.AddRange(FindControlsRecursive(child, childTypeToFind));
			}
			return result;
		}

		public static string GetRandomName() {
			return "x" + Guid.NewGuid().ToString().Replace("-", String.Empty);
		}

		/// <summary>
		/// Adds an event handler (functionReference) to the control for the 
		/// given event.  Do not assume that any event listeners will fire 
		/// in a specific order.
		/// </summary>
		/// <param name="control">The control that requires an event handler</param>
		/// <param name="eventName">The event the functionReference will handle</param>
		/// <param name="functionReference">The function name or anonymous function
		/// that handles the event.  The "this" keyword is not valid in the function.</param>
		public static void AddClientEventListener(Control control, ClientEvent eventName, string functionReference) {
			string clientId = control.ClientID;
			string clientEventName = eventName.ToString().ToLower();

			#region Client Script

			const string scriptKey = "AddEventListener";
			if (!control.Page.ClientScript.IsClientScriptBlockRegistered(typeof(ControlUtilities), scriptKey)) {
				string addEventListenerScript = @"
<script type='text/javascript' language='javascript'>
function AddEventListener(controlId, eventName, listenerAction) {
	var control = document.getElementById(controlId);
	if (control.attachEvent) {
		control.attachEvent(eventName.toLowerCase(), listenerAction);
	}
	else if (control.addEventListener) {
		control.addEventListener(eventName.toLowerCase().replace(/^on/, ''), listenerAction, false);
	}
}
</script>";
				control.Page.ClientScript.RegisterClientScriptBlock(typeof(ControlUtilities), scriptKey, addEventListenerScript);
			}

			#endregion

			string startUpScript = string.Format(@"
				<script type='text/javascript' language='javascript'>
					AddEventListener('{0}', '{1}', {2});
				</script>",
			                                     clientId,
			                                     clientEventName,
			                                     functionReference);
			control.Page.ClientScript.RegisterStartupScript(typeof(ControlUtilities), GetRandomName(), startUpScript);
		}

		public static void SetInitialFocus(Control container, Type typeOfFirstControlToRecieveFocus) {
			ArrayList controls = FindControlsRecursive(container, typeOfFirstControlToRecieveFocus);
			if (controls.Count > 0)
				container.Page.SetFocus((Control) controls[0]);
		}
	}
}
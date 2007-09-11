using System;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ruhe.Common;

namespace Ruhe.Web.UI.Controls {
	public class InputCheckBoxList : CheckBoxList, IInputControl {
		private IList selectedDataSource;

		public IList SelectedDataSource {
			get { return selectedDataSource; }
			set { selectedDataSource = value; }
		}

		protected override void Render(HtmlTextWriter writer) {
			writer.AddAttribute(HtmlTextWriterAttribute.Class, "scrollable");
			writer.AddStyleAttribute(HtmlTextWriterStyle.Height, "7em");
			writer.RenderBeginTag(HtmlTextWriterTag.Div);

			base.Render(writer);

			writer.RenderEndTag();
		}

		public override void DataBind() {
			base.DataBind();
			SelectByList(SelectedDataSource);
		}

		//TODO: optionally add items that aren't in the list; otherwise, skip
		public void SelectByList(IList dataList) {
			Clear();
			if (dataList != null) {
				foreach (object dataElement in dataList) {
					string value = Convert.ToString(Reflector.GetPropertyValue(dataElement, DataValueField));
					Items.FindByValue(value).Selected = true;
				}
			}
		}

		#region ILabeledControl Members

		public string LabelText {
			get { return StringUtilities.NullToEmpty((string) ViewState["LabelText"]); }
			set { ViewState["LabelText"] = value; }
		}

		public string FormatText {
			get { return StringUtilities.NullToEmpty((string) ViewState["FormatText"]); }
			set { ViewState["FormatText"] = value; }
		}

		#endregion

		#region IInputControl Members

		public string DefaultElementClientId {
			get {
				// TODO:  Add InputCheckBoxList.DefaultElementClientId getter implementation
				return null;
			}
		}

		public string ValidatedControlId {
			get {
				// TODO:  Add InputCheckBoxList.ValidatedControlId getter implementation
				return null;
			}
		}

		public string ErrorMessage {
			get {
				// TODO:  Add InputCheckBoxList.ErrorMessage getter implementation
				return null;
			}
			set {
				// TODO:  Add InputCheckBoxList.ErrorMessage setter implementation
			}
		}

		public bool ReadOnly {
			get {
				// TODO:  Add InputCheckBoxList.ReadOnly getter implementation
				return false;
			}
			set {
				// TODO:  Add InputCheckBoxList.ReadOnly setter implementation
			}
		}

		public bool Required {
			get {
				// TODO:  Add InputCheckBoxList.Required getter implementation
				return false;
			}
			set {
				// TODO:  Add InputCheckBoxList.Required setter implementation
			}
		}

		public bool EnableClientScript {
			get {
				// TODO:  Add InputCheckBoxList.EnableClientScript getter implementation
				return false;
			}
			set {
				// TODO:  Add InputCheckBoxList.EnableClientScript setter implementation
			}
		}

		public void Clear() {
			foreach (ListItem item in Items) {
				item.Selected = false;
			}
		}

		#endregion
	}
}
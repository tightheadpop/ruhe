using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ruhe.Common;

namespace Ruhe.Web.UI.Controls {
    /// <summary>
    /// Under development.
    /// </summary>
    public class InputCheckBoxList : CheckBoxList, IInputControl {
        private IList selectedDataSource;

        public IList SelectedDataSource {
            get { return selectedDataSource; }
            set { selectedDataSource = value; }
        }

        public override void DataBind() {
            base.DataBind();
            SelectByList(SelectedDataSource);
        }

        protected override void Render(HtmlTextWriter writer) {
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "scrollable");
            writer.AddStyleAttribute(HtmlTextWriterStyle.Height, "7em");
            writer.RenderBeginTag(HtmlTextWriterTag.Div);

            base.Render(writer);

            writer.RenderEndTag();
        }

        //TODO: optionally add items that aren't in the list; otherwise, skip
        public void SelectByList(IEnumerable dataList) {
            Clear();
            if (dataList != null) {
                foreach (object dataElement in dataList) {
                    string value = Convert.ToString(Reflector.GetPropertyValue(dataElement, DataValueField));
                    Items.FindByValue(value).Selected = true;
                }
            }
        }

        #region ILabeledControl Members

        public string FormatText {
            get { return (string) ViewState["FormatText"]; }
            set { ViewState["FormatText"] = value; }
        }

        public string LabelText {
            get { return (string) ViewState["LabelText"]; }
            set { ViewState["LabelText"] = value; }
        }

        #endregion

        #region IInputControl Members

        public string DefaultElementClientId {
            get {
                // TODO:  Add InputCheckBoxList.DefaultElementClientId getter implementation
                return null;
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

        public List<int> SelectedIntValues {
            get {
                return SelectedItems.ConvertAll(
                    new Converter<ListItem, int>(
                        delegate(ListItem i) { return Convert.ToInt32(i.Value); }));
            }
        }

        public List<ListItem> SelectedItems {
            get {
                List<ListItem> selectedItems = new List<ListItem>();
                foreach (ListItem item in Items) {
                    if (item.Selected)
                        selectedItems.Add(item);
                }
                return selectedItems;
            }
        }

        public List<string> SelectedValues {
            get {
                return SelectedItems.ConvertAll(
                    new Converter<ListItem, string>(
                        delegate(ListItem i) { return i.Value; }));
            }
        }

        public string ValidatedControlId {
            get {
                // TODO:  Add InputCheckBoxList.ValidatedControlId getter implementation
                return null;
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
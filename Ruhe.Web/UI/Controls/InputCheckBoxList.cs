using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ruhe.Common;
using Ruhe.Common.Utilities;

namespace Ruhe.Web.UI.Controls {
    /// <summary>
    /// Under development.
    /// </summary>
    public class InputCheckBoxList : CheckBoxList, IInputControl {
        private IList disabledDataSource;

        public new IList DataSource {
            get { return (IList) base.DataSource; }
            set { base.DataSource = value; }
        }

        public string DefaultElementClientId {
            get {
                // TODO:  Add InputCheckBoxList.DefaultElementClientId getter implementation
                return null;
            }
        }

        public IList DisabledDataSource {
            get { return disabledDataSource; }
            set { disabledDataSource = value; }
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

        public string FormatText {
            get { return (string) ViewState["FormatText"]; }
            set { ViewState["FormatText"] = value; }
        }

        public string LabelText {
            get { return (string) ViewState["LabelText"]; }
            set { ViewState["LabelText"] = value; }
        }

        public bool ReadOnly {
            get {
                EnsureChildControls();
                return Convert.ToBoolean(ViewState["ReadOnly"]);
            }
            set {
                EnsureChildControls();
                ViewState["ReadOnly"] = value;
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

        public IList SelectedDataSource { get; set; }

        public List<int> SelectedIntValues {
            get { return SelectedItems.ConvertAll(i => Convert.ToInt32(i.Value)); }
        }

        public List<ListItem> SelectedItems {
            get {
                var selectedItems = new List<ListItem>();
                foreach (ListItem item in Items) {
                    if (item.Selected)
                        selectedItems.Add(item);
                }
                return selectedItems;
            }
        }

        public List<string> SelectedValues {
            get { return SelectedItems.ConvertAll(i => i.Value); }
        }

        public string ValidatedControlId {
            // TODO:  Add InputCheckBoxList.ValidatedControlId getter implementation
            get { return null; }
        }

        public void Clear() {
            ClearSelection();
        }

        public override void DataBind() {
            base.DataBind();
            SelectByList(SelectedDataSource);
            EmitDisabledScript();
        }

        private void EmitDisabledScript() {
            if (disabledDataSource == null || Page == null) return;

            var indexes = new List<string>();
            foreach (object o in disabledDataSource) {
                indexes.Add(DataSource.IndexOf(o).ToString());
            }
            if (indexes.Count == 0) return;
            string clientArrayName = ClientID + "_disabled";
            Page.ClientScript.RegisterArrayDeclaration(clientArrayName, "'" + string.Join("','", indexes.ToArray()) + "'");
            Page.ClientScript.RegisterStartupScript(GetType(), ClientID + "disabled script", string.Format(@"
for(var i = 0; i < {0}.length; i++) {{
    var box = $get('{1}_' + {0}[i]);
    box.disabled = true;
    box.name = null;
    box.parentNode.disabled = true;
}}", clientArrayName, ClientID), true);
        }

        private string GetDataValue(object dataElement) {
            if (DataValueField.TrimToNull() == null)
                return dataElement.ToString();
            return Convert.ToString(dataElement.GetPropertyValue(DataValueField));
        }

        protected override void Render(HtmlTextWriter writer) {
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "scrollable");
            writer.AddStyleAttribute(HtmlTextWriterStyle.Height, "7em");
            writer.RenderBeginTag(HtmlTextWriterTag.Div);

            base.Render(writer);

            writer.RenderEndTag();
        }

        protected override void RenderItem(ListItemType itemType, int repeatIndex, RepeatInfo repeatInfo, HtmlTextWriter writer) {
            if (ReadOnly) {
                string itemId = ClientID + "_" + repeatIndex;
                Page.ClientScript.RegisterStartupScript(GetType(), itemId, string.Format(@"$get('{0}').onclick=function(){{return false;}};", itemId), true);
            }
            base.RenderItem(itemType, repeatIndex, repeatInfo, writer);
        }

        //TODO: optionally add items that aren't in the list; otherwise, skip
        public void SelectByList(IEnumerable dataList) {
            Clear();
            if (dataList != null) {
                foreach (object dataElement in dataList) {
                    Items.FindByValue(GetDataValue(dataElement)).Selected = true;
                }
            }
        }
    }
}
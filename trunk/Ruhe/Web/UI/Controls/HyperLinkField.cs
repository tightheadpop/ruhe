using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquidSyntax.ForWeb;

namespace Ruhe.Web.UI.Controls {
    /// <summary>
    /// Enables OGNL-like navigation to properties. It does not yet support method
    /// calls or other operations.
    /// </summary>
    public class HyperLinkField : System.Web.UI.WebControls.HyperLinkField {
        protected object[] GetNavigateUrlValue(object dataItem) {
            return DataNavigateUrlFields.Select(url => DataBinder.Eval(dataItem, url)).ToArray();
        }

        protected object GetTextValue(object dataItem) {
            return DataBinder.Eval(dataItem, DataTextField);
        }

        public override void InitializeCell(DataControlFieldCell cell, DataControlCellType cellType, DataControlRowState rowState, int rowIndex) {
            base.InitializeCell(cell, cellType, rowState, rowIndex);
            ReplaceDataBindingEvent(cell);
        }

        protected void OnDataBindField(object sender, EventArgs e) {
            var boundControl = (HyperLink) sender;
            var controlContainer = boundControl.NamingContainer;
            var dataItem = DataBinder.GetDataItem(controlContainer);

            boundControl.Text = FormatDataTextValue(GetTextValue(dataItem));
            boundControl.NavigateUrl = FormatDataNavigateUrlValue(GetNavigateUrlValue(dataItem));
        }

        protected void ReplaceDataBindingEvent(Control cell) {
            var oldLink = cell.FindFirst<HyperLink>();
            if (oldLink == null) return;

            cell.Controls.Remove(oldLink);
            var newLink = new HyperLink {Text = oldLink.Text, NavigateUrl = oldLink.NavigateUrl, Target = oldLink.Target};
            newLink.DataBinding += OnDataBindField;
            cell.Controls.Add(newLink);
        }
    }
}
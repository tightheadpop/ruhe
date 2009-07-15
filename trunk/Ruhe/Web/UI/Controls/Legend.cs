using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquidSyntax;
using LiquidSyntax.ForWeb;

namespace Ruhe.Web.UI.Controls {
    /// <summary>
    /// Auto-discovers all IIcons in a <see cref="Page"/> and renders a
    /// table of descriptions for each type found.
    /// </summary>
    public class Legend : Panel {
        private readonly SortedList controlList;

        public Legend() {
            controlList = new SortedList();
        }

        public string Overview {
            get { return (string) ViewState["Overview"]; }
            set { ViewState["Overview"] = value; }
        }

        private void Add(IIcon item) {
            if (! controlList.ContainsKey(item.Name)) {
                var control = (IIcon) Activator.CreateInstance(item.GetType());
                controlList.Add(item.Name, control);
            }
        }

        protected override void AddAttributesToRender(HtmlTextWriter writer) {
            CssClass = Regex.Replace(CssClass, @"\blegend\b", string.Empty).WithSuffix(" legend").Trim();
            base.AddAttributesToRender(writer);
        }

        protected override void OnPreRender(EventArgs e) {
            base.OnPreRender(e);
            RegisterIcons();
        }

        private void RegisterIcons() {
            Page.FindAllUntil<IIcon>(c => !c.Visible).ForEach(Add);
        }

        protected override void Render(HtmlTextWriter writer) {
            if (!string.IsNullOrEmpty(Overview)) {
                var overview = new Panel();
                Controls.Add(overview);
                overview.Controls.Add(new EncodedLabel(Overview));
            }

            var table = new Table();

            foreach (IIcon icon in controlList.Values) {
                var row = new TableRow();
                row.Style.Add("margin-top", "5px");
                table.Rows.Add(row);

                //Add icon cell
                var cell = new TableCell {HorizontalAlign = HorizontalAlign.Center, VerticalAlign = VerticalAlign.Top};
                row.Cells.Add(cell);
                cell.Controls.Add(icon as Control);

                //Add description cell
                cell = new TableCell {VerticalAlign = VerticalAlign.Top};
                row.Cells.Add(cell);
                cell.Controls.Add(new EncodedLabel(icon.Description));

                Controls.Add(table);
            }

            if (table.HasControls()) {
                base.Render(writer);
            }
        }
    }
}
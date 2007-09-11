using System;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ruhe.Web.UI.Controls {
	public class Legend : Control {
		private SortedList controlList;

		public Legend() {
			controlList = new SortedList();
		}

		private void Add(IIcon item) {
			if (! controlList.ContainsKey(item.Name)) {
				IIcon control = (IIcon) Activator.CreateInstance(item.GetType());
				controlList.Add(item.Name, control);
			}
		}

		protected override void OnPreRender(EventArgs e) {
			base.OnPreRender(e);
			RegisterIcons();
		}

		private void RegisterIcons() {
			foreach (IIcon icon in ControlUtilities.FindControlsRecursive(Page, typeof(IIcon))) {
				if (((Control) icon).Visible) {
					Add(icon);
				}
			}
		}

		protected override void Render(HtmlTextWriter writer) {
			Panel overview = new Panel();
			Controls.Add(overview);
			overview.Controls.Add(new EncodedLabel("Below are explanations of the symbols that you may encounter on this page."));

			Table table = new Table();

			foreach (IIcon icon in controlList.Values) {
				TableRow row = new TableRow();
				row.Style.Add("margin-top", "5px");
				table.Rows.Add(row);

				//Add icon cell
				TableCell cell = new TableCell();
				cell.HorizontalAlign = HorizontalAlign.Center;
				cell.VerticalAlign = VerticalAlign.Top;
				row.Cells.Add(cell);
				cell.Controls.Add(icon as Control);

				//Add description cell
				cell = new TableCell();
				cell.VerticalAlign = VerticalAlign.Top;
				row.Cells.Add(cell);
				cell.Controls.Add(new EncodedLabel(icon.Description));

				Controls.Add(table);
			}

			if (table.HasControls()) {
				writer.AddAttribute(HtmlTextWriterAttribute.Class, "legend");
				writer.RenderBeginTag(HtmlTextWriterTag.Fieldset);

				writer.RenderBeginTag(HtmlTextWriterTag.Legend);
				writer.Write("Legend");
				writer.RenderEndTag();

				base.Render(writer);

				writer.RenderEndTag();
			}
		}
	}
}
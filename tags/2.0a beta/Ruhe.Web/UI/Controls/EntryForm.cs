using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ruhe.Common;

namespace Ruhe.Web.UI.Controls {
	/*
	 * IMPORTANT! ACHTUNG! 
	 * 
	 *		This class is copied directly from LabeledControlPanel to fix a funky
	 *		error in ASP.NET wherein the LabeledControlPanel could not maintain
	 *		ViewState.  Even though this file is an exact copy, it works differently.
	 * 
	 * 
	 * */

	public class EntryForm : Panel, ILabeledControl, ILayoutContainer {
		public EntryForm() {
			LabelPosition = LabelPosition.Left;
		}

		public LabelPosition LabelPosition {
			get { return (LabelPosition) Enum.Parse(typeof(LabelPosition), (string) ViewState["LabelPosition"], true); }
			set { ViewState["LabelPosition"] = value.ToString(); }
		}

		public string HeaderText {
			get { return StringUtilities.NullToEmpty((string) ViewState["HeaderText"]); }
			set { ViewState["HeaderText"] = value; }
		}

		public void ClearFormControls() {
			foreach (IInputControl control in ControlUtilities.FindControlsRecursive(this, typeof(IInputControl))) {
				control.Clear();
			}
		}

		protected override void AddAttributesToRender(HtmlTextWriter writer) {
			string cssClass = CssClass.Replace("labeledControlPanel", String.Empty);
			CssClass = StringUtilities.ForceSuffix(cssClass, " labeledControlPanel").Trim();
			base.AddAttributesToRender(writer);
		}

		protected override void Render(HtmlTextWriter writer) {
			RenderBeginTag(writer);
			RenderContents(writer);
			RenderEndTag(writer);
		}

		protected override void RenderContents(HtmlTextWriter writer) {
			Table layoutTable = new Table();

			layoutTable.ID = UniqueID + "_layoutTable";
			layoutTable.BorderWidth = Unit.Pixel(0);
			layoutTable.CellPadding = 0;
			layoutTable.CellSpacing = 2;

			if (HasControls()) {
				if (HeaderText != String.Empty) {
					writer.RenderBeginTag(HtmlTextWriterTag.Fieldset);
					writer.RenderBeginTag(HtmlTextWriterTag.Legend);
					writer.Write(HttpUtility.HtmlEncode(HeaderText));
					writer.RenderEndTag();
				}
				layoutTable.RenderBeginTag(writer);

				ProcessControlRows(Controls, writer);
				layoutTable.RenderEndTag(writer);
				if (LabelText != String.Empty) {
					writer.RenderEndTag();
				}
			}
		}

		private void ProcessControlRows(ControlCollection controls, HtmlTextWriter writer) {
			foreach (Control control in controls) {
				if (control is ILayoutContainer && ((ILayoutContainer) control).IsLayoutContainer)
					ProcessControlRows(control.Controls, writer);
				else {
					if (control is SectionHeader) {
						RenderHeaderRow(control, writer);
					}
					else if (control.Visible && IsControlNonEmpty(control)) {
						RenderRow(control, writer);
					}
				}
			}
		}

		private void RenderNameLabelCell(Control control, HtmlTextWriter writer) {
			string labelText = String.Empty;
			EncodedLabel nameLabel;
			TableCell labelCell = new TableCell();
			labelCell.CssClass = "label " + LabelPosition.ToString().ToLower();

			ILabeledControl labeledControl = control as ILabeledControl;
			if (labeledControl != null) {
				labelText = labeledControl.LabelText.Trim();
				labelText = (labelText == String.Empty) ? String.Empty : labelText + ":";
			}
			nameLabel = new EncodedLabel(labelText);
			nameLabel.ID = control.UniqueID.Replace(":", "_") + "_label";

			labelCell.RenderBeginTag(writer);
			writer.RenderBeginTag(HtmlTextWriterTag.Nobr);

			IInputControl inputControl = control as IInputControl;
			if (inputControl != null) {
				writer.AddAttribute(HtmlTextWriterAttribute.For, inputControl.DefaultElementClientId);
				writer.RenderBeginTag(HtmlTextWriterTag.Label);
			}
			nameLabel.RenderControl(writer);
			if (LabelPosition == LabelPosition.Above) {
				RenderFormatLabel(control, writer);
			}

			if (inputControl != null) {
				writer.RenderEndTag();
			}
			writer.RenderEndTag();
			labelCell.RenderEndTag(writer);
		}

		private void RenderFormatLabel(Control control, HtmlTextWriter writer) {
			EncodedLabel formatLabel;
			string formatText;
			formatLabel = new EncodedLabel();
			formatLabel.CssClass = "format";

			ILabeledControl labeledControl = control as ILabeledControl;
			if (labeledControl != null) {
				formatText = labeledControl.FormatText;
				if (formatText.Length > 0) {
					formatLabel.Text = formatText;
				}
			}

			formatLabel.ID = control.UniqueID.Replace(":", "_") + "_format";

			writer.Write(" ");
			formatLabel.RenderControl(writer);
		}

		private void RenderContentCell(Control control, HtmlTextWriter writer) {
			TableCell controlCell = new TableCell();

			controlCell.CssClass = "labeled";
			controlCell.RenderBeginTag(writer);
			control.RenderControl(writer);
			if (LabelPosition == LabelPosition.Left) {
				RenderFormatLabel(control, writer);
			}
			controlCell.RenderEndTag(writer);
		}

		private void RenderRow(Control control, HtmlTextWriter writer) {
			TableRow row = new TableRow();
			row.RenderBeginTag(writer);

			RenderNameLabelCell(control, writer);
			if (LabelPosition == LabelPosition.Above) {
				row.RenderEndTag(writer);
				row.RenderBeginTag(writer);
			}
			RenderContentCell(control, writer);

			row.RenderEndTag(writer);
		}

		private void RenderHeaderRow(Control control, HtmlTextWriter writer) {
			TableRow row = new TableRow();

			TableCell cell = new TableCell();
			cell.ColumnSpan = 2;
			cell.CssClass = "sectionHeader";

			row.RenderBeginTag(writer);
			cell.RenderBeginTag(writer);
			control.RenderControl(writer);
			cell.RenderEndTag(writer);
			row.RenderEndTag(writer);
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

		private bool IsControlNonEmpty(Control control) {
			return control is ILabeledControl ||
			       control is WebControl ||
			       control is LiteralControl && ((LiteralControl) control).Text.Trim().Length > 0;
		}

		#region ILayoutContainer Members

		public bool IsLayoutContainer {
			get {
				EnsureChildControls();
				return Convert.ToBoolean(ViewState["IsLayoutPassthrough"]);
			}
			set {
				EnsureChildControls();
				ViewState["IsLayoutPassthrough"] = value;
			}
		}

		#endregion
	}
}
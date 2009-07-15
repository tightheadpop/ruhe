using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquidSyntax;
using LiquidSyntax.ForWeb;
using System.Linq;

namespace Ruhe.Web.UI.Controls {
    /// <summary>
    /// Provides a well-formed, tabular layout for child controls
    /// </summary>
    public class LabeledControlPanel : Panel, ILabeledControl, ILayoutContainer {
        public LabeledControlPanel() {
            LabelPosition = LabelPosition.Left;
        }

        public string FormatText {
            get { return (string) ViewState["FormatText"]; }
            set { ViewState["FormatText"] = value; }
        }

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

        public LabelPosition LabelPosition {
            get { return ((string) ViewState["LabelPosition"]).As<LabelPosition>(); }
            set { ViewState["LabelPosition"] = value.ToString(); }
        }

        public string LabelText {
            get { return (string) ViewState["LabelText"]; }
            set { ViewState["LabelText"] = value; }
        }

        public string ValidationGroup {
            get {
                EnsureChildControls();
                return (string) ViewState["ValidationGroup"];
            }
            set {
                EnsureChildControls();
                ViewState["ValidationGroup"] = value;

                var controlsToUpdate = this.FindAll<Control>().ToList();
                controlsToUpdate.Remove(this);
                foreach (var c in controlsToUpdate) {
                    if (c.HasProperty("ValidationGroup")) {
                        c.SetPropertyValue("ValidationGroup", value);
                    }
                }
            }
        }

        protected override void AddAttributesToRender(HtmlTextWriter writer) {
            var cssClass = CssClass.Replace("labeledControlPanel", String.Empty);
            CssClass = cssClass.WithSuffix(" labeledControlPanel").Trim();
            base.AddAttributesToRender(writer);
        }

        public void ClearFormControls() {
            foreach (var control in this.FindAll<IInputControl>()) {
                control.Clear();
            }
        }

        protected override void OnPreRender(EventArgs e) {
            Require.DefaultStyleSheet(typeof(Require), "ruhe.css");
            base.OnPreRender(e);
        }

        private void ProcessControlRows(ControlCollection controls, HtmlTextWriter writer) {
            foreach (Control control in controls) {
                if (control is ILayoutContainer && ((ILayoutContainer) control).IsLayoutContainer)
                    ProcessControlRows(control.Controls, writer);
                else {
                    if (control is SectionHeader) {
                        RenderHeaderRow(control, writer);
                    } else if (control.Visible && IsNotEmptyLiteral(control)) {
                        RenderRow(control, writer);
                    }
                }
            }
        }

        protected override void Render(HtmlTextWriter writer) {
            RenderBeginTag(writer);
            RenderContents(writer);
            RenderEndTag(writer);
        }

        private void RenderContentCell(Control control, HtmlTextWriter writer) {
            var controlCell = new TableCell {CssClass = "labeled"};

            controlCell.RenderBeginTag(writer);
            control.RenderControl(writer);
            if (LabelPosition == LabelPosition.Left) {
                RenderFormatLabel(control, writer);
            }
            controlCell.RenderEndTag(writer);
        }

        protected override void RenderContents(HtmlTextWriter writer) {
            var layoutTable = new Table {CssClass = "layoutTable", ID = UniqueID + "_layoutTable"};

            if (HasControls()) {
                layoutTable.RenderBeginTag(writer);

                ProcessControlRows(Controls, writer);
                layoutTable.RenderEndTag(writer);
                if (!string.IsNullOrEmpty(LabelText)) {
                    writer.RenderEndTag();
                }
            }
        }

        private void RenderNameLabelCell(Control control, HtmlTextWriter writer) {
            var labelText = string.Empty;
            var labelCell = new TableCell {CssClass = "label " + LabelPosition.ToString().ToLower()};

            var labeledControl = control as ILabeledControl;
            if (labeledControl != null) {
                labelText = labeledControl.LabelText.TrimToEmpty();
                labelText = string.IsNullOrEmpty(labelText) ? string.Empty : labelText + ":";
            }
            var nameLabel = new EncodedLabel(labelText) {ID = control.UniqueID.Replace(":", "_") + "_label"};

            labelCell.RenderBeginTag(writer);
            writer.RenderBeginTag(HtmlTextWriterTag.Nobr);

            var inputControl = control as IInputControl;
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

        private void RenderRow(Control control, HtmlTextWriter writer) {
            var row = new TableRow();
            row.RenderBeginTag(writer);

            RenderNameLabelCell(control, writer);
            if (LabelPosition == LabelPosition.Above) {
                row.RenderEndTag(writer);
                row.RenderBeginTag(writer);
            }
            RenderContentCell(control, writer);

            row.RenderEndTag(writer);
        }

        /// <summary>
        /// The ASPX parser sees whitespace as an empty literal control.
        /// </summary>
        private static bool IsNotEmptyLiteral(Control control) {
            if (control is LiteralControl)
                return ((LiteralControl) control).Text.Trim().Length > 0;
            return true;
        }

        private static void RenderFormatLabel(Control control, HtmlTextWriter writer) {
            var formatLabel = new Label {CssClass = "format"};

            var labeledControl = control as ILabeledControl;
            if (labeledControl != null) {
                var formatText = labeledControl.FormatText.TrimToEmpty();
                if (formatText.Length > 0) {
                    formatLabel.Text = formatText;
                }
            }

            formatLabel.ID = control.UniqueID.Replace(":", "_") + "_format";

            writer.Write(" ");
            formatLabel.RenderControl(writer);
        }

        private static void RenderHeaderRow(Control control, HtmlTextWriter writer) {
            var row = new TableRow();

            var cell = new TableCell {ColumnSpan = 2, CssClass = "sectionHeader"};

            row.RenderBeginTag(writer);
            cell.RenderBeginTag(writer);
            control.RenderControl(writer);
            cell.RenderEndTag(writer);
            row.RenderEndTag(writer);
        }
    }
}
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ruhe.Common;
using Ruhe.Common.Utilities;
using Ruhe.Web.Configuration;

namespace Ruhe.Web.UI.Controls {
    public class InputDateRange : CompositeControl, IInputControl {
        private InputDate fromDate;
        private InputDate toDate;
        private PlaceHolder inputContainer;
        private Label readOnlyLabel;
        private RequiredIcon requiredLabel;

        protected virtual void AssignIdsToChildControls() {
            fromDate.ID = ID + "_from";
            toDate.ID = ID + "_to";
            readOnlyLabel.ID = ID + "_readOnly";
            requiredLabel.ID = ID + "_required";
        }

        protected override void CreateChildControls() {
            base.CreateChildControls();
            CreateInputContainer();
            CreateStartDate();
            CreateToLabel();
            CreateEndDate();
            CreateRequiredLabel();
            CreateReadOnlyLabel();
            AssignIdsToChildControls();
            ReadOnly = false;
            Required = false;
        }

        public override string ID {
            get { return base.ID; }
            set {
                EnsureChildControls();
                base.ID = value;
                AssignIdsToChildControls();
            }
        }

        private void CreateReadOnlyLabel() {
            readOnlyLabel = new Label();
            Controls.Add(readOnlyLabel);
        }

        private void CreateRequiredLabel() {
            requiredLabel = new RequiredIcon();
            requiredLabel.EnableViewState = false;
            inputContainer.Controls.Add(new BreakingSpace());
            inputContainer.Controls.Add(requiredLabel);
        }

        private void CreateEndDate() {
            toDate = new InputDate();
            inputContainer.Controls.Add(toDate);
        }

        private void CreateToLabel() {
            inputContainer.Controls.Add(new LiteralControl("to"));
            inputContainer.Controls.Add(new NonBreakingSpace());
        }

        private void CreateStartDate() {
            fromDate = new InputDate();
            inputContainer.Controls.Add(fromDate);
        }

        private void CreateInputContainer() {
            inputContainer = new PlaceHolder();
            Controls.Add(inputContainer);
        }

        public string DefaultElementClientId {
            get {
                EnsureChildControls();
                return fromDate.ClientID;
            }
        }

        public string ValidatedControlId {
            get { return toDate.ID; }
        }

        public string ErrorMessage {
            get {
                EnsureChildControls();
                return StringUtilities.NullToEmpty((string) ViewState["ErrorMessage"]);
            }
            set {
                EnsureChildControls();
                ViewState["ErrorMessage"] = value;
            }
        }

        public bool ReadOnly {
            get {
                EnsureChildControls();
                return readOnlyLabel.Visible;
            }
            set {
                EnsureChildControls();
                readOnlyLabel.Visible = value;
                inputContainer.Visible = !value;
            }
        }

        public bool Required {
            get {
                EnsureChildControls();
                return requiredLabel.Visible;
            }
            set {
                EnsureChildControls();
                requiredLabel.Visible = value;
            }
        }

        public string ValidationGroup {
            get {
                EnsureChildControls();
                return fromDate.ValidationGroup;
            }
            set {
                EnsureChildControls();
                fromDate.ValidationGroup = value;
                toDate.ValidationGroup = value;
            }
        }

        public bool EnableClientScript {
            get {
                EnsureChildControls();
                return fromDate.EnableClientScript;
            }
            set {
                EnsureChildControls();
                fromDate.EnableClientScript = value;
                toDate.EnableClientScript = value;
            }
        }

        public DateRange? DateRange {
            get {
                EnsureChildControls();
                return Common.DateRange.Create(fromDate.Value, toDate.Value);
            }
            set {
                EnsureChildControls();
                if (value.HasValue && value.Value.Start != DateTime.MinValue.Date)
                    fromDate.Value = value.Value.Start;
                else
                    fromDate.Value = null;
                if (value.HasValue && value.Value.End != DateTime.MaxValue.Date)
                    toDate.Value = value.Value.End;
                else
                    toDate.Value = null;
            }
        }

        public void Clear() {
            EnsureChildControls();
            fromDate.Clear();
            toDate.Clear();
        }

        protected override void Render(HtmlTextWriter writer) {
            EnsureChildControls();
            readOnlyLabel.Text = DateRange.HasValue ? DateRange.Value.ToString(RuheConfigurationSection.GetCurrent().DateFormat.Value) : string.Empty;
//            requiredLabel.Visible = Required && !ReadOnly;

            writer.RenderBeginTag(HtmlTextWriterTag.Nobr);
            base.Render(writer);
            writer.RenderEndTag();
        }
    }
}
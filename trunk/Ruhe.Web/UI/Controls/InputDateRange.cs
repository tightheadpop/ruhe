using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ruhe.Common;
using Ruhe.Web.Configuration;

namespace Ruhe.Web.UI.Controls {
    public class InputDateRange : CompositeControl, IInputControl {
        private InputDate fromDate;
        private InputDate toDate;
        private PlaceHolder inputContainer;
        private Label readOnlyLabel;
        private RequiredIcon requiredLabel;
        private OrGroupValidator groupValidator;
        private InputDateRangeValidator rangeValidator;

        protected override void OnInit(EventArgs e) {
            base.OnInit(e);
            EnsureChildControls();
            AssignIdsToChildControls();
            IValidatorConfigurator configurator = RuheConfiguration.ValidatorConfigurator;
            configurator.ConfigureValidator(groupValidator, this);
            configurator.ConfigureValidator(rangeValidator, this);
        }

        protected virtual void AssignIdsToChildControls() {
            fromDate.ID = ID + "_from";
            toDate.ID = ID + "_to";
            readOnlyLabel.ID = ID + "_readOnly";
            requiredLabel.ID = ID + "_requiredLabel";
            groupValidator.ID = ID + "_groupValidator";
            groupValidator.GroupToValidate = new string[] {fromDate.ID, toDate.ID};
            rangeValidator.ID = ID + "_rangeValidator";
            rangeValidator.ControlToValidate = toDate.ID;
        }

        protected override void CreateChildControls() {
            base.CreateChildControls();
            CreateInputContainer();
            CreateStartDate();
            CreateToLabel();
            CreateEndDate();
            CreateRequiredLabel();
            CreateGroupValidator();
            CreateRangeValidator();
            CreateReadOnlyLabel();
            ReadOnly = false;
            Required = false;
            ErrorMessage = "Please enter a valid date range.";
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

        private void CreateGroupValidator() {
            groupValidator = new OrGroupValidator();
            inputContainer.Controls.Add(new BreakingSpace());
            inputContainer.Controls.Add(groupValidator);
        }

        private void CreateRangeValidator() {
            rangeValidator = new InputDateRangeValidator();
            inputContainer.Controls.Add(new BreakingSpace());
            inputContainer.Controls.Add(rangeValidator);
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
                return (string) ViewState["ErrorMessage"];
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
                groupValidator.Enabled = groupValidator.Visible = value;
                rangeValidator.Enabled = rangeValidator.Visible = value;
            }
        }

        public string Format {
            get {
                EnsureChildControls();
                return fromDate.Format;
            }
            set {
                EnsureChildControls();
                fromDate.Format = value;
                toDate.Format = value;
            }
        }

        public override string FormatText {
            get { return base.FormatText ?? RuheConfiguration.DateFormatText; }
            set { base.FormatText = value; }
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
                groupValidator.ValidationGroup = value;
                rangeValidator.ValidationGroup = value;
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
                groupValidator.EnableClientScript = value;
                rangeValidator.EnableClientScript = value;
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
            if (ReadOnly)
                readOnlyLabel.Text = DateRange.HasValue ? DateRange.Value.ToString(Format) : string.Empty;

            writer.RenderBeginTag(HtmlTextWriterTag.Nobr);
            base.Render(writer);
            writer.RenderEndTag();
        }
    }
}
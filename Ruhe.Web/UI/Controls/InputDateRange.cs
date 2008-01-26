using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ruhe.Common;

namespace Ruhe.Web.UI.Controls {
    public class InputDateRange : CompositeControl, IInputControl {
        private InputDate fromDate;
        private InputDate toDate;
        private PlaceHolder inputContainer;
        private Label readOnlyLabel;

        protected virtual void AssignIdsToChildControls() {
            fromDate.ID = ID + "_from";
            toDate.ID = ID + "_to";
            readOnlyLabel.ID = ID + "_readonly";
        }

        protected override void CreateChildControls() {
            base.CreateChildControls();
            CreateInputContainer();
            CreateStartDate();
            CreateToLabel();
            CreateEndDate();
            CreateReadOnlyLabel();
            AssignIdsToChildControls();
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
            get { throw new NotImplementedException(); }
        }

        public string ErrorMessage {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public bool ReadOnly {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public bool Required {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public string ValidationGroup {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public bool EnableClientScript {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public DateRange? DateRange {
            get {
                EnsureChildControls();
                if (fromDate.Value.HasValue && toDate.Value.HasValue)
                    return new DateRange(fromDate.Value.Value, toDate.Value.Value);
                if (fromDate.Value.HasValue)
                    return Common.DateRange.StartingOn(fromDate.Value.Value);
                if (toDate.Value.HasValue)
                    return Common.DateRange.EndingOn(toDate.Value.Value);
                return null;
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
    }
}
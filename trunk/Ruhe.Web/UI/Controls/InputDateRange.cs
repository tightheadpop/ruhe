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
            CreateFromLabel();
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
        }

        private void CreateStartDate() {
            fromDate = new InputDate();
            inputContainer.Controls.Add(fromDate);
        }

        private void CreateFromLabel() {
            inputContainer.Controls.Add(new LiteralControl("from"));
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

        public DateRange DateRange {
            get {
                EnsureChildControls();
                return new DateRange(fromDate.Value, toDate.Value);
            }
            set {
                EnsureChildControls();
                fromDate.Value = value.Start;
                toDate.Value = value.End;
            }
        }

        public void Clear() {
            EnsureChildControls();
            fromDate.Clear();
            toDate.Clear();
        }
    }
}
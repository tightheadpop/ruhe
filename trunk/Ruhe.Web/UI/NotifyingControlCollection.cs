using System;
using System.Web.UI;

namespace Ruhe.Web.UI {
    public class NotifyingControlCollection : ControlCollection {
        public NotifyingControlCollection(Control owner) : base(owner) {}

        public override void Add(Control child) {
            base.Add(child);
            OnChildControlAdded(new ControlAddedEventArgs(child));
        }

        public override void AddAt(int index, Control child) {
            AddAt(index, child, true);
        }

        public void AddAt(int index, Control child, bool raiseEvent) {
            base.AddAt(index, child);
            if (raiseEvent)
                OnChildControlAdded(new ControlAddedEventArgs(child));
        }

        protected virtual void OnChildControlAdded(ControlAddedEventArgs args) {
            if (null != ChildControlAdded)
                ChildControlAdded(this, args);
        }

        public event EventHandler<ControlAddedEventArgs> ChildControlAdded;
    }

    public class ControlAddedEventArgs : EventArgs {
        private readonly Control childControl;

        public ControlAddedEventArgs(Control childControl) {
            this.childControl = childControl;
        }

        public Control ChildControl {
            get { return childControl; }
        }
    }
}
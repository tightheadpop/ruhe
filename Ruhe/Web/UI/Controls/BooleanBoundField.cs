using System;
using System.Web.UI;

namespace Ruhe.Web.UI.Controls {
    public class BooleanBoundField : BoundField {
        public virtual string FalseText { get; set; }

        public virtual string TrueText { get; set; }

        protected virtual bool Evaluate(Control controlContainer) {
            return Convert.ToBoolean(base.GetValue(controlContainer));
        }

        protected override object GetValue(Control controlContainer) {
            return Evaluate(controlContainer) ? TrueText : FalseText;
        }
    }
}
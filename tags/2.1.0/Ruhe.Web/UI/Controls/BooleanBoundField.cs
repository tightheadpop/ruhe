using System;
using System.Web.UI;

namespace Ruhe.Web.UI.Controls {
    public class BooleanBoundField : BoundField {
        private string falseText;
        private string trueText;

        public virtual string FalseText {
            get { return falseText; }
            set { falseText = value; }
        }

        public virtual string TrueText {
            get { return trueText; }
            set { trueText = value; }
        }

        protected virtual bool Evaluate(Control controlContainer) {
            return Convert.ToBoolean(base.GetValue(controlContainer));
        }

        protected override object GetValue(Control controlContainer) {
            return Evaluate(controlContainer) ? TrueText : FalseText;
        }
    }
}
using System;
using System.Web.UI;

namespace Ruhe.Web.UI.Controls {
    public class BooleanBoundField : BoundField {
        private string falseText;
        private string trueText;

        public string FalseText {
            get { return falseText; }
            set { falseText = value; }
        }

        public string TrueText {
            get { return trueText; }
            set { trueText = value; }
        }

        protected override object GetValue(Control controlContainer) {
            bool value = Convert.ToBoolean(base.GetValue(controlContainer));
            return value ? TrueText : FalseText;
        }
    }
}
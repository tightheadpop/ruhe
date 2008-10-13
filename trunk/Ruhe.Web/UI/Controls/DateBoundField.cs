using Ruhe.Common.Utilities;
using Ruhe.Web.Configuration;

namespace Ruhe.Web.UI.Controls {
    public class DateBoundField : BoundField {
        public override string DataFormatString {
            get {
                return base.DataFormatString.TrimToNull()
                       ?? string.Format("{{0:{0}}}", RuheConfiguration.DateFormat);
            }
            set { base.DataFormatString = value; }
        }
        protected override string FormatDataValue(object dataValue, bool encode) {
            return string.Format(DataFormatString, dataValue);
        }
    }
}
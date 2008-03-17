using Ruhe.Common.Utilities;
using Ruhe.Web.Configuration;

namespace Ruhe.Web.UI.Controls {
    public class DateBoundField : BoundField {
        public override string DataFormatString {
            get {
                return StringUtilities.TrimToNull(base.DataFormatString)
                       ?? string.Format("{{0:{0}}}", RuheConfiguration.DateFormat);
            }
            set { base.DataFormatString = value; }
        }
    }
}
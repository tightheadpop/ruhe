using Ruhe.Common.Utilities;
using Ruhe.Web.Configuration;

namespace Ruhe.Web.UI.Controls {
    public class DateBoundField : BoundField {
        public override string DataFormatString {
            get {
                return StringUtilities.TrimToNull((string)ViewState["Format"])
                       ?? string.Format("{{0:{0}}}", RuheConfiguration.DateFormat);
            }
            set { ViewState["DataFormatString"] = value; }
        }
    }
}
using Ruhe.Web.Configuration;

namespace Ruhe.Web.UI.Controls {
    public class DateBoundField : BoundField {
        public override string DataFormatString {
            get {
                string userValue = (string) ViewState["DataFormatString"];
                if (!string.IsNullOrEmpty(userValue))
                    return userValue;
                return string.Format("{{0:{0}}}", RuheConfigurationSection.GetCurrent().DateFormat.Value);
            }
            set { ViewState["DataFormatString"] = value; }
        }
    }
}
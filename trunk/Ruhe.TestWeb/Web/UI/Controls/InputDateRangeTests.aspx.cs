using System;
using System.Web.UI;

namespace Ruhe.TestWeb.Web.UI.Controls {
    public partial class InputDateRangeTests : Page {
        protected void Page_Load(object sender, EventArgs e) {
            readOnlyInput.DateRange = new DateRange(DateTime.Today, DateTime.Today.AddDays(3));
        }
    }
}
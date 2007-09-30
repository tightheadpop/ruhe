using System;
using System.Web.UI;
using Ruhe.Web.UI.Controls;

public partial class Web_UI_Controls_InputNumberTests : Page {
    protected void Page_Load(object sender, EventArgs e) {
        if (Request["mode"] != null) {
            inputNumber.NumericFormat = (NumericFormat) Enum.Parse(typeof(NumericFormat), Request["mode"], true);
        }
        if (Request["max"] != null) {
            inputNumber.MinimumValue = Request["min"];
            inputNumber.MaximumValue = Request["max"];
        }
    }
}
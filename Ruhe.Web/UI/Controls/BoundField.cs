using System.Web.UI;
using Ruhe.Common.Utilities;

namespace Ruhe.Web.UI.Controls {
    /// <summary>
    /// Enables OGNL-like navigation to properties. It does not yet support method
    /// calls or other operations.
    /// <see cref="ObjectUtilities.GetPropertyValue(object,string)"/>
    /// </summary>
    public class BoundField : System.Web.UI.WebControls.BoundField {
        protected override object GetValue(Control controlContainer) {
            object dataItem = DataBinder.GetDataItem(controlContainer);
            return DataBinder.Eval(dataItem, DataField);
        }
    }
}
using System;
using System.Web.UI;
using Ruhe.Web.UI.Controls;

namespace Ruhe.TestWeb {
    public partial class AnotherLayoutContainer : UserControl, ILayoutContainer {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack)
                anotherTextBox.Text = Page.User.Identity.Name;
        }

        public bool IsLayoutContainer {
            get { return true; }
        }
    }
}
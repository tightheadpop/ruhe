using System;
using System.Web.UI;
using Ruhe.Common;

namespace Ruhe.TestWeb.Web.UI.Controls {
    public partial class BoundFieldTests : Page {
        protected void Page_Load(object sender, EventArgs e) {
            grid.DataSource = Quick.List(new Foo());
            grid.DataBind();
        }

        public class Foo {
            private readonly string[] bar = new string[] {"hi, mom!"};

            public string[] Bar {
                get { return bar; }
            }
        }
    }
}
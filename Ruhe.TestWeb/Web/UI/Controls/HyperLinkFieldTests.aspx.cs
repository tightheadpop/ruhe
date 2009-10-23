using System;
using System.Web.UI;
using LiquidSyntax;

namespace Ruhe.TestWeb.Web.UI.Controls {
    public partial class HyperLinkFieldTests : Page {
        protected void Page_Load(object sender, EventArgs e) {
            grid.DataSource = new Baz().AsList();
            grid.DataBind();
        }

        public class Bar {
            public int Id {
                get { return 1; }
            }
        }

        public class Baz {
            public Bar Bar {
                get { return new Bar(); }
            }
        }
    }
}
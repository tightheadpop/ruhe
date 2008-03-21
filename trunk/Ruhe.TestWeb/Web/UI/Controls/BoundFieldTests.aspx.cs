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
            private readonly string[] bar = new string[] {"hi, mom! i've got a new job."};

            public string[] Bar {
                get { return bar; }
            }

            public DateTime Baz {
                get { return new DateTime(2009, 2, 9); }
            }

            public DateRange Boz {
                get { return DateRange.StartingOn(new DateTime(1983, 9, 17)); }
            }

            public bool IsIt {
                get { return false; }
            }
        }
    }
}
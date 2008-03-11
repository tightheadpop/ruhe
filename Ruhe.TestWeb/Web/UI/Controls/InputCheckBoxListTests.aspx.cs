using System;
using System.Web.UI;
using Ruhe.Common;

namespace Ruhe.TestWeb.Web.UI.Controls {
    public partial class InputCheckBoxListTests : Page {
        protected void Page_Load(object sender, EventArgs e) {
            Whatever a = new Whatever(0, "a");
            Whatever b = new Whatever(1, "b");
            Whatever c = new Whatever(2, "c");
            Whatever d = new Whatever(3, "d");

            checkboxlist.DataSource = Quick.List(a, b, c, d);
            checkboxlist.SelectedDataSource = Quick.List(a);
            checkboxlist.DisabledDataSource = Quick.List(b, c);
            checkboxlist.DataBind();
        }

        public class Whatever {
            private readonly string text;
            private readonly int value;

            public Whatever(int value, string text) {
                this.value = value;
                this.text = text;
            }

            public string Text {
                get { return text; }
            }

            public int Value {
                get { return value; }
            }
        }
    }
}
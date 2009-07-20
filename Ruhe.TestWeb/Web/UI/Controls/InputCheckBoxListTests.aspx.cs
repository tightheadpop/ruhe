using System;
using System.Web.UI;
using LiquidSyntax;

namespace Ruhe.TestWeb.Web.UI.Controls {
    public partial class InputCheckBoxListTests : Page {
        protected void Page_Load(object sender, EventArgs e) {
            var a = new Whatever(0, "a");
            var b = new Whatever(1, "b");
            var c = new Whatever(2, "c");
            var d = new Whatever(3, "d");

            checkboxlist.DataSource = new []{a, b, c, d};
            checkboxlist.SelectedDataSource = a.AsList();
            checkboxlist.DisabledDataSource = new []{b, c};
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
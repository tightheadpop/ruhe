using NUnit.Framework;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Tests.Web.UI.Controls {
    [TestFixture]
    public class InputCheckBoxListTests {
        private InputCheckBoxList list;
        private Thing b;
        private Thing c;

        [Test]
        public void SelectByList() {
            list.DataBind();

            list.SelectByList(new Thing[] {b, c});

            Assert.IsFalse(list.Items[0].Selected);
            Assert.IsTrue(list.Items[1].Selected);
            Assert.IsTrue(list.Items[2].Selected);
        }

        [Test]
        public void SelectedDataSource() {
            list.SelectedDataSource = new Thing[] {b, c};
            list.DataBind();

            Assert.IsFalse(list.Items[0].Selected);
            Assert.IsTrue(list.Items[1].Selected);
            Assert.IsTrue(list.Items[2].Selected);
        }

        [Test]
        public void SelectedItems() {
            list.SelectedDataSource = new Thing[] {b, c};
            list.DataBind();

            Assert.AreEqual(2, list.SelectedItems.Count);
            Assert.AreEqual("2", list.SelectedItems[0].Value);
            Assert.AreEqual("3", list.SelectedItems[1].Value);
        }

        [Test]
        public void SelectedValues() {
            list.SelectedDataSource = new Thing[] {b, c};
            list.DataBind();

            Assert.AreEqual(new string[] {"2", "3"}, list.SelectedValues);
        }

        [Test]
        public void SelectedIntValues() {
            list.SelectedDataSource = new Thing[] {b, c};
            list.DataBind();

            Assert.AreEqual(new int[] {2, 3}, list.SelectedIntValues);
        }

        [SetUp]
        public void SetUp() {
            list = new InputCheckBoxList();
            list.DataTextField = "Name";
            list.DataValueField = "Value";
            b = new Thing("b", 2);
            c = new Thing("c", 3);
            Thing a = new Thing("a", 1);
            list.DataSource = new Thing[] {a, b, c};
        }

        private class Thing {
            private readonly string name;
            private readonly int value;

            public Thing(string name, int value) {
                this.name = name;
                this.value = value;
            }

            public string Name {
                get { return name; }
            }

            public int Value {
                get { return value; }
            }
        }
    }
}
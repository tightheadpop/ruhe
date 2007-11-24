using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using NUnit.Framework;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Tests.Web.UI.Controls {
    [TestFixture]
    public class InputEnumTests {
        [Test]
        public void BindsAllEnumNames() {
            InputEnumeration<Milkables> input = new InputEnumeration<Milkables>();
            List<string> actual = new List<string>();
            foreach (ListItem item in input.Items) {
                actual.Add(item.Text);
            }
            Assert.AreEqual(Enum.GetNames(typeof(Milkables)), actual);
        }

        [Test]
        public void ConvertsEnumValueWhenSettingsAndReading() {
            InputEnumeration<Milkables> input = new InputEnumeration<Milkables>();
            input.Value = Milkables.Trout;
            Assert.AreEqual(input.Value, Milkables.Trout);
        }

        protected enum Milkables {
            Chicken,
            Trout,
            Goat
        }
    }
}
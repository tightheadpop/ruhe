using System;
using NUnit.Extensions.Asp.AspTester;
using NUnit.Framework;
using Ruhe.Common;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Tests.Web.UI.Controls {
    [TestFixture]
    public class InputEnumWebTests : RuheWebTest<InputEnum> {
        private DropDownListTester noInitialBlank;
        private DropDownListTester initialBlank;
        private readonly int NumberOfMonths = Enum.GetNames(typeof(Month)).Length;

        [Test]
        public void PopulatesDropDown() {
            LoadPage();
            Assert.AreEqual(NumberOfMonths, noInitialBlank.Items.Count);
        }

        [Test]
        public void IncludesInitialBlank() {
            LoadPage();
            Assert.AreEqual(NumberOfMonths + 1, initialBlank.Items.Count);
            Assert.AreEqual(string.Empty, initialBlank.Items[0].RawText, "the first item should be blank");
        }

        protected override void LoadPage() {
            base.LoadPage();
            noInitialBlank = new DropDownListTester(IdFor("noInitialBlank"));
            initialBlank = new DropDownListTester(IdFor("initialBlank"));
        }
    }
}
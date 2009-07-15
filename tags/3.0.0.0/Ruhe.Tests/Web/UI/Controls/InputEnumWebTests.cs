using System;
using NUnit.Extensions.Asp.AspTester;
using NUnit.Framework;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Tests.Web.UI.Controls {
    [TestFixture]
    public class InputEnumWebTests : RuheWebTest<InputEnum> {
        private readonly int NumberOfMonths = Enum.GetNames(typeof(Month)).Length;
        private DropDownListTester initialBlank;
        private DropDownListTester noInitialBlank;

        [Test]
        public void IncludesInitialBlank() {
            LoadPage();
            Assert.AreEqual(NumberOfMonths + 1, initialBlank.Items.Count);
            Assert.AreEqual(string.Empty, initialBlank.Items[0].RawText, "the first item should be blank");
        }

        [Test]
        public void PopulatesDropDown() {
            LoadPage();
            Assert.AreEqual(NumberOfMonths, noInitialBlank.Items.Count);
        }

        protected override void LoadPage() {
            base.LoadPage();
            noInitialBlank = new DropDownListTester(IdFor("noInitialBlank"));
            initialBlank = new DropDownListTester(IdFor("initialBlank"));
        }
    }
}
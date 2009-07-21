using NUnit.Framework;
using Ruhe.Tests.Web.UI.Controls;

namespace Ruhe.Tests.TestExtensions.AspTesters {
    public class InputDropDownListTesterTests : RuheWebTest<InputDropDownListTester> {
        private InputDropDownListTester dropDownList;

        [Test]
        public void SelectByValue() {
            LoadPage();
            dropDownList = new InputDropDownListTester(IdFor("dropDownList"));
            dropDownList.SelectByValue("two");
            Assert.AreEqual(2, dropDownList.SelectedIndex);
        }
    }
}
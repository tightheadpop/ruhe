using NUnit.Extensions.Asp;
using NUnit.Framework;
using Ruhe.TestExtensions.AspTesters;
using Ruhe.Tests.Web.UI.Controls;

namespace Ruhe.Tests.TestExtensions.AspTesters {
    public class InputDropDownListTesterTests : RuheWebTest<InputDropDownListTester> {
        private InputDropDownListTester dropDownList;

        [Test]
        public void SelectByValue() {
            LoadPage();
            dropDownList = new InputDropDownListTester(IdFor.It("dropDownList"));
            dropDownList.SelectByValue("two");
            Assert.AreEqual(2, dropDownList.SelectedIndex);
        }
    }
}
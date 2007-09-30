using NUnit.Extensions.Asp;
using NUnit.Framework;
using Ruhe.TestExtensions;
using Ruhe.TestExtensions.AspTesters;

namespace Ruhe.Tests.Extensions.AspTesters {
	public class InputDropDownListTesterTests : WebFormTestCase {
		private InputDropDownListTester dropDownList;

		[Test]
		public void SelectByValue() {
			Browser.GetPage(ControlTesterUtilities.GetUrlPath(typeof(InputDropDownListTester)));
			dropDownList = new InputDropDownListTester(IdFor.It("dropDownList"));
			dropDownList.SelectByValue("two");
			Assert.AreEqual(2, dropDownList.SelectedIndex);
		}
	}
}
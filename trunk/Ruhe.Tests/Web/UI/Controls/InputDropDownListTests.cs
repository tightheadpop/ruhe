using System.Text.RegularExpressions;
using NUnit.Extensions.Asp;
using NUnit.Extensions.Asp.AspTester;
using NUnit.Extensions.Asp.HtmlTester;
using NUnit.Framework;
using Ruhe.TestExtensions;
using Ruhe.Tests.TestExtensions.HtmlTesters;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Tests.Web.UI.Controls {
	[TestFixture]
	public class InputDropDownListTests : WebFormTestCase {
		private string baseUrl;

		protected override void SetUp() {
			base.SetUp();
			baseUrl = Regex.Replace(ControlTesterUtilities.GetUrlPath(typeof(InputDropDownList)), "(.*/).*", "$1");
		}

		private void LoadPage(string pageName) {
			Browser.GetPage(baseUrl + pageName);
		}

		[Test]
		public void CanHaveChildControls() {
			InputDropDownList list = new InputDropDownList();
			Assert.IsNotNull(list.Controls[0]);
		}

		[Test]
		public void NotRequired() {
			LoadPage("InputDropDownNotRequired.aspx");
			HtmlControlTester img = new HtmlImageTester("DropDownTest_required");
			WebAssert.NotVisible(img);
		}

		[Test]
		public void Required() {
			LoadPage("InputDropDownRequired.aspx");
			HtmlControlTester img = new HtmlImageTester("DropDownTest_required");
			WebAssert.Visible(img);
		}

		[Test]
		public void SelectByValue() {
			InputDropDownList list = new InputDropDownList();
			string[] items = {"alpha", "bravo", "charlie"};
			list.DataSource = items;
			list.DataBind();

			AssertTrue(list.Items[0] == list.SelectedItem);
			AssertTrue(list.Items[0].Selected);

			list.SelectByValue("bravo");
			AssertTrue(list.Items[1].Selected);
			AssertTrue(!list.Items[0].Selected && !list.Items[2].Selected);
		}

		[Test]
		public void SelectByValueInt() {
			InputDropDownList list = new InputDropDownList();
			string[] items = {"1", "2", "3"};
			list.DataSource = items;
			list.DataBind();

			list.SelectByValue(2);
			AssertTrue(list.Items[1].Selected);
			AssertTrue(!list.Items[0].Selected && !list.Items[2].Selected);
		}

		[Test]
		public void SelectByValueTwice() {
			InputDropDownList list = new InputDropDownList();
			string[] items = {"alpha", "bravo", "charlie"};
			list.DataSource = items;
			list.DataBind();

			AssertTrue(list.Items[0] == list.SelectedItem);
			AssertTrue(list.Items[0].Selected);

			list.SelectByValue("bravo");
			list.SelectByValue("charlie");
			AssertTrue(list.Items[2].Selected);
			AssertTrue(!list.Items[0].Selected && !list.Items[1].Selected);
		}

		[Test]
		public void SelectByValueNotInList() {
			InputDropDownList list = new InputDropDownList();
			string[] items = {"alpha", "bravo", "charlie"};
			list.DataSource = items;
			list.DataBind();

			list.SelectByValue("zulu");
			AssertTrue(list.Items[0] == list.SelectedItem);
			AssertTrue(list.Items[0].Selected);
			AssertTrue(!list.Items[1].Selected && !list.Items[2].Selected);
		}

		[Test]
		public void PostBackIsolation() {
			LoadPage("InputDropDownPostBackIsolation.aspx");

			DropDownListTester dropDownList1 = new DropDownListTester("DropDownList1", CurrentWebForm);
			TextBoxTester byProduct1 = new TextBoxTester("ByProduct1", CurrentWebForm);
			TextBoxTester byProduct2 = new TextBoxTester("ByProduct2", CurrentWebForm);

			AssertEquals(byProduct1.Text, "did not fire");
			AssertEquals(byProduct2.Text, "did not fire");

			dropDownList1.SelectedIndex = 2; // <--- a postback happens here
			AssertTrue("Selected index of first drop down list should be the second option", dropDownList1.SelectedIndex == 2);

			AssertEquals(byProduct1.Text, "did fire");
			AssertEquals(byProduct2.Text, "did not fire");
		}

		[Test]
		public void ReadOnlySingleValue() {
			LoadPage("InputDropDownReadOnly.aspx");

			LabelTester readOnlyListLabel = new LabelTester("readOnlyList_readOnly", CurrentWebForm);
			DropDownListTester readOnlyList = new DropDownListTester("readOnlyList", CurrentWebForm);

			AssertVisibility(readOnlyListLabel, true);
			AssertVisibility(readOnlyList, false);
			AssertEquals("&amp;OrgTest", readOnlyListLabel.Text);
		}

		[Test]
		public void ReadOnlyTrueMultipleValues() {
			LoadPage("InputDropDownReadOnly.aspx");

			LabelTester readOnlyListLabel = new LabelTester("readOnlyTrueListMultiItem_readOnly", CurrentWebForm);
			DropDownListTester readOnlyList = new DropDownListTester("readOnlyTrueListMultiItem", CurrentWebForm);

			AssertVisibility(readOnlyListLabel, true);
			AssertVisibility(readOnlyList, false);
			AssertEquals("Org1", readOnlyListLabel.Text);
		}

		[Test]
		public void ReadOnlyFalseMultipleValues() {
			LoadPage("InputDropDownReadOnly.aspx");

			DropDownListTester readOnlyList = new DropDownListTester("readOnlyFalseListMultiItem", CurrentWebForm);
			LabelTester readOnlyListLabel = new LabelTester("readOnlyFalseListMultiItem_readOnly", CurrentWebForm);

			AssertVisibility(readOnlyList, true);
			AssertTrue(readOnlyList.Items.Count > 1);
			AssertVisibility(readOnlyListLabel, false);
		}

		[Test]
		public void ReadOnlyMultipleValueToSingleValue() {
			LoadPage("InputDropDownAutoPostBackDisplay.aspx");

			DropDownListTester firstList = new DropDownListTester("firstDropDownList", CurrentWebForm);
			DropDownListTester secondList = new DropDownListTester("secondDropDownList", CurrentWebForm);
			LabelTester firstLabel = new LabelTester("firstDropDownList_readOnly", CurrentWebForm);
			LabelTester secondLabel = new LabelTester("secondDropDownList_readOnly", CurrentWebForm);

			AssertVisibility(firstList, true);
			AssertTrue(firstList.Items.Count > 1);
			AssertVisibility(secondList, true);
			AssertTrue(secondList.Items.Count > 1);
			AssertVisibility(firstLabel, false);
			AssertVisibility(secondLabel, false);

			firstList.SelectedIndex = 1;

			AssertVisibility(firstList, true);
			AssertTrue(firstList.Items.Count > 1);
			AssertVisibility(secondList, false);
			AssertVisibility(firstLabel, false);
			AssertVisibility(secondLabel, true);
		}

		[Test]
		public void ReadOnlySingleValueToMultipleValue() {
			LoadPage("InputDropDownAutoPostBackDisplay.aspx");

			DropDownListTester thirdList = new DropDownListTester("thirdDropDownList", CurrentWebForm);
			DropDownListTester fourthList = new DropDownListTester("fourthDropDownList", CurrentWebForm);
			LabelTester thirdLabel = new LabelTester("thirdDropDownList_readOnly", CurrentWebForm);
			LabelTester fourthLabel = new LabelTester("fourthDropDownList_readOnly", CurrentWebForm);

			AssertVisibility(thirdList, true);
			AssertTrue(thirdList.Items.Count > 1);
			AssertVisibility(fourthList, false);
			AssertVisibility(thirdLabel, false);
			AssertVisibility(fourthLabel, true);

			thirdList.SelectedIndex = 1;

			AssertVisibility(thirdList, true);
			AssertTrue(thirdList.Items.Count > 1);
			AssertVisibility(fourthList, true);
			AssertTrue(fourthList.Items.Count > 1);
			AssertVisibility(thirdLabel, false);
			AssertVisibility(fourthLabel, false);
		}
	}
}
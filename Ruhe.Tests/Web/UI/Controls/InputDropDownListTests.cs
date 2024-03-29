using System.Web.UI.WebControls;
using LiquidSyntax;
using NUnit.Extensions.Asp;
using NUnit.Extensions.Asp.AspTester;
using NUnit.Extensions.Asp.HtmlTester;
using NUnit.Framework;
using Ruhe.Tests.TestExtensions.HtmlTesters;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Tests.Web.UI.Controls {
    [TestFixture]
    public class InputDropDownListTests : RuheWebTest<InputDropDownList> {
        [Test]
        public void BecomesNonReadOnlyWhenSingleValueBecomesMultipleValues() {
            LoadOtherPage("InputDropDownAutoPostBackDisplay.aspx");

            var thirdList = new DropDownListTester(IdFor("thirdDropDownList"));
            var fourthList = new DropDownListTester(IdFor("fourthDropDownList"));
            var thirdLabel = new LabelTester(IdFor("thirdDropDownList_readOnly"));
            var fourthLabel = new LabelTester(IdFor("fourthDropDownList_readOnly"));

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

        [Test]
        public void BecomesReadOnlyWhenThereIsASingleValue() {
            LoadOtherPage("InputDropDownAutoPostBackDisplay.aspx");

            var firstList = new DropDownListTester(IdFor("firstDropDownList"));
            var secondList = new DropDownListTester(IdFor("secondDropDownList"));
            var firstLabel = new LabelTester(IdFor("firstDropDownList_readOnly"));
            var secondLabel = new LabelTester(IdFor("secondDropDownList_readOnly"));

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
        public void CanHaveChildControls() {
            var list = new InputDropDownList();
            Assert.IsNotNull(list.Controls[0]);
        }

        [Test]
        public void ClearRevertsSelection() {
            var list = new InputDropDownList();
            list.Items.Add(new ListItem("a", "0"));
            list.Items.Add(new ListItem("b", "1"));
            list.Items.Add(new ListItem("c", "2"));
            list.Items[2].Selected = true;

            list.Clear();

            Assert.AreEqual(0, list.SelectedIndex);
        }

        [Test]
        public void ClearRevertsSelectionAndSelectsInitialBlank() {
            var list = new InputDropDownList();
            list.Items.Add(new ListItem());
            list.Items.Add(new ListItem("a", "0"));
            list.Items.Add(new ListItem("b", "1"));
            list.Items.Add(new ListItem("c", "2"));
            list.Items[2].Selected = true;

            list.Clear();

            Assert.AreEqual(string.Empty, list.SelectedText);
            Assert.AreEqual(0, list.SelectedIndex);
        }

        [Test]
        public void InitialBlankIsSelectedAfterDataBind() {
            var list = new InputDropDownList {InitialBlank = true};
            list.BindList(new[] {1, 2, 3});
            Assert.AreEqual(4, list.Items.Count);
            Assert.IsTrue(list.Items[0].Selected);
        }

        [Test]
        public void IsReadOnlyWhenOnlyASingleValue() {
            LoadOtherPage("InputDropDownReadOnly.aspx");

            var readOnlyListLabel = new LabelTester(IdFor("readOnlyList_readOnly"));
            var readOnlyList = new DropDownListTester(IdFor("readOnlyList"));

            AssertVisibility(readOnlyListLabel, true);
            AssertVisibility(readOnlyList, false);
            AssertEquals("&amp;OrgTest", readOnlyListLabel.Text);
        }

        [Test]
        public void PostBackIsolation() {
            LoadOtherPage("InputDropDownPostBackIsolation.aspx");

            var dropDownList1 = new DropDownListTester(IdFor("DropDownList1"));
            var byProduct1 = new TextBoxTester(IdFor("ByProduct1"));
            var byProduct2 = new TextBoxTester(IdFor("ByProduct2"));

            AssertEquals(byProduct1.Text, "did not fire");
            AssertEquals(byProduct2.Text, "did not fire");

            dropDownList1.SelectedIndex = 2; // <--- a postback happens here
            AssertTrue("Selected index of first drop down list should be the second option", dropDownList1.SelectedIndex == 2);

            AssertEquals(byProduct1.Text, "did fire");
            AssertEquals(byProduct2.Text, "did not fire");
        }

        [Test]
        public void ReadOnlyFalseRendersAsNormal() {
            LoadOtherPage("InputDropDownReadOnly.aspx");

            var readOnlyList = new DropDownListTester(IdFor("readOnlyFalseListMultiItem"));
            var readOnlyListLabel = new LabelTester(IdFor("readOnlyFalseListMultiItem_readOnly"));

            AssertVisibility(readOnlyList, true);
            AssertTrue(readOnlyList.Items.Count > 1);
            AssertVisibility(readOnlyListLabel, false);
        }

        [Test]
        public void ReadOnlyRendersAsLabel() {
            LoadOtherPage("InputDropDownReadOnly.aspx");

            var readOnlyListLabel = new LabelTester(IdFor("readOnlyTrueListMultiItem_readOnly"));
            var readOnlyList = new DropDownListTester(IdFor("readOnlyTrueListMultiItem"));

            AssertVisibility(readOnlyListLabel, true);
            AssertVisibility(readOnlyList, false);
            AssertEquals("Org1", readOnlyListLabel.Text);
        }

        [Test]
        public void RequiredMarkerIsNotVisibleWhenControlIsNotRequired() {
            LoadOtherPage("InputDropDownNotRequired.aspx");
            HtmlControlTester img = new HtmlImageTester(IdFor("DropDownTest_required"));
            WebAssert.NotVisible(img);
        }

        [Test]
        public void RequiredMarkerIsVisibleWhenControlIsRequired() {
            LoadOtherPage("InputDropDownRequired.aspx");
            HtmlControlTester img = new HtmlImageTester(IdFor("DropDownTest_required"));
            WebAssert.Visible(img);
        }

        [Test]
        public void SelectByValue() {
            var list = new InputDropDownList();
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
        public void SelectByValueDeselectsPreviouslySelectedItem() {
            var list = new InputDropDownList();
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
        public void SelectByValueDoesNotFailWhenValueIsNotInList() {
            var list = new InputDropDownList();
            string[] items = {"alpha", "bravo", "charlie"};
            list.DataSource = items;
            list.DataBind();

            list.SelectByValue("zulu");
            AssertTrue(list.Items[0] == list.SelectedItem);
            AssertTrue(list.Items[0].Selected);
            AssertTrue(!list.Items[1].Selected && !list.Items[2].Selected);
        }

        [Test]
        public void SelectByValueInt() {
            var list = new InputDropDownList();
            string[] items = {"1", "2", "3"};
            list.DataSource = items;
            list.DataBind();

            list.SelectByValue(2);
            AssertTrue(list.Items[1].Selected);
            AssertTrue(!list.Items[0].Selected && !list.Items[2].Selected);
        }

        [Test]
        public void SettingDataSourceToNullMakesItemsEmpty() {
            var list = new InputDropDownList();

            list.DataSource = "moo".AsList();
            list.DataBind();
            Assert.IsNotEmpty(list.Items);

            list.DataSource = null;
            list.DataBind();
            Assert.IsEmpty(list.Items);
        }
    }
}
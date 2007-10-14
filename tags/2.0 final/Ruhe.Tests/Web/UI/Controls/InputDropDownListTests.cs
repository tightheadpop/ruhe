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
        public void RequiredMarkerIsNotVisibleWhenControlIsNotRequired() {
            LoadPage("InputDropDownNotRequired.aspx");
            HtmlControlTester img = new HtmlImageTester(IdFor.It("DropDownTest_required"));
            WebAssert.NotVisible(img);
        }

        [Test]
        public void RequiredMarkerIsVisibleWhenControlIsRequired() {
            LoadPage("InputDropDownRequired.aspx");
            HtmlControlTester img = new HtmlImageTester(IdFor.It("DropDownTest_required"));
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
        public void SelectByValueDeselectsPreviouslySelectedItem() {
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
        public void SelectByValueDoesNotFailWhenValueIsNotInList() {
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

            DropDownListTester dropDownList1 = new DropDownListTester(IdFor.It("DropDownList1"));
            TextBoxTester byProduct1 = new TextBoxTester(IdFor.It("ByProduct1"));
            TextBoxTester byProduct2 = new TextBoxTester(IdFor.It("ByProduct2"));

            AssertEquals(byProduct1.Text, "did not fire");
            AssertEquals(byProduct2.Text, "did not fire");

            dropDownList1.SelectedIndex = 2; // <--- a postback happens here
            AssertTrue("Selected index of first drop down list should be the second option", dropDownList1.SelectedIndex == 2);

            AssertEquals(byProduct1.Text, "did fire");
            AssertEquals(byProduct2.Text, "did not fire");
        }

        [Test]
        public void IsReadOnlyWhenOnlyASingleValue() {
            LoadPage("InputDropDownReadOnly.aspx");

            LabelTester readOnlyListLabel = new LabelTester(IdFor.It("readOnlyList_readOnly"));
            DropDownListTester readOnlyList = new DropDownListTester(IdFor.It("readOnlyList"));

            AssertVisibility(readOnlyListLabel, true);
            AssertVisibility(readOnlyList, false);
            AssertEquals("&amp;OrgTest", readOnlyListLabel.Text);
        }

        [Test]
        public void ReadOnlyRendersAsLabel() {
            LoadPage("InputDropDownReadOnly.aspx");

            LabelTester readOnlyListLabel = new LabelTester(IdFor.It("readOnlyTrueListMultiItem_readOnly"));
            DropDownListTester readOnlyList = new DropDownListTester(IdFor.It("readOnlyTrueListMultiItem"));

            AssertVisibility(readOnlyListLabel, true);
            AssertVisibility(readOnlyList, false);
            AssertEquals("Org1", readOnlyListLabel.Text);
        }

        [Test]
        public void ReadOnlyFalseRendersAsNormal() {
            LoadPage("InputDropDownReadOnly.aspx");

            DropDownListTester readOnlyList = new DropDownListTester(IdFor.It("readOnlyFalseListMultiItem"));
            LabelTester readOnlyListLabel = new LabelTester(IdFor.It("readOnlyFalseListMultiItem_readOnly"));

            AssertVisibility(readOnlyList, true);
            AssertTrue(readOnlyList.Items.Count > 1);
            AssertVisibility(readOnlyListLabel, false);
        }

        [Test]
        public void BecomesReadOnlyWhenThereIsASingleValue() {
            LoadPage("InputDropDownAutoPostBackDisplay.aspx");

            DropDownListTester firstList = new DropDownListTester(IdFor.It("firstDropDownList"));
            DropDownListTester secondList = new DropDownListTester(IdFor.It("secondDropDownList"));
            LabelTester firstLabel = new LabelTester(IdFor.It("firstDropDownList_readOnly"));
            LabelTester secondLabel = new LabelTester(IdFor.It("secondDropDownList_readOnly"));

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
        public void BecomesNonReadOnlyWhenSingleValueBecomesMultipleValues() {
            LoadPage("InputDropDownAutoPostBackDisplay.aspx");

            DropDownListTester thirdList = new DropDownListTester(IdFor.It("thirdDropDownList"));
            DropDownListTester fourthList = new DropDownListTester(IdFor.It("fourthDropDownList"));
            LabelTester thirdLabel = new LabelTester(IdFor.It("thirdDropDownList_readOnly"));
            LabelTester fourthLabel = new LabelTester(IdFor.It("fourthDropDownList_readOnly"));

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
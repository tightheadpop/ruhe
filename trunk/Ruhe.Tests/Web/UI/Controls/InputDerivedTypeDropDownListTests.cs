using LiquidSyntax.ForTesting;
using NUnit.Extensions.Asp.AspTester;
using NUnit.Framework;
using Ruhe.Tests.TestExtensions.AspTesters;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Tests.Web.UI.Controls {
    [TestFixture]
    public class InputDerivedTypeDropDownListTests : RuheWebTest<InputDropDownList> {
        private InputDropDownListTester list;
        private InputDropDownListTester otherList;
        private LabelTester label;
        private LabelTester otherLabel;

        protected override string GetUrlPath<R>() {
            return base.GetUrlPath<R>().Replace("InputDropDownList", "InputDerivedTypeDropDownList");
        }

        [Test]
        public void ShouldShowTypeBIsSelectedWhenUserChoosesDisplayNameOfTypeB() {
            list.SelectByValue("Another class that extends Foo");
            label.Text.Should(Be.EqualTo("B"));
        }

        [Test]
        public void ShouldNotAffectTheSelectionOfAnotherSimilarControlOnTheSamePage() {
            list.SelectByValue("Another class that extends Foo");
            otherList.SelectByValue("Yet another class that extends Foo");

            label.Text.Should(Be.EqualTo("B"));
            otherLabel.Text.Should(Be.EqualTo("C"));
        }

        protected override void SetUp() {
            base.SetUp();
            LoadPage();

            list = new InputDropDownListTester(IdFor("list"));
            otherList = new InputDropDownListTester(IdFor("otherList"));

            label = new LabelTester(IdFor("label"));
            otherLabel = new LabelTester(IdFor("otherLabel"));
        }
    }
}
using NUnit.Extensions.Asp.AspTester;
using NUnit.Framework;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Tests.Web.UI.Controls {
    [TestFixture]
    public class UpdateLabelTests : RuheWebTest<UpdateLabel> {
        private LabelTester proof;
        private ButtonTester saveButton;

        [Test]
        public void EmitsStyleScript() {
            StringAssert.Contains(Tests.IdFor.Format("updateLabel", "$get('{0}').style.display = 'inline';"), Browser.CurrentPageText);
        }

        [Test]
        public void RetainsBehavior() {
            saveButton.Click();
            Assert.IsNotEmpty(proof.Text);
        }

        protected override void SetUp() {
            base.SetUp();
            saveButton = new ButtonTester(IdFor("saveButton"));
            proof = new LabelTester(IdFor("proof"));
            LoadPage();
        }
    }
}
using NUnit.Extensions.Asp.AspTester;
using NUnit.Framework;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Tests.Web.UI.Controls {
    [TestFixture]
    public class UpdateLabelTests : RuheWebTest<UpdateLabel> {
        private ButtonTester saveButton;
        private LabelTester proof;

        [Test]
        public void RetainsBehavior() {
            saveButton.Click();
            Assert.IsNotEmpty(proof.Text);
        }

        [Test]
        public void EmitsStyleScript() {
            StringAssert.Contains(Tests.IdFor.Format("updateLabel", "document.getElementById('{0}').style.display = 'inline';"), Browser.CurrentPageText);
        }

        protected override void SetUp() {
            base.SetUp();
            saveButton = new ButtonTester(IdFor("saveButton"));
            proof = new LabelTester(IdFor("proof"));
            LoadPage();
        }
    }
}
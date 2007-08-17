using System;
using NUnit.Extensions.Asp;
using NUnit.Extensions.Asp.AspTester;
using NUnit.Framework;
using Ruhe.TestExtensions;
using Ruhe.TestExtensions.AspTesters;

namespace Ruhe.Tests.Extensions.AspTesters {
	[TestFixture]
	public class GridTesterTests : WebFormTestCase {
		private GridTester gridTester;
		private LabelTester postBackMessage;

		protected override void SetUp() {
			base.SetUp();
			Browser.GetPage(ControlTesterUtilities.GetUrlPath(typeof(GridTester)));
			gridTester = new GridTester("grid", CurrentWebForm);
			postBackMessage = new LabelTester("grid__ctl2_message", CurrentWebForm);
		}

		[Test]
		public void InitialPageState() {
			AssertVisibility(gridTester, true);
			AssertVisibility(postBackMessage, false);
		}

		[Test]
		public void ClickEditButton() {
			gridTester.ClickButton(GridButtonType.Edit, 0); //postback
			AssertEquals("postback", postBackMessage.Text);
		}

		[Test]
		public void EditItemIndex() {
			Console.Write(Browser.CurrentPageText);
			AssertEquals(-1, gridTester.EditItemIndex);
			gridTester.ClickButton(GridButtonType.Edit, 0); //postback
			AssertEquals(0, gridTester.EditItemIndex);

			gridTester.ClickButton(GridButtonType.Cancel, 0);
			gridTester.ClickButton(GridButtonType.Edit, 3);
			AssertEquals(3, gridTester.EditItemIndex);
		}
	}
}
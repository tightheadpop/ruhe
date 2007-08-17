using System;
using NUnit.Extensions.Asp;
using NUnit.Extensions.Asp.AspTester;

namespace Ruhe.TestExtensions.AspTesters {
	public class InputDropDownListTester : DropDownListTester {
		public InputDropDownListTester(string aspID, Tester container) : base(aspID, container) {
			if (aspID.IndexOf(":") > -1)
				throw new ArgumentException("Use element's ID instead of name.");
		}

		public void SelectByValue(string value) {
			for (int i = 0; i < Items.Count; i++) {
				if (Items[i].Value == value) {
					SelectedIndex = i;
					break;
				}
			}
		}

		public void SelectByValue(int value) {
			SelectByValue(value.ToString());
		}

		public string SelectedValue {
			get { return Items[SelectedIndex].Value; }
			set { SelectByValue(value); }
		}
	}
}
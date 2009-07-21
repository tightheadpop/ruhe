using System;
using NUnit.Extensions.Asp.AspTester;

namespace Ruhe.Tests.TestExtensions.AspTesters {
    public class InputDropDownListTester : DropDownListTester {
        public InputDropDownListTester(string aspID) : base(aspID) {
            if (aspID.IndexOf(":") > -1)
                throw new ArgumentException("Use element's ID instead of name.");
        }

        public void SelectByValue(string value) {
            for (var i = 0; i < Items.Count; i++) {
                if (Items[i].Value == value) {
                    SelectedIndex = i;
                    break;
                }
            }
        }

        public void SelectByValue(int value) {
            SelectByValue(value.ToString());
        }
    }
}
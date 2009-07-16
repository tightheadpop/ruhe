using NUnit.Extensions.Asp;

namespace Ruhe.TestExtensions {
    //TODO move to Ruhe.Tests as helper class specific to this project
    public static class ControlTesterUtilities {
        public static bool HasChildElement(this ControlTester tester, string id) {
            return new WebControlTester(id, tester).Visible;
        }
    }
}
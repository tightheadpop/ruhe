using NUnit.Extensions.Asp;

namespace Ruhe.Tests.TestExtensions {
    public static class ControlTesterUtilities {
        public static bool HasChildElement(this ControlTester tester, string id) {
            return new WebControlTester(id, tester).Visible;
        }
    }
}
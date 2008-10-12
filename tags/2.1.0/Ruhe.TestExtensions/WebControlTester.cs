using NUnit.Extensions.Asp;

namespace Ruhe.TestExtensions {
    public class WebControlTester : ControlTester {
        public WebControlTester(string id, Tester container) : base(id, container) {}
    }
}
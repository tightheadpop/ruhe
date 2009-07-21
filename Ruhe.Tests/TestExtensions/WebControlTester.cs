using NUnit.Extensions.Asp;

namespace Ruhe.Tests.TestExtensions {
    public class WebControlTester : ControlTester {
        public WebControlTester(string id, Tester container) : base(id, container) {}
    }
}
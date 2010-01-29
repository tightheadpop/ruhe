using Ruhe.Web;

namespace Ruhe.Tests.Web {
    public class FakeHttpApplication : IHttpApplication {
        public IHttpRequest Request { get; set; }
        public IHttpResponse Response { get; set; }
    }
}
using System.Web;

namespace Ruhe.Web {
    public class HttpApplicationWrapper : IHttpApplication {
        private readonly HttpApplication httpApplication;

        public HttpApplicationWrapper(HttpApplication httpApplication) {
            this.httpApplication = httpApplication;
        }

        public IHttpRequest Request {
            get { return new HttpRequestWrapper(httpApplication.Request); }
        }

        public IHttpResponse Response {
            get { return new HttpResponseWrapper(httpApplication.Response); }
        }
    }
}
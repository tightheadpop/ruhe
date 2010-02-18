using System;
using System.Web;

namespace Ruhe.Web {
    public class HttpRequestWrapper : IHttpRequest {
        private readonly HttpRequest request;

        public HttpRequestWrapper(HttpRequest request) {
            this.request = request;
        }

        public bool IsSecureConnection {
            get { return request.IsSecureConnection; }
        }

        public Uri Url {
            get { return request.Url; }
        }
    }
}
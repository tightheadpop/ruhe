using System.Web;

namespace Ruhe.Web {
    public class HttpResponseWrapper : IHttpResponse {
        private readonly HttpResponse response;

        public HttpResponseWrapper(HttpResponse response) {
            this.response = response;
        }

        public int StatusCode {
            get { return response.StatusCode; }
            set { response.StatusCode = value; }
        }

        public void AddHeader(string name, string value) {
            response.AddHeader(name, value);
        }

        public void Clear() {
            response.Clear();
        }

        public void End() {
            response.End();
        }
    }
}
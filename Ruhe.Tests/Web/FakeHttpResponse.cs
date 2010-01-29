using System.Collections;
using System.Collections.Generic;
using Ruhe.Web;

namespace Ruhe.Tests.Web {
    public class FakeHttpResponse : IHttpResponse {
        public readonly IDictionary Headers = new Dictionary<string, string>();
        
        public FakeHttpResponse() {
            StatusCode = 200;
        }

        public int StatusCode { get; set; }

        public void AddHeader(string name, string value) {
            Headers.Add(name, value);
        }

        public void Clear() {}

        public void End() {}
    }
}
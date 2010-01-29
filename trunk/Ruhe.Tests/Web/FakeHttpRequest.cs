using System;
using Ruhe.Web;

namespace Ruhe.Tests.Web {
    public class FakeHttpRequest : IHttpRequest {
        public bool IsSecureConnection {
            get { return Url.ToString().StartsWith("https"); }
        }

        public Uri Url { get; set; }
    }
}
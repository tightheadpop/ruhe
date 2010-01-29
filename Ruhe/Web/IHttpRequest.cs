using System;

namespace Ruhe.Web {
    public interface IHttpRequest {
        bool IsSecureConnection { get; }
        Uri Url { get; }
    }
}
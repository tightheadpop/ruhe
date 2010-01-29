namespace Ruhe.Web {
    public interface IHttpApplication {
        IHttpRequest Request { get; }
        IHttpResponse Response { get; }
    }
}
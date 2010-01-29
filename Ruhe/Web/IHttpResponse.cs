namespace Ruhe.Web {
    public interface IHttpResponse {
        void Clear();
        int StatusCode { get; set; }
        void AddHeader(string name, string value);
        void End();
    }
}
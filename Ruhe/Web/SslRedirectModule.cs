using System;
using System.Web;

namespace Ruhe.Web {
    public class SslRedirectModule : IHttpModule {
        private void Application_BeginRequest(object sender, EventArgs e) {
            var application = ((HttpApplication) sender);
            HandleRedirect(new HttpApplicationWrapper(application));
        }

        public void Dispose() {}

        public void HandleRedirect(IHttpApplication application) {
            var request = application.Request;
            var response = application.Response;

            if (!request.IsSecureConnection) {
                response.Clear();
                response.StatusCode = 301;
                response.AddHeader("Location", request.Url.ToString().Replace("http", "https"));
                response.End();
            }
        }

        public void Init(HttpApplication application) {
            application.BeginRequest += (Application_BeginRequest);
        }
    }
}
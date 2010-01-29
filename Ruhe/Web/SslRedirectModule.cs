using System;
using System.Web;
using DeftTech.DuckTyping;

namespace Ruhe.Web {
    public class SslRedirectModule : IHttpModule {
        public void Dispose() {}

        public void Init(HttpApplication application) {
            application.BeginRequest += (Application_BeginRequest);
        }

        private void Application_BeginRequest(object sender, EventArgs e) {
            var application = ((HttpApplication) sender);
            HandleRedirect(DuckTyping.Cast<IHttpApplication>(application));
        }

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
    }
}
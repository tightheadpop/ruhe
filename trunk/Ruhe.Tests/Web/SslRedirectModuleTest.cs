using System;
using LiquidSyntax.ForTesting;
using NUnit.Framework;
using Ruhe.Web;

namespace Ruhe.Tests.Web {
    [TestFixture]
    public class SslRedirectModuleTest {
        private FakeHttpApplication application;
        private FakeHttpRequest request;
        private FakeHttpResponse response;

        [SetUp]
        public void SetUp() {
            GivenAnHttpApplication();
        }

        [Test]
        public void NonSslRequestIs301RedirectToSsl() {
            request.Url = new Uri("http://localhost/");

            new SslRedirectModule().HandleRedirect(application);

            response.StatusCode.Should(Be.EqualTo(301));
            response.Headers["Location"].Should(Be.StringStarting("https"));
        }

        [Test]
        public void SslRequestIsNotRedirectd() {
            request.Url = new Uri("https://localhost/");

            new SslRedirectModule().HandleRedirect(application);

            response.StatusCode.Should(Be.EqualTo(200));
            response.Headers["Location"].Should(Be.Null);
        }

        private void GivenAnHttpApplication() {
            application = new FakeHttpApplication();
            request = new FakeHttpRequest();
            response = new FakeHttpResponse();

            application.Request = request;
            application.Response = response;
        }
    }
}
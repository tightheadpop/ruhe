using System;
using System.Diagnostics;
using System.Net.Sockets;
using Ruhe.Configuration;

namespace Ruhe.Web {
    public class AspNetDevelopmentServer : IDisposable {
        private readonly int port;
        private readonly string path;
        private readonly string virtualPath;
        private Process developmentServerProcess;

        public AspNetDevelopmentServer(int port, string path) : this(port, path, string.Empty) {}

        public AspNetDevelopmentServer(int port, string path, string virtualPath) {
            this.port = port;
            this.path = path;
            this.virtualPath = virtualPath;
        }

        public void Start() {
            if (IsServerAlreadyStarted(port))
                return;
            developmentServerProcess =
                new Process {
                    StartInfo = {
                        FileName = RuheConfiguration.DevelopmentServerPath,
                        Arguments = String.Format("/port:{0} /path:\"{1}\" /vpath:\"/{2}\"", port, path, virtualPath),
                        WindowStyle = ProcessWindowStyle.Minimized
                    }
                };
            developmentServerProcess.Start();
        }

        public void Dispose() {
            Stop();
        }

        public void Stop() {
            //taskkill /IM webdev.webserver.exe
            if (developmentServerProcess != null)
                developmentServerProcess.Kill();
        }

        public void DisposeOnAppDomainUnload() {
            AppDomain.CurrentDomain.DomainUnload += (sender, args) => Dispose();
        }

        private static bool IsServerAlreadyStarted(int port) {
            try {
                new TcpClient("localhost", port);
                return true;
            }
            catch (SocketException) {
                return false;
            }
        }
    }
}
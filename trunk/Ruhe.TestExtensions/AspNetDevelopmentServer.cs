using System;
using System.Diagnostics;
using System.Net.Sockets;

namespace Ruhe.TestExtensions {
    public class AspNetDevelopmentServer : IDisposable {
        private readonly Process developmentServerProcess;

        public AspNetDevelopmentServer(int port, string path) : this(port, path, string.Empty) {}

        public AspNetDevelopmentServer(int port, string path, string virtualPath) {
            if (IsServerAlreadyStarted(port))
                return;

            developmentServerProcess = new Process();
            developmentServerProcess.StartInfo.FileName = @"C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\WebDev.WebServer.EXE";
            developmentServerProcess.StartInfo.Arguments = String.Format("/port:{0} /path:\"{1}\" /vpath:\"/{2}\"", port, path, virtualPath);
            developmentServerProcess.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;

            developmentServerProcess.Start();
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

        public void Dispose() {
            //taskkill /IM webdev.webserver.exe
            if (developmentServerProcess != null)
                developmentServerProcess.Kill();
        }
    }
}
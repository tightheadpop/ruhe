using System;
using System.Collections;
using Microsoft.Build.Framework;

namespace Ruhe.Tests.MsBuild {
    public class FakeBuildEngine : IBuildEngine {
        public int ColumnNumberOfTaskNode { get; set; }
        public bool ContinueOnError { get; set; }
        public int LineNumberOfTaskNode { get; set; }
        public string ProjectFileOfTaskNode { get; set; }
        public string LoggedMessage = null;

        public bool BuildProjectFile(string projectFileName, string[] targetNames, IDictionary globalProperties, IDictionary targetOutputs) {
            throw new NotImplementedException();
        }

        public void LogCustomEvent(CustomBuildEventArgs e) {
            throw new NotImplementedException();
        }

        public void LogErrorEvent(BuildErrorEventArgs e) {}

        public void LogMessageEvent(BuildMessageEventArgs e) {
            LoggedMessage = e.Message;
        }

        public void LogWarningEvent(BuildWarningEventArgs e) {
            throw new NotImplementedException();
        }
    }
}
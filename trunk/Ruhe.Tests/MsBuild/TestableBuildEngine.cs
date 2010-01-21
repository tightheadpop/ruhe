using System;
using System.Collections;
using Microsoft.Build.Framework;

namespace Ruhe.Tests.MsBuild {
    public class TestableBuildEngine : IBuildEngine {
        public int ColumnNumberOfTaskNode { get; set; }
        public bool ContinueOnError { get; set; }
        public int LineNumberOfTaskNode { get; set; }
        public string ProjectFileOfTaskNode { get; set; }

        public bool BuildProjectFile(string projectFileName, string[] targetNames, IDictionary globalProperties, IDictionary targetOutputs) {
            throw new NotImplementedException();
        }

        public void LogCustomEvent(CustomBuildEventArgs e) {
            throw new NotImplementedException();
        }

        public void LogErrorEvent(BuildErrorEventArgs e) {}

        public void LogMessageEvent(BuildMessageEventArgs e) {
            throw new NotImplementedException();
        }

        public void LogWarningEvent(BuildWarningEventArgs e) {
            throw new NotImplementedException();
        }
    }
}
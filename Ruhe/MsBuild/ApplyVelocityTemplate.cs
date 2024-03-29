using System;
using System.IO;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using NVelocity;
using NVelocity.App;

namespace Ruhe.MsBuild {
    public class ApplyVelocityTemplate : Task {
        [Required]
        public string TemplateFile { get; set; }

        [Required]
        public string PropertiesFile { get; set; }

        [Required]
        public string OutputFile { get; set; }

        public override bool Execute() {
            try {
                CreateOutputFile();
                Log.LogMessage("Successfully created {0}", OutputFile);
                return true;
            }
            catch (Exception e){
                Log.LogError(e.Message);
                return false;
            }
        }

        private void CreateOutputFile() {
            using (var templateStream = new FileStream(TemplateFile, FileMode.Open, FileAccess.Read)) {
                var context = GetInitializedContext();
                ApplyTemplate(templateStream, context);
            }
        }

        private VelocityContext GetInitializedContext() {
            var context = new VelocityContext();
            using (var propertiesStream = new StreamReader(PropertiesFile)) {
                string line;
                while (null != (line = propertiesStream.ReadLine())) {
                    var pair = line.Split("=".ToCharArray(), 2);
                    if (pair.Length < 2) continue;
                    context.Put(pair[0].Trim(), pair[1].Trim());
                }
            }
            return context;
        }

        public void ApplyTemplate(Stream templateStream, VelocityContext context) {
            var velocity = new VelocityEngine();
            velocity.Init();
            using (var writer = new StreamWriter(OutputFile, false)) {
                velocity.Evaluate(context, writer, "MsBuild", new StreamReader(templateStream));
            }
        }
    }
}
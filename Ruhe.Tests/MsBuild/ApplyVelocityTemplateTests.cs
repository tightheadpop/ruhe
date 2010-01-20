using System.IO;
using System.Reflection;
using LiquidSyntax;
using LiquidSyntax.ForTesting;
using Microsoft.Build.Utilities;
using NUnit.Framework;
using Ruhe.MsBuild;

namespace Ruhe.Tests.MsBuild {
    [TestFixture]
    public class ApplyVelocityTemplateTests {
        private static readonly string outputFile = Path.GetTempFileName();
        private static readonly string propertiesFile = GetResourceName("Properties.txt");
        private static readonly string templateFile = GetResourceName("Template.txt");
        private static readonly string templateFileWithError = GetResourceName("TemplateWithError.txt");
        private Task task;

        [TearDown]
        public void TearDown() {
            File.Delete(outputFile);
        }

        [Test]
        public void CreatesOutputFileWithSubstitutionsMade() {
            GivenAValidTemplate();
            task.Execute();
            File.ReadAllText(outputFile).Should(Be.EqualTo(@"Old McDonald had a farm.
On that farm, he had a cow that says ""moo.""
The text here should contain an equal sign: a=b=c"));
        }

        [Test]
        public void ErrorMessageIsWrittenToLog() {
            GivenAInvalidTemplate();
            task.Execute();
            task.Log.HasLoggedErrors.Should(Be.True);

            GivenAValidTemplate();
            task.Execute();
            task.Log.HasLoggedErrors.Should(Be.False);
        }

        [Test]
        public void ReturnsTrueIfSuccessful() {
            GivenAValidTemplate();
            Assert.IsTrue(task.Execute());
        }

        private static string GetResourceName(string shortName) {
            var uri = Assembly.GetExecutingAssembly().CodeBase;
            var path = Path.GetDirectoryName(uri.WithoutPrefix("file:///").Replace('/', '\\'));
            return Path.Combine(path, @"..\..\Resources\" + shortName);
        }

        private void GivenAInvalidTemplate() {
            task = new ApplyVelocityTemplate {
                TemplateFile = templateFileWithError,
                PropertiesFile = propertiesFile,
                OutputFile = outputFile,
                BuildEngine = new TestableBuildEngine()
            };
        }

        private void GivenAValidTemplate() {
            task = new ApplyVelocityTemplate {
                TemplateFile = templateFile,
                PropertiesFile = propertiesFile,
                OutputFile = outputFile,
                BuildEngine = new TestableBuildEngine()
            };
        }
    }
}
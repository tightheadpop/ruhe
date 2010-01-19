using System.IO;
using System.Reflection;
using LiquidSyntax;
using Microsoft.Build.Utilities;
using NUnit.Framework;
using Ruhe.MsBuild;
using LiquidSyntax.ForTesting;

namespace Ruhe.Tests.MsBuild {
    [TestFixture]
    public class ApplyVelocityTemplateTests {
        private static readonly string outputFile = Path.GetTempFileName();
        private static readonly string templateFile = GetResourceName("Template.txt");
        private static readonly string propertiesFile = GetResourceName("Properties.txt");
        private Task task;

        [Test]
        public void CreatesOutputFileWithSubstitutionsMade() {
            task.Execute();
            File.ReadAllText(outputFile).Should(Be.EqualTo(@"Old McDonald had a farm.
On that farm, he had a cow that says ""moo.""
The text here should contain an equal sign: a=b=c"));
        }

        [Test]
        public void ReturnsTrueIfSuccessful() {
            Assert.IsTrue(task.Execute());
        }

        [SetUp]
        public void SetUp() {
            task = new ApplyVelocityTemplate {TemplateFile = templateFile, PropertiesFile = propertiesFile, OutputFile = outputFile};
        }

        [TearDown]
        public void TearDown() {
            File.Delete(outputFile);
        }

        private static string GetResourceName(string shortName) {
            var uri = Assembly.GetExecutingAssembly().CodeBase;
            var path = Path.GetDirectoryName(uri.WithoutPrefix("file:///").Replace('/', '\\'));
            return Path.Combine(path, @"..\..\Resources\" + shortName);
        }
    }
}
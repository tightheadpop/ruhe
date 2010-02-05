using System.Web.UI;
using LiquidSyntax;

namespace Ruhe.Tests.Web.UI {
    public class ScriptReference : ScriptReferenceBase {
        private System.Web.UI.ScriptReference fromAssembly;

        public ScriptReference() {
            fromAssembly = new System.Web.UI.ScriptReference("Ruhe.Web.Resources.ruhe.js", GetType().Assembly.FullName);
        }

        protected override bool IsFromSystemWebExtensions() {
            return false;
        }

        protected override string GetUrl(ScriptManager scriptManager, bool zip) {
            return (string) fromAssembly.InvokeMethod("GetUrl", new object[] {scriptManager, zip});
        }
    }
}
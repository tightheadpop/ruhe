using System.Web;

namespace Ruhe.Web {
    public class WebUtilities {
        public static bool IsHttpContext {
            get { return HttpContext.Current != null; }
        }

        public static bool BrowserIsInternetExplorer {
            get {
                if (IsHttpContext)
                    return HttpContext.Current.Request.Browser.Browser == "IE";
                return false;
            }
        }
    }
}
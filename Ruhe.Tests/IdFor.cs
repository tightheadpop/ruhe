namespace Ruhe.Tests {
    public class IdFor {
        public static string It(string baseId) {
            return "ajax_content_" + baseId;
        }

        public static string Format(string baseId, string format) {
            return string.Format(format, It(baseId));
        }
    }
}
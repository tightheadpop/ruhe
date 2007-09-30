using System.Collections;

namespace Ruhe.Common.Utilities {
    public class Collections {
        private Collections() {}

        public static object First(object[] collection) {
            if (collection.Length > 0) {
                return collection[0];
            }
            return null;
        }

        public static string First(string[] collection) {
            return (string) First((object[]) collection);
        }

        public static object First(ICollection list) {
            return First(new ArrayList(list).ToArray());
        }
    }
}
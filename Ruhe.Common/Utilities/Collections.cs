using System;
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

        public static object First(ICollection collection) {
            return First(new ArrayList(collection).ToArray());
        }

        public static T First<T>(IEnumerable collection, Predicate<T> predicate) {
            foreach (object item in collection) {
                if (item is T && predicate((T) item))
                    return (T) item;
            }
            return default(T);
        }
    }
}
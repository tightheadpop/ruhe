using System;
using System.Collections;
using System.Collections.Generic;

namespace Ruhe.Common.Utilities {
    public class Collections {
        private Collections() {}

        public static T First<T>(IEnumerable<T> collection) {
            return First<T>(collection, delegate { return true; });
        }

        public static object First(IEnumerable collection) {
            foreach (object o in collection) {
                return o;
            }
            return null;
        }

        public static T First<T>(IEnumerable collection, Predicate<T> predicate) {
            foreach (object item in collection) {
                if (item is T && predicate((T) item))
                    return (T) item;
            }
            return default(T);
        }

        public static T Last<T>(IEnumerable<T> list) {
            T result = default(T);
            foreach (T t in list) {
                result = t;
            }
            return result;
        }

        public static T Shift<T>(ICollection<T> items) {
            T result = First(items);
            items.Remove(result);
            return result;
        }
    }
}
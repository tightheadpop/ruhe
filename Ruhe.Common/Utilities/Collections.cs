using System;
using System.Collections;
using System.Collections.Generic;

namespace Ruhe.Common.Utilities {
    public static class Collections {
        public static T First<T>(this IEnumerable<T> collection) {
            return collection.First<T>(delegate { return true; });
        }

        public static object First(this IEnumerable collection) {
            foreach (object o in collection) {
                return o;
            }
            return null;
        }

        public static T First<T>(this IEnumerable collection, Predicate<T> predicate) {
            foreach (object item in collection) {
                if (item is T && predicate((T) item))
                    return (T) item;
            }
            return default(T);
        }

        public static T Last<T>(this IEnumerable<T> list) {
            T result = default(T);
            foreach (T t in list) {
                result = t;
            }
            return result;
        }

        public static T Shift<T>(this ICollection<T> items) {
            T result = items.First();
            items.Remove(result);
            return result;
        }
    }
}
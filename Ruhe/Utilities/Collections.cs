using System;
using System.Collections;
using System.Collections.Generic;

namespace Ruhe.Utilities {
    public static class Collections {
        public static T First<T>(this IEnumerable<T> collection) {
            return collection.First<T>(delegate { return true; });
        }

        public static object First(this IEnumerable collection) {
            foreach (var o in collection) {
                return o;
            }
            return null;
        }

        public static T First<T>(this IEnumerable collection, Predicate<T> predicate) {
            foreach (var item in collection) {
                if (item is T && predicate((T) item))
                    return (T) item;
            }
            return default(T);
        }

        public static T Last<T>(this IEnumerable<T> list) {
            var result = default(T);
            foreach (var t in list) {
                result = t;
            }
            return result;
        }

        public static T Shift<T>(this ICollection<T> items) {
            var result = items.First();
            items.Remove(result);
            return result;
        }

        public static void AddRange<T>(this ICollection<T> list, IEnumerable<T> toAdd) {
            foreach (var t in toAdd) {
                list.Add(t);
            }
        }

        public static List<TOutput> ConvertAll<T, TOutput>(this IEnumerable<T> list, Converter<T, TOutput> converter) {
            return new List<T>(list).ConvertAll(converter);
        }

        public static bool Contains<T>(this IEnumerable<T> list, object o) {
            foreach (var t in list) {
                if (Equals(t, o))
                    return true;
            }
            return false;
        }
    }
}
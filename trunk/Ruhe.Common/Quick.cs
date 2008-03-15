using System;
using System.Collections.Generic;
using Ruhe.Common.Utilities;

namespace Ruhe.Common {
    /// <summary>
    /// Function bucket for generating different enumerables quickly.
    /// </summary>
    public class Quick {
        public static Dictionary<K, V> Dictionary<K, V>(params object[] keyValuePairs) {
            Validate.That(keyValuePairs.Length % 2 == 0, "arguments must be in pairs");
            Dictionary<K, V> result = new Dictionary<K, V>();
            for (int i = 0; i < keyValuePairs.Length; i += 2) {
                result.Add((K) keyValuePairs[i], (V) keyValuePairs[i + 1]);
            }
            return result;
        }

        /// <summary>
        /// Requires ICollection to indicate order must be preserved between keys and values.
        /// </summary>
        public static Dictionary<K, V> Dictionary<K, V>(ICollection<K> keys, ICollection<V> values) {
            Validate.IsTrue(keys.Count == values.Count, "must have the same number of keys and values");
            Dictionary<K, V> result = new Dictionary<K, V>();
            keys = new List<K>(keys);
            values = new List<V>(values);
            int initialCount = keys.Count;
            for (int i = 0; i < initialCount; i++) {
                K key = Collections.Shift(keys);
                V value = Collections.Shift(values);
                result.Add(key, value);
            }
            return result;
        }

        public static Dictionary<K, V> Dictionary<K, V>(string propertyName, IEnumerable<V> values) {
            List<V> myValues = new List<V>(values);
            List<K> keys = myValues.ConvertAll<K>(delegate(V input) { return (K) Reflector.GetPropertyValue(input, propertyName); });
            return Dictionary(keys, myValues);
        }

        public static List<T> List<T>(IEnumerable<T> items) {
            return new List<T>(items);
        }

        public static List<T> List<T>(params T[] items) {
            return new List<T>(items);
        }

        public static string[] StringArray(params object[] items) {
            return List(items).ConvertAll<string>(delegate(object o) { return Convert.ToString(o); }).ToArray();
        }

        public static T[] Array<T>(params T[] items) {
            return items;
        }

        public static string Join(string delimiter, params object[] items) {
            return string.Join(delimiter, StringArray(items));
        }

        public static string Join(params object[] items) {
            return Join(", ", items);
        }
    }
}
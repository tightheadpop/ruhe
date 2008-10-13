using System.Collections.Generic;
using Ruhe.Common.Utilities;

namespace Ruhe.Common {
    /// <summary>
    /// Function bucket for generating different enumerables.
    /// </summary>
    public class Quick {
        public static T[] Array<T>(params T[] items) {
            return items;
        }

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
            (keys.Count == values.Count).MustBeTrue("must have the same number of keys and values");
            Dictionary<K, V> result = new Dictionary<K, V>();
            keys = new List<K>(keys);
            values = new List<V>(values);
            int initialCount = keys.Count;
            for (int i = 0; i < initialCount; i++) {
                K key = keys.Shift();
                V value = values.Shift();
                result.Add(key, value);
            }
            return result;
        }

        public static Dictionary<K, V> Dictionary<K, V>(string propertyName, IEnumerable<V> values) {
            List<V> myValues = new List<V>(values);
            List<K> keys = myValues.ConvertAll<K>(delegate(V input) { return (K) input.GetPropertyValue(propertyName); });
            return Dictionary(keys, myValues);
        }

        public static string Join(string delimiter, params object[] items) {
            return string.Join(delimiter, StringArray((IEnumerable<object>) items));
        }

        public static string Join<T>(string delimiter, IEnumerable<T> items) {
            return string.Join(delimiter, StringArray(items));
        }

        public static string Join(params object[] items) {
            return Join(", ", items);
        }

        public static string Join<T>(IEnumerable<T> items) {
            return Join(", ", items);
        }

        public static List<T> List<T>(IEnumerable<T> items) {
            return new List<T>(items);
        }

        public static List<T> List<T>(params T[] items) {
            return new List<T>(items);
        }

        public static string[] StringArray(params object[] items) {
            return new List<object>(items).ConvertAll(o => o.ToString()).ToArray();
        }

        public static string[] StringArray<T>(IEnumerable<T> items) {
            return List(items).ConvertAll(
                o => o == null ? string.Empty : o.ToString()).ToArray();
        }
    }
}
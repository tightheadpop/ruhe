using System.Collections.Generic;

namespace Ruhe.Common {
    /// <summary>
    /// Function bucket for generating different enumerables quickly.
    /// </summary>
    public class Quick {
        public static List<T> List<T>(IEnumerable<T> items) {
            return new List<T>(items);
        }

        public static List<T> List<T>(params T[] items) {
            return new List<T>(items);
        }
    }
}
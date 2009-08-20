using System.Collections.Generic;

namespace Ruhe {
    public class MultiMapSet<TKey, TValueInSet> {
        private readonly IDictionary<TKey, HashSet<TValueInSet>> map = new Dictionary<TKey, HashSet<TValueInSet>>();

        public IEnumerable<TKey> Keys {
            get { return map.Keys; }
        }

        public IEnumerable<HashSet<TValueInSet>> Values {
            get { return map.Values; }
        }

        public void Add(TKey key, TValueInSet valueInSet) {
            if (map.ContainsKey(key)) {
                map[key].Add(valueInSet);
            } else {
                map.Add(key, new HashSet<TValueInSet> {valueInSet});
            }
        }

        public HashSet<TValueInSet> this[TKey key] {
            get { return map[key]; }
        }

        public bool ContainsKey(TKey key) {
            return map.ContainsKey(key);
        }
    }
}
using System;
using System.Collections.Generic;
using NUnit.Framework;
using Ruhe.Common;

namespace Ruhe.Tests.Common {
    [TestFixture]
    public class QuickTests {
        [Test]
        public void Array() {
            Assert.AreEqual(new int[] {4, 3, 2, 1}, Quick.Array(4, 3, 2, 1));
        }

        [Test]
        public void Dictionary() {
            Dictionary<string, int> dictionary = Quick.Dictionary<string, int>("a", 19, "b", 42);
            Assert.AreEqual(2, dictionary.Count);
            Assert.AreEqual(19, dictionary["a"]);
            Assert.AreEqual(42, dictionary["b"]);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void DictionaryExpectsEvenNumberOfItems() {
            Quick.Dictionary<string, int>("a", 19, "b");
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void DictionaryFromTwoCollectionsRequiresSameSize() {
            Quick.Dictionary(Quick.List("a"), Quick.List(1, 2, 3));
        }

        [Test]
        public void DictionaryKeyedByComplexProperty() {
            Bar bar1 = new Bar(new Foo("p"));
            Bar bar2 = new Bar(new Foo("q"));
            Dictionary<string, Bar> dictionary = Quick.Dictionary<string, Bar>("Foo.ID", Quick.List(bar1, bar2));
            Assert.AreEqual(2, dictionary.Count);
            Assert.AreSame(bar1, dictionary["p"]);
            Assert.AreSame(bar2, dictionary["q"]);
        }

        [Test]
        [ExpectedException(typeof(InvalidCastException))]
        public void DictionaryRequiresCorrectTypesInPairs() {
            Quick.Dictionary<string, int>("a", 19, "b", "p");
        }

        [Test]
        public void DisctionaryByCombiningTwoCollections() {
            List<string> keys = Quick.List("a", "b");
            List<int> values = Quick.List(4, 89);
            Dictionary<string, int> dictionary = Quick.Dictionary(keys, values);
            Assert.AreEqual(2, dictionary.Count);
            Assert.AreEqual(4, dictionary["a"]);
            Assert.AreEqual(89, dictionary["b"]);

            Assert.AreEqual(2, keys.Count, "original key list should be unchanged");
            Assert.AreEqual(2, values.Count, "original value list should be unchanged");
        }

        [Test]
        public void Join() {
            Assert.AreEqual("4-5--2", Quick.Join("-", 4, 5, null, 2));
            Assert.AreEqual("4, 5, , 2", Quick.Join(4, 5, null, 2));
        }

        [Test]
        public void ListFromEnumerable() {
            Assert.AreEqual(new string[] {"a", "b", "c"}, Quick.List(new string[] {"a", "b", "c"}));
        }

        [Test]
        public void ListFromIndividualItems() {
            Assert.AreEqual(new string[] {"a", "b", "c"}, Quick.List("a", "b", "c"));
        }

        [Test]
        public void StringArray() {
            Assert.AreEqual(new string[] {"1", "2", "3"}, Quick.StringArray(1, 2, 3));
        }

        private class Bar {
            private readonly Foo foo;

            public Bar(Foo foo) {
                this.foo = foo;
            }

            public Foo Foo {
                get { return foo; }
            }
        }

        private class Foo {
            private readonly string id;

            public Foo(string id) {
                this.id = id;
            }

            public string ID {
                get { return id; }
            }
        }
    }
}
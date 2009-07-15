using System;
using NUnit.Framework;

namespace Ruhe.Tests {
    [TestFixture]
    public class QuickTests {
        [Test]
        public void Array() {
            Assert.AreEqual(new[] {4, 3, 2, 1}, Quick.Array(4, 3, 2, 1));
        }

        [Test]
        public void Dictionary() {
            var dictionary = Quick.Dictionary<string, int>("a", 19, "b", 42);
            Assert.AreEqual(2, dictionary.Count);
            Assert.AreEqual(19, dictionary["a"]);
            Assert.AreEqual(42, dictionary["b"]);
        }

        [Test]
        public void DictionaryExpectsEvenNumberOfItems() {
            try {
                Quick.Dictionary<string, int>("a", 19, "b");
                Assert.Fail();
            }
            catch (ArgumentException) {
            }
        }

        [Test]
        public void DictionaryFromTwoCollectionsRequiresSameSize() {
            try {
                Quick.Dictionary(Quick.List("a"), Quick.List("1", "2", "3"));
                Assert.Fail();
            }
            catch (ArgumentException) {
            }
        }

        [Test]
        public void DictionaryKeyedByComplexProperty() {
            var bar1 = new Bar(new Foo("p"));
            var bar2 = new Bar(new Foo("q"));
            var dictionary = Quick.Dictionary<string, Bar>("Foo.ID", Quick.List(bar1, bar2));
            Assert.AreEqual(2, dictionary.Count);
            Assert.AreSame(bar1, dictionary["p"]);
            Assert.AreSame(bar2, dictionary["q"]);
        }

        [Test]
        public void DictionaryRequiresCorrectTypesInPairs() {
            try {
                Quick.Dictionary<string, int>("a", 19, "b", "p");
                Assert.Fail();
            }
            catch (InvalidCastException) {
            }
        }

        [Test]
        public void DisctionaryByCombiningTwoCollections() {
            var keys = Quick.List("a", "b");
            var values = Quick.List("4", "89");
            var dictionary = Quick.Dictionary(keys, values);
            Assert.AreEqual(2, dictionary.Count);
            Assert.AreEqual("4", dictionary["a"]);
            Assert.AreEqual("89", dictionary["b"]);

            Assert.AreEqual(2, keys.Count, "original key list should be unchanged");
            Assert.AreEqual(2, values.Count, "original value list should be unchanged");
        }

        [Test]
        public void Join() {
            Assert.AreEqual("4-5--2", Quick.Join("-", 4, 5, null, 2));
            Assert.AreEqual("4, 5, , 2", Quick.Join(4, 5, null, 2));
        }

        [Test]
        public void JoinIEnumerable() {
            Assert.AreEqual("4-5--2", Quick.Join("-", Quick.List<object>(4, 5, null, 2)));
            Assert.AreEqual("4, 5, , 2", Quick.Join(Quick.List<object>(4, 5, null, 2)));
        }

        [Test]
        public void ListFromIndividualItems() {
            Assert.AreEqual(new[] {"a", "b", "c"}, Quick.List("a", "b", "c"));
        }

        [Test]
        public void Set() {
            var set = Quick.Set(1, 2, 3, 3);
            Assert.AreEqual(3, set.Count);
            Assert.IsTrue(set.Contains(1));
            Assert.IsTrue(set.Contains(2));
            Assert.IsTrue(set.Contains(3));
        }

        [Test]
        public void StringArray() {
            Assert.AreEqual(new[] {"1", "2", "3"}, Quick.StringArray(1, 2, 3));
        }

        [Test]
        public void StringArrayFromIEnumerable() {
            Assert.AreEqual(new[] {"1", "2", "3"}, Quick.StringArray(Quick.List(1, 2, 3)));
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
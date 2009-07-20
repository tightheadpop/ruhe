using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web.UI;
using System.Web.UI.WebControls;
using NUnit.Framework;
using Ruhe.Common;
using Ruhe.Common.Utilities;

namespace Ruhe.Tests.Common {
    [TestFixture]
    public class CollectionsTest {
        [Test]
        public void FindFirstTypeThatSatisfiesPredicate() {
            ArrayList list = new ArrayList();
            list.Add(new DateTime());
            Literal expected = new Literal();
            expected.ID = "expected";
            list.Add(expected);
            Literal notExpected = new Literal();
            notExpected.ID = "notExpected";
            list.Add(notExpected);

            Control actual = Collections.First<Control>(list, delegate(Control c) { return c.ID == "expected"; });
            Assert.AreSame(expected, actual);
        }

        [Test]
        public void FirstForCollection() {
            StringCollection collection = new StringCollection();
            Assert.AreEqual(null, Collections.First(collection));

            collection.Add("1");
            collection.Add("foo");
            Assert.AreEqual("1", Collections.First(collection));
        }

        [Test]
        public void FirstForObjectArray() {
            Assert.AreEqual(1, Collections.First(new object[] {1, 2, 3}));
            Assert.AreEqual(null, Collections.First(new object[] {}));
        }

        [Test]
        public void FirstForStringArray() {
            Assert.AreEqual("foo", Collections.First(new object[] {"foo", "bar", "baz"}));
            Assert.AreEqual(null, Collections.First(new string[] {}));
        }

        [Test]
        public void Last() {
            Assert.AreEqual("last", Collections.Last(Quick.List("first", "middle", "last")));
        }

        [Test]
        public void LastReturnsNullForEmptyList() {
            Assert.IsNull(Collections.Last(new object[] {}));
        }

        [Test]
        public void Shift() {
            List<int> list = Quick.List(1, 2, 3);
            Assert.AreEqual(1, Collections.Shift(list));
            Assert.AreEqual(2, list.Count);
        }
    }
}
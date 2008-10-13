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

            Control actual = list.First(delegate(Control c) { return c.ID == "expected"; });
            Assert.AreSame(expected, actual);
        }

        [Test]
        public void FirstForCollection() {
            StringCollection collection = new StringCollection();
            Assert.AreEqual(null, collection.First());

            collection.Add("1");
            collection.Add("foo");
            Assert.AreEqual("1", collection.First());
        }

        [Test]
        public void FirstForObjectArray() {
            Assert.AreEqual(1, new object[] {1, 2, 3}.First());
            Assert.AreEqual(null, new object[] {}.First());
        }

        [Test]
        public void FirstForStringArray() {
            Assert.AreEqual("foo", new object[] {"foo", "bar", "baz"}.First());
            Assert.AreEqual(null, new string[] {}.First());
        }

        [Test]
        public void Last() {
            Assert.AreEqual("last", Quick.List("first", "middle", "last").Last());
        }

        [Test]
        public void LastReturnsNullForEmptyList() {
            Assert.IsNull(new object[] {}.Last());
        }

        [Test]
        public void Shift() {
            List<int> list = Quick.List(1, 2, 3);
            Assert.AreEqual(1, list.Shift());
            Assert.AreEqual(2, list.Count);
        }
    }
}
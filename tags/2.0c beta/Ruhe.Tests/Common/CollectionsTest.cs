using System.Collections.Specialized;
using NUnit.Framework;
using Ruhe.Common.Utilities;

namespace Ruhe.Tests.Common {
	[TestFixture]
	public class CollectionsTest {
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
		public void FirstForCollection() {
			StringCollection collection = new StringCollection();
			Assert.AreEqual(null, Collections.First(collection));

			collection.Add("1");
			collection.Add("foo");
			Assert.AreEqual("1", Collections.First(collection));
		}
	}
}
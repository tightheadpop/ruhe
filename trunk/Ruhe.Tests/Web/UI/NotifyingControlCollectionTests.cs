using System.Web.UI;
using NUnit.Framework;
using Ruhe.Web.UI;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Tests.Web.UI {
    [TestFixture]
    public class NotifyingControlCollectionTests {
        [Test]
        public void RaisesChildControlAddedEventWhenAddAtIsCalled() {
            Control actual = null;
            NotifyingControlCollection collection = new NotifyingControlCollection(new EncodedLabel());
            collection.ChildControlAdded += delegate(object sender, ControlAddedEventArgs a) { actual = a.ChildControl; };
            NonBreakingSpace expected = new NonBreakingSpace();
            collection.AddAt(0, expected);
            Assert.AreSame(expected, actual);
        }

        [Test]
        public void RaisesChildControlAddedEventWhenAddIsCalled() {
            Control actual = null;
            NotifyingControlCollection collection = new NotifyingControlCollection(new EncodedLabel());
            collection.ChildControlAdded += delegate(object sender, ControlAddedEventArgs a) { actual = a.ChildControl; };
            NonBreakingSpace expected = new NonBreakingSpace();
            collection.Add(expected);
            Assert.AreSame(expected, actual);
        }

        [Test]
        public void CanCallAddAtWithoutRaisingEvent() {
            Control actual = null;
            NotifyingControlCollection collection = new NotifyingControlCollection(new EncodedLabel());
            collection.ChildControlAdded += delegate(object sender, ControlAddedEventArgs a) { actual = a.ChildControl; };
            NonBreakingSpace expected = new NonBreakingSpace();
            collection.AddAt(0, expected, false);
            Assert.IsNull(actual);
        }
    }
}
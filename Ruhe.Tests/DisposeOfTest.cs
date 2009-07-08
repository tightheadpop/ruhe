using System;
using System.Collections.Generic;
using NUnit.Framework;
using Ruhe.Utilities;

namespace Ruhe.Tests {
    [TestFixture]
    public class DisposeOfTest {
        [Test]
        public void DisposeOfListDisposesAllItemsInList() {
            var foo = new Foo();
            var bar = new Foo();

            Quick.List(foo, bar).Dispose();
            Assert.IsTrue(foo.Disposed);
            Assert.IsTrue(bar.Disposed);
        }

        [Test]
        public void DisposeQuietlyOfIDisposableSuppressesExceptions() {
            var exceptionThrowingDisposable = new ExceptionThrowingDisposable();
            exceptionThrowingDisposable.DisposeQuietly();
            Assert.IsTrue(exceptionThrowingDisposable.disposed);
        }

        [Test]
        public void DisposeQuietlyOfNullThrowsNoException() {
            ((IDisposable) null).DisposeQuietly();
        }

        [Test]
        [ExpectedException(typeof(ApplicationException))]
        public void DisposingListDoesNotStifleExceptions() {
            Quick.List<IDisposable>(new ExceptionThrowingDisposable()).Dispose();
        }

        [Test]
        public void DisposingListIgnoresNulls() {
            Quick.List((IDisposable) null).Dispose();
        }

        [Test]
        public void DisposingListsIgnoresNullList() {
            ((IEnumerable<IDisposable>) null).Dispose();
        }

        [Test]
        public void DisposingListsQuietlyIgnoresNullList() {
            ((IEnumerable<IDisposable>) null).DisposeQuietly();
        }

        [Test]
        public void DisposingListsQuietlyIgnoresNulls() {
            Quick.List((IDisposable) null).DisposeQuietly();
        }

        [Test]
        public void QuietlyDisposingListStiflesExceptions() {
            var item = new ExceptionThrowingDisposable();
            Quick.List(item).DisposeQuietly();
            Assert.IsTrue(item.disposed);
        }

        private class ExceptionThrowingDisposable : IDisposable {
            public bool disposed;

            public void Dispose() {
                disposed = true;
                throw new ApplicationException("Simulate a fatal disposal.");
            }
        }

        private class Foo : IDisposable {
            public bool Disposed;

            public void Dispose() {
                Disposed = true;
            }
        }
    }
}
using System;
using System.Data;
using System.IO;
using NUnit.Framework;
using Ruhe.Common;

namespace Ruhe.Tests.Common {
    [TestFixture]
    public class DisposeOfTest {
        [Test]
        public void DisposeOfIDisposable() {
            Foo disposable = new Foo();
            DisposeOf.These(disposable);
            Assert.IsTrue(disposable.Disposed);
        }

        [Test]
        public void DisposeOfNullThrowsNoException() {
            DisposeOf.These(null);
        }

        [Test]
        public void DisposeOfClosesAndDisposes() {
            FooConnection foo = new FooConnection();
            DisposeOf.These(foo);
            Assert.IsTrue(foo.Closed);
            Assert.IsTrue(foo.Disposed);
        }

        [Test]
        public void DisposeOfFlushesAndCloses() {
            FooWriter writer = new FooWriter();
            DisposeOf.These(writer);
            Assert.IsTrue(writer.Flushed);
            Assert.IsTrue(writer.Closed);
        }

        [Test]
        [ExpectedException(typeof(ApplicationException))]
        public void DisposingDoesNotStifleExceptions() {
            DisposeOf.These(new ExceptionThrowingDisposable());
        }

        [Test]
        public void DisposeOfCollectionOfStreamWritersCallsClose() {
            FooWriter first = new FooWriter();
            FooWriter second = new FooWriter();
            DisposeOf.These(Quick.List(first, second));
            Assert.IsTrue(first.Closed);
            Assert.IsTrue(first.Disposed);
            Assert.IsTrue(second.Closed);
            Assert.IsTrue(second.Disposed);
        }

        #region Test Classes

        private class ExceptionThrowingDisposable : IDisposable {
            public void Dispose() {
                throw new ApplicationException("Simulate a fatal disposal.");
            }
        }

        private class FooWriter : StreamWriter {
            private bool _closed;
            private bool _flushed;
            public bool Disposed;
            public FooWriter() : base(new MemoryStream()) {}

            public bool Closed {
                get { return _closed; }
            }

            public bool Flushed {
                get { return _flushed; }
            }

            public override void Close() {
                _closed = true;
            }

            public override void Flush() {
                _flushed = true;
            }

            protected override void Dispose(bool disposing) {
                Disposed = true;
                base.Dispose(disposing);
            }
        }

        private class Foo : IDisposable {
            public bool Disposed;

            public void Dispose() {
                Disposed = true;
            }
        }

        private class FooConnection : IDbConnection {
            private bool _closed = false;
            private bool _disposed = false;

            public IDbTransaction BeginTransaction() {
                throw new NotImplementedException();
            }

            public IDbTransaction BeginTransaction(IsolationLevel il) {
                throw new NotImplementedException();
            }

            public void Close() {
                _closed = true;
            }

            public void ChangeDatabase(string databaseName) {
                throw new NotImplementedException();
            }

            public IDbCommand CreateCommand() {
                throw new NotImplementedException();
            }

            public void Open() {
                throw new NotImplementedException();
            }

            public string ConnectionString {
                get { throw new NotImplementedException(); }
                set { throw new NotImplementedException(); }
            }

            public int ConnectionTimeout {
                get { throw new NotImplementedException(); }
            }

            public string Database {
                get { throw new NotImplementedException(); }
            }

            public ConnectionState State {
                get { throw new NotImplementedException(); }
            }

            public bool Closed {
                get { return _closed; }
            }

            public bool Disposed {
                get { return _disposed; }
            }

            public void Dispose() {
                _disposed = true;
            }
        }

        #endregion
    }
}
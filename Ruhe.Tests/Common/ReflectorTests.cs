using System;
using System.Collections;
using System.Reflection;
using NUnit.Framework;
using Ruhe.Common;

namespace Ruhe.Tests.Common {
    [TestFixture]
    public class ReflectorTests {
        [Test]
        public void GetCrossAssemblyType() {
            Assert.IsNotNull(Reflector.GetCrossAssemblyType("Ruhe.Web", "Ruhe.Web.QueryStringBuilder"));
        }

        [Test]
        public void IsIList() {
            TestObject testObject = new TestObject();
            PropertyInfo property = Reflector.GetProperty(testObject, "List");
            Assert.IsTrue(Reflector.IsIList(property));
        }

        [Test]
        public void InvokePublicMethod() {
            TestObject testObject = new TestObject();
            object result = Reflector.InvokeMethod(testObject, "Get");
            Assert.IsTrue(result.GetType().Equals(typeof(string)));
            Assert.AreEqual("set", result);
        }

        [Test]
        public void InvokeNonPublicMethod() {
            TestObject testObject = new TestObject();

            object result = Reflector.InvokeMethod(testObject, "Set");
            Assert.IsNull(result);
            Assert.IsTrue(testObject.VerifySet);
        }

        [Test]
        public void GetPropertyValue() {
            TestObject testObject = new TestObject();
            Assert.AreEqual(false, Reflector.GetPropertyValue(testObject, "VerifySet"));
        }

        [Test]
        public void SetPropertyValue() {
            TestObject testObject = new TestObject();
            Reflector.SetPropertyValue(testObject, "VerifySet", true);
            Assert.AreEqual(true, testObject.VerifySet);
        }

        [Test]
        public void SetPropertyValueAsEnum() {
            TestObject testObject = new TestObject();
            Reflector.SetPropertyValue(testObject, "TestEnum", "Dingsbums");
            Assert.AreEqual(TestEnum.Dingsbums, testObject.TestEnum);

            Reflector.SetPropertyValue(testObject, "TestEnum", TestEnum.Tchotchke);
            Assert.AreEqual(TestEnum.Tchotchke, testObject.TestEnum);

            Reflector.SetPropertyValue(testObject, "TestEnum", 1);
            Assert.AreEqual(TestEnum.Dingsbums, testObject.TestEnum);
        }

        [Test]
        public void GetFieldValue() {
            TestObject testObject = new TestObject();
            ArrayList innerList = (ArrayList) Reflector.GetFieldValue(testObject, "_list");
            Assert.IsNotNull(innerList);
        }

        [Test]
        public void SetFieldValue() {
            TestObject testObject = new TestObject();

            ArrayList innerList = new ArrayList();
            innerList.Add("Ben");
            Reflector.SetFieldValue(testObject, "_list", innerList);
            Assert.AreEqual(innerList, testObject.List);
        }

        [Test]
        public void SetFieldValueAsEnum() {
            TestObject testObject = new TestObject();
            Reflector.SetFieldValue(testObject, "_testEnum", "Dingsbums");
            Assert.AreEqual(TestEnum.Dingsbums, testObject.TestEnum);

            Reflector.SetFieldValue(testObject, "_testEnum", TestEnum.Tchotchke);
            Assert.AreEqual(TestEnum.Tchotchke, testObject.TestEnum);

            Reflector.SetFieldValue(testObject, "_testEnum", 1);
            Assert.AreEqual(TestEnum.Dingsbums, testObject.TestEnum);
        }

        [Test]
        public void FieldExists() {
            TestObject testObject = new TestObject();
            Assert.IsTrue(Reflector.FieldExists(testObject, "_list"));
            Assert.IsFalse(Reflector.FieldExists(testObject, "_nofieldherebuddy"));
        }

        [Test]
        public void Implements() {
            Assert.IsTrue(Reflector.ImplementsInterface(typeof(TestObject), typeof(IDisposable)));
            Assert.IsFalse(Reflector.ImplementsInterface(typeof(TestObject), typeof(IList)));
        }

        [Test]
        public void ConvertToEnum() {
            Assert.AreEqual(TestEnum.Tchotchke, Reflector.ConvertToEnum("Tchotchke", typeof(TestEnum)));
            Assert.AreEqual(TestEnum.Dingsbums, Reflector.ConvertToEnum(1, typeof(TestEnum)));
        }

        public enum TestEnum {
            Tchotchke = 0,
            Dingsbums = 1
        }

        public class TestObject : IDisposable {
            private IList _list = new ArrayList();
            private bool _verifySet = false;
            private TestEnum _testEnum = TestEnum.Tchotchke;

            public IList List {
                get { return _list; }
                set { _list = value; }
            }

            public bool VerifySet {
                get { return _verifySet; }
                set { _verifySet = value; }
            }

            protected void Set() {
                _verifySet = true;
            }

            public string Get() {
                return "set";
            }

            public TestEnum TestEnum {
                get { return _testEnum; }
                set { _testEnum = value; }
            }

            public void Dispose() {}
        }
    }
}
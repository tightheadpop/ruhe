using System;
using System.Collections;
using NUnit.Framework;
using Ruhe.Common;

namespace Ruhe.Tests.Common {
    [TestFixture]
    public class ReflectorTests {
        [Test]
        public void ConvertToEnum() {
            Assert.AreEqual(TestEnum.Tchotchke, "Tchotchke".As<TestEnum>());
            Assert.AreEqual(TestEnum.Dingsbums, 1.As<TestEnum>());
            Assert.AreEqual(TestEnum.Tchotchke, "Tchotchke".As<TestEnum>());
        }

        [Test]
        public void ConvertToValueType() {
            Assert.AreEqual(true, "True".As<bool>());
            Assert.AreEqual(1, "1".As<int>());
        }

        [Test]
        public void FieldExists() {
            var testObject = new TestObject();
            Assert.IsTrue(testObject.FieldExists("_list"));
            Assert.IsFalse(testObject.FieldExists("_nofieldherebuddy"));
        }

        [Test]
        public void GetCrossAssemblyType() {
            Assert.IsNotNull("Ruhe.Web".GetCrossAssemblyType("Ruhe.Web.QueryStringBuilder"));
        }

        [Test]
        public void GetFieldValue() {
            new TestObject().GetFieldValue("_list").MustNotBeNull();
        }

        [Test]
        public void GetPropertyValue() {
            Assert.AreEqual("first".Length, new TestObject().GetPropertyValue("StringArrayProperty[0].Length"));
        }

        [Test]
        public void HasProperty() {
            var obj = new TestObject();
            Assert.IsTrue(obj.HasProperty("List.Count"));
            Assert.IsFalse(obj.HasProperty("Won't have it"));
        }

        [Test]
        public void Implements() {
            Assert.IsTrue(typeof(TestObject).Implements<IDisposable>());
            Assert.IsFalse(typeof(TestObject).Implements<IList>());
        }

        [Test]
        public void InvokeNonPublicMethod() {
            var testObject = new TestObject();

            var result = testObject.InvokeMethod("Set");
            Assert.IsNull(result);
            Assert.IsTrue(testObject.VerifySet);
        }

        [Test]
        public void InvokePublicMethod() {
            var testObject = new TestObject();
            var result = testObject.InvokeMethod("Get");
            Assert.IsTrue(result.GetType().Equals(typeof(string)));
            Assert.AreEqual("set", result);
        }

        [Test]
        public void SetFieldValue() {
            var testObject = new TestObject();

            var innerList = new ArrayList {"Ben"};
            testObject.SetFieldValue("_list", innerList);
            Assert.AreEqual(innerList, testObject.List);
        }

        [Test]
        public void SetFieldValueAsEnum() {
            var testObject = new TestObject();
            testObject.SetFieldValue("_testEnum", "Dingsbums");
            Assert.AreEqual(TestEnum.Dingsbums, testObject.TestEnum);

            testObject.SetFieldValue("_testEnum", TestEnum.Tchotchke);
            Assert.AreEqual(TestEnum.Tchotchke, testObject.TestEnum);

            testObject.SetFieldValue("_testEnum", 1);
            Assert.AreEqual(TestEnum.Dingsbums, testObject.TestEnum);
        }

        [Test]
        public void SetPropertyValue() {
            var testObject = new TestObject();
            testObject.SetPropertyValue("VerifySet", true);
            Assert.AreEqual(true, testObject.VerifySet);
        }

        [Test]
        public void SetPropertyValueAsEnum() {
            var testObject = new TestObject();
            testObject.SetPropertyValue("TestEnum", "Dingsbums");
            Assert.AreEqual(TestEnum.Dingsbums, testObject.TestEnum);

            testObject.SetPropertyValue("TestEnum", TestEnum.Tchotchke);
            Assert.AreEqual(TestEnum.Tchotchke, testObject.TestEnum);

            testObject.SetPropertyValue("TestEnum", 1);
            Assert.AreEqual(TestEnum.Dingsbums, testObject.TestEnum);
        }

        public enum TestEnum {
            Tchotchke = 0,
            Dingsbums = 1
        }

        public class TestObject : IDisposable {
            private IList _list = new ArrayList();
            private TestEnum _testEnum = TestEnum.Tchotchke;
            private bool _verifySet;

            public IList List {
                get { return _list; }
                set { _list = value; }
            }

            public string[] StringArrayProperty {
                get { return new[] {"first", "second"}; }
            }

            public TestEnum TestEnum {
                get { return _testEnum; }
                set { _testEnum = value; }
            }

            public bool VerifySet {
                get { return _verifySet; }
                set { _verifySet = value; }
            }

            public void Dispose() {}

            public string Get() {
                return "set";
            }

            protected void Set() {
                _verifySet = true;
            }
        }
    }
}
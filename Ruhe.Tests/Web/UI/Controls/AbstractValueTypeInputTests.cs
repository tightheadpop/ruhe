using NUnit.Framework;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Tests.Web.UI.Controls {
    [TestFixture]
    public class AbstractValueTypeInputTests {
        [Test]
        public void DefaultMaximumValueIsNull() {
            Assert.IsNull(new InputNumber().MaximumValue);
        }

        [Test]
        public void DefaultMinimumValueIsNull() {
            Assert.IsNull(new InputNumber().MinimumValue);
        }

        [Test]
        public void SettingValueToNonNullValueYieldsSameValue() {
            var input = new InputNumber {Value = 1.2};
            Assert.AreEqual(1.2, input.Value);
        }

        [Test]
        public void SettingValueToNullYieldsNullValue() {
            var input = new InputNumber {Value = null};
            Assert.IsNull(input.Value);
        }

        [Test]
        public void ValueIsNullWhenNotSet() {
            Assert.IsNull(new InputNumber().Value);
        }
    }
}
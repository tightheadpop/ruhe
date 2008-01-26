using System;
using NUnit.Framework;
using Ruhe.Common;
using Ruhe.Web.UI.Controls;

namespace Ruhe.Tests.Web.UI.Controls {
    [TestFixture]
    public class InputDateRangeTests {
        [Test]
        public void GetAndSetDateRangeValue() {
            InputDateRange input = new InputDateRange();
            DateRange oneWeek = new DateRange(DateTime.Today, DateTime.Today.AddDays(7));
            input.DateRange = oneWeek;

            Assert.AreEqual(oneWeek, input.DateRange);
        }

        [Test]
        public void InitialValueIsNull() {
            Assert.IsNull(new InputDateRange().DateRange);
        }
    }
}
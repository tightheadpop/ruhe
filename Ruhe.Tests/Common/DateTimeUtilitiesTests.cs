using System;
using NUnit.Framework;
using Ruhe.Common;
using Ruhe.Common.Utilities;

namespace Ruhe.Tests.Common {
    [TestFixture]
    public class DateTimeUtilitiesTests {
        [Test]
        public void GetFirstDayOfWeek() {
            int sunday = 4;
            DateTime originalDate = new DateTime(2004, 7, sunday);
            DateTime firstDay = originalDate.GetFirstDayOfWeek();
            Assert.IsTrue(firstDay.DayOfWeek == DayOfWeek.Sunday);
            Assert.IsTrue(firstDay.Year == originalDate.Year);
            Assert.IsTrue(firstDay.Month == originalDate.Month);
            Assert.IsTrue(firstDay.Day == originalDate.Day);
            Assert.IsTrue(firstDay.DayOfWeek == originalDate.DayOfWeek);

            int monday = 5;
            originalDate = new DateTime(2004, 7, monday);
            firstDay = originalDate.GetFirstDayOfWeek();
            Assert.IsTrue(firstDay.DayOfWeek == DayOfWeek.Sunday);
            Assert.IsTrue(firstDay.Year == originalDate.Year);
            Assert.IsTrue(firstDay.Month == originalDate.Month);
            Assert.IsTrue(firstDay.Day != originalDate.Day);
            Assert.IsTrue(firstDay.DayOfWeek != originalDate.DayOfWeek);

            int thursday = 8;
            originalDate = new DateTime(2004, 7, thursday);
            firstDay = originalDate.GetFirstDayOfWeek();
            Assert.IsTrue(firstDay.DayOfWeek == DayOfWeek.Sunday);
            Assert.IsTrue(firstDay.Year == originalDate.Year);
            Assert.IsTrue(firstDay.Month == originalDate.Month);
            Assert.IsTrue(firstDay.Day != originalDate.Day);
            Assert.IsTrue(firstDay.DayOfWeek != originalDate.DayOfWeek);
        }

        [Test]
        public void GetNextDayOfWeek() {
            DateTime expected = new DateTime(2005, 5, 9);

            DateTime startingDate = new DateTime(2005, 5, 3);
            Assert.AreEqual(expected, startingDate.GetNext(DayOfWeek.Monday));

            startingDate = new DateTime(2005, 5, 2);
            Assert.AreEqual(expected, startingDate.GetNext(DayOfWeek.Monday));

            startingDate = new DateTime(2005, 5, 8);
            Assert.AreEqual(expected, startingDate.GetNext(DayOfWeek.Monday));
        }

        [Test]
        public void GetNthDayOfWeekInMonth() {
            DateTime May9th2005 = new DateTime(2005, 5, 9);
            Assert.AreEqual(May9th2005, 2.GetNthDayOfWeekInMonth(DayOfWeek.Monday, Month.May, 2005));

            DateTime May1st2005 = new DateTime(2005, 5, 1);
            Assert.AreEqual(May1st2005, 1.GetNthDayOfWeekInMonth(DayOfWeek.Sunday, Month.May, 2005));
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetNthDayOfWeekInMonthOutOfRange() {
            (-1).GetNthDayOfWeekInMonth(DayOfWeek.Sunday, Month.May, 2005);
        }

        [Test]
        public void GetPreviousDayOfWeek() {
            DateTime expected = new DateTime(2005, 5, 9);

            DateTime start = new DateTime(2005, 5, 12);
            Assert.AreEqual(expected, start.GetPrevious(DayOfWeek.Monday));

            start = new DateTime(2005, 5, 16);
            Assert.AreEqual(expected, start.GetPrevious(DayOfWeek.Monday));
        }
    }
}
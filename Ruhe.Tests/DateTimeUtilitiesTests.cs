using System;
using NUnit.Framework;
using Ruhe.Utilities;

namespace Ruhe.Tests {
    [TestFixture]
    public class DateTimeUtilitiesTests {
        [Test]
        public void AfterShouldGiveDateInFuture() {
            var start = new DateTime(2005, 5, 9);
            var actual = 2.Days().After(start);
            Assert.AreEqual(start.AddDays(2), actual);
        }

        [Test]
        public void AgoShouldGiveDateInPast() {
            //TODO: typemock to mock DateTime.Now
            var ago = 2.Days().Ago();
            Assert.AreEqual(DateTime.Today.AddDays(-2), ago.Date);
        }

        [Test]
        public void BeforeShouldGiveDateInFuture() {
            var start = new DateTime(2005, 5, 9);
            var actual = 2.Days().Before(start);
            Assert.AreEqual(start.AddDays(-2), actual);
        }

        [Test]
        public void DaysShouldGiveTimeSpan() {
            var span = 2.Days();
            Assert.AreEqual(2, span.Days);
        }

        [Test]
        public void GetFirstDayOfWeek() {
            const int sunday = 4;
            var originalDate = new DateTime(2004, 7, sunday);
            var firstDay = originalDate.FirstDayOfWeek();
            Assert.IsTrue(firstDay.DayOfWeek == DayOfWeek.Sunday);
            Assert.IsTrue(firstDay.Year == originalDate.Year);
            Assert.IsTrue(firstDay.Month == originalDate.Month);
            Assert.IsTrue(firstDay.Day == originalDate.Day);
            Assert.IsTrue(firstDay.DayOfWeek == originalDate.DayOfWeek);

            const int monday = 5;
            originalDate = new DateTime(2004, 7, monday);
            firstDay = originalDate.FirstDayOfWeek();
            Assert.IsTrue(firstDay.DayOfWeek == DayOfWeek.Sunday);
            Assert.IsTrue(firstDay.Year == originalDate.Year);
            Assert.IsTrue(firstDay.Month == originalDate.Month);
            Assert.IsTrue(firstDay.Day != originalDate.Day);
            Assert.IsTrue(firstDay.DayOfWeek != originalDate.DayOfWeek);

            const int thursday = 8;
            originalDate = new DateTime(2004, 7, thursday);
            firstDay = originalDate.FirstDayOfWeek();
            Assert.IsTrue(firstDay.DayOfWeek == DayOfWeek.Sunday);
            Assert.IsTrue(firstDay.Year == originalDate.Year);
            Assert.IsTrue(firstDay.Month == originalDate.Month);
            Assert.IsTrue(firstDay.Day != originalDate.Day);
            Assert.IsTrue(firstDay.DayOfWeek != originalDate.DayOfWeek);
        }

        [Test]
        public void GetNextDayOfWeek() {
            var expected = new DateTime(2005, 5, 9);

            var startingDate = new DateTime(2005, 5, 3);
            Assert.AreEqual(expected, startingDate.Next(DayOfWeek.Monday));

            startingDate = new DateTime(2005, 5, 2);
            Assert.AreEqual(expected, startingDate.Next(DayOfWeek.Monday));

            startingDate = new DateTime(2005, 5, 8);
            Assert.AreEqual(expected, startingDate.Next(DayOfWeek.Monday));
        }

        [Test]
        public void GetNthDayOfWeekInMonth() {
            var May9th2005 = new DateTime(2005, 5, 9);
            Assert.AreEqual(May9th2005, 2.GetNthDayOfWeekInMonth(DayOfWeek.Monday, Month.May, 2005));

            var May1st2005 = new DateTime(2005, 5, 1);
            Assert.AreEqual(May1st2005, 1.GetNthDayOfWeekInMonth(DayOfWeek.Sunday, Month.May, 2005));
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetNthDayOfWeekInMonthOutOfRange() {
            (0).GetNthDayOfWeekInMonth(DayOfWeek.Sunday, Month.May, 2005);
        }

        [Test]
        public void GetPreviousDayOfWeek() {
            var expected = new DateTime(2005, 5, 9);

            var start = new DateTime(2005, 5, 12);
            Assert.AreEqual(expected, start.Previous(DayOfWeek.Monday));

            start = new DateTime(2005, 5, 16);
            Assert.AreEqual(expected, start.Previous(DayOfWeek.Monday));
        }

        [Test]
        public void HenceShouldGiveDateInFuture() {
            //TODO: typemock to mock DateTime.Now
            var hence = 2.Days().FromNow();
            Assert.AreEqual(DateTime.Today.AddDays(2), hence.Date);
        }

        [Test]
        public void HoursShouldGiveTimeSpan() {
            var span = 2.Hours();
            Assert.AreEqual(2, span.Hours);
        }

        [Test]
        public void MinutesShouldGiveTimeSpan() {
            var span = 2.Minutes();
            Assert.AreEqual(2, span.Minutes);
        }

        [Test]
        public void SecondsShouldGiveTimeSpan() {
            var span = 2.Seconds();
            Assert.AreEqual(2, span.Seconds);
        }
    }
}
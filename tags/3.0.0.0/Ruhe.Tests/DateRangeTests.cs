using System;
using NUnit.Framework;

namespace Ruhe.Tests {
    [TestFixture]
    public class DateRangeTests {
        private readonly DateRange parentRange = new DateRange(new DateTime(2004, 1, 1), DateTime.Today);

        [Test]
        public void Abuts() {
            var ending = DateRange.EndingOn(new DateTime(2004, 1, 1));
            var starting = DateRange.StartingOn(new DateTime(2004, 1, 2));
            Assert.IsTrue(starting.Abuts(ending));
            Assert.IsTrue(ending.Abuts(starting));
        }

        [Test]
        public void CompareStartingToEnding() {
            var high = DateRange.StartingOn(DateTime.Today);
            var low = DateRange.EndingOn(DateTime.Today);
            Assert.AreEqual(1, high.CompareTo(low));
        }

        [Test]
        public void CompareTo() {
            var high = DateRange.StartingOn(DateTime.Today);
            var low = DateRange.StartingOn(DateTime.Today.AddDays(-1));
            Assert.AreEqual(1, high.CompareTo(low));
            Assert.AreEqual(0, high.CompareTo(high));
            Assert.AreEqual(-1, low.CompareTo(high));
        }

        [Test]
        public void CreatesEndingOnIfStartIsNull() {
            Assert.AreEqual(DateRange.EndingOn(DateTime.Today), DateRange.Create(null, DateTime.Today));
        }

        [Test]
        public void CreatesNullIfBothStartAndEndAreNull() {
            Assert.IsNull(DateRange.Create(null, null));
        }

        [Test]
        public void CreatesRange() {
            Assert.AreEqual(parentRange, DateRange.Create(parentRange.Start, parentRange.End));
        }

        [Test]
        public void CreatesStartingOnIfEndIsNull() {
            Assert.AreEqual(DateRange.StartingOn(DateTime.Today), DateRange.Create(DateTime.Today, null));
        }

        [Test]
        public void EndingOnHasANullStartDate() {
            var range = DateRange.EndingOn(new DateTime(2009, 12, 1));
            Assert.AreEqual(new DateTime(2009, 12, 1), range.End);
            Assert.AreEqual(DateTime.MinValue.Date, range.Start);
        }

        [Test]
        public void EndingOnIncludesEndingOn() {
            var earlyEnd = DateRange.EndingOn(new DateTime(2004, 1, 1));
            var lateEnd = DateRange.EndingOn(new DateTime(2005, 1, 1));
            Assert.IsTrue(lateEnd.Includes(earlyEnd));
            Assert.IsFalse(earlyEnd.Includes(lateEnd));
        }

        [Test]
        public void EndingOnIncludesStartingOn() {
            var ending = DateRange.EndingOn(new DateTime(2004, 1, 1));
            var starting = DateRange.StartingOn(new DateTime(2003, 1, 1));
            Assert.IsFalse(ending.Includes(starting));
        }

        [Test]
        public void GetGapBetween() {
            var yearFromToday = DateTime.Today.AddYears(1);
            var other = DateRange.StartingOn(yearFromToday);
            var gap = parentRange.GetGap(other);
            Assert.AreEqual(DateTime.Today.AddDays(1), gap.Value.Start);
            Assert.AreEqual(yearFromToday.AddDays(-1), gap.Value.End);
        }

        [Test]
        public void GetGapBetweenOverlappingRangesIsNull() {
            var gap = parentRange.GetGap(DateRange.StartingOn(DateTime.Today));
            Assert.AreEqual(null, gap);
        }

        [Test]
        public void IncludesChildDateRange() {
            var childRange = new DateRange(new DateTime(2005, 1, 1), new DateTime(2005, 2, 28));
            Assert.IsTrue(parentRange.Includes(childRange));
        }

        [Test]
        public void IncludesDateTime() {
            var range = new DateRange(new DateTime(2005, 1, 1), DateTime.Today);
            Assert.IsTrue(range.Includes(DateTime.Today), "boundary end");
            Assert.IsTrue(range.Includes(new DateTime(2005, 1, 1)), "boundary begin");
            Assert.IsFalse(range.Includes(new DateTime(2004, 12, 31)), "boundary prior");
            Assert.IsFalse(range.Includes(DateTime.Today.AddDays(1)), "boundary after");
        }

        [Test]
        public void IncludesEternity() {
            Assert.IsFalse(parentRange.Includes(DateRange.Eternity));
        }

        [Test]
        public void IncludesOverlappingRange() {
            var overlappingRange = new DateRange(new DateTime(2003, 1, 1), new DateTime(2005, 1, 1));
            Assert.IsFalse(parentRange.Includes(overlappingRange));
        }

        [Test]
        public void Overlaps() {
            var overlappingRange = new DateRange(new DateTime(2003, 1, 1), new DateTime(2005, 1, 1));
            Assert.IsTrue(parentRange.Overlaps(overlappingRange));
        }

        [Test]
        public void OverlapsEternity() {
            Assert.IsTrue(parentRange.Overlaps(DateRange.Eternity));
        }

        [Test]
        public void OverlapsStartingOn() {
            var startingOn = DateRange.StartingOn(new DateTime(2003, 1, 1));
            Assert.IsTrue(parentRange.Overlaps(startingOn));
        }

        [Test]
        public void StartingOnHasANullEndDate() {
            var range = DateRange.StartingOn(new DateTime(2004, 1, 1));
            Assert.AreEqual(new DateTime(2004, 1, 1), range.Start);
            Assert.AreEqual(DateTime.MaxValue.Date, range.End);
        }

        [Test]
        public void StartingOnIncludesStartingOn() {
            var earlyStart = DateRange.StartingOn(new DateTime(2004, 1, 1));
            var lateStart = DateRange.StartingOn(new DateTime(2005, 1, 1));
            Assert.IsTrue(earlyStart.Includes(lateStart));
            Assert.IsFalse(lateStart.Includes(earlyStart));
        }

        [Test]
        public void StartingOnOverlapsEndingOn() {
            var ending = DateRange.EndingOn(new DateTime(2004, 1, 1));
            var starting = DateRange.StartingOn(new DateTime(2003, 1, 1));
            Assert.IsTrue(starting.Overlaps(ending));
        }

        [Test]
        public void ThrowsExceptionWhenEndDatePrecedesStartDate() {
            try {
                new DateRange(DateTime.Today.AddDays(4), DateTime.Today);
                Assert.Fail();
            }
            catch (ArgumentException) {
            }
        }

        [Test]
        public void ValidatesThatEndDateHasNoTimeUnits() {
            try {
                DateRange.EndingOn(DateTime.Today.AddMilliseconds(1));
                Assert.Fail();
            }
            catch (ArgumentException) {
            }
        }

        [Test]
        public void ValidatesThatStartDateHasNoTimeUnits() {
            try {
                DateRange.StartingOn(DateTime.Today.AddMilliseconds(1));
                Assert.Fail();
            }
            catch (ArgumentException) {
            }
        }

        //iscoontiguous
        //tostring
        //combine
    }
}
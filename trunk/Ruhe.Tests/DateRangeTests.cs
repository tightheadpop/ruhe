using System;
using NUnit.Framework;

namespace Ruhe.Tests {
    [TestFixture]
    public class DateRangeTests {
        private readonly DateRange parentRange = new DateRange(new DateTime(2004, 1, 1), DateTime.Today);

        [Test]
        public void Abuts() {
            DateRange ending = DateRange.EndingOn(new DateTime(2004, 1, 1));
            DateRange starting = DateRange.StartingOn(new DateTime(2004, 1, 2));
            Assert.IsTrue(starting.Abuts(ending));
            Assert.IsTrue(ending.Abuts(starting));
        }

        [Test]
        public void CompareStartingToEnding() {
            DateRange high = DateRange.StartingOn(DateTime.Today);
            DateRange low = DateRange.EndingOn(DateTime.Today);
            Assert.AreEqual(1, high.CompareTo(low));
        }

        [Test]
        public void CompareTo() {
            DateRange high = DateRange.StartingOn(DateTime.Today);
            DateRange low = DateRange.StartingOn(DateTime.Today.AddDays(-1));
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
            DateRange range = DateRange.EndingOn(new DateTime(2009, 12, 1));
            Assert.AreEqual(new DateTime(2009, 12, 1), range.End);
            Assert.AreEqual(DateTime.MinValue.Date, range.Start);
        }

        [Test]
        public void EndingOnIncludesEndingOn() {
            DateRange earlyEnd = DateRange.EndingOn(new DateTime(2004, 1, 1));
            DateRange lateEnd = DateRange.EndingOn(new DateTime(2005, 1, 1));
            Assert.IsTrue(lateEnd.Includes(earlyEnd));
            Assert.IsFalse(earlyEnd.Includes(lateEnd));
        }

        [Test]
        public void EndingOnIncludesStartingOn() {
            DateRange ending = DateRange.EndingOn(new DateTime(2004, 1, 1));
            DateRange starting = DateRange.StartingOn(new DateTime(2003, 1, 1));
            Assert.IsFalse(ending.Includes(starting));
        }

        [Test]
        public void GetGapBetween() {
            DateTime yearFromToday = DateTime.Today.AddYears(1);
            DateRange other = DateRange.StartingOn(yearFromToday);
            DateRange? gap = parentRange.GetGap(other);
            Assert.AreEqual(DateTime.Today.AddDays(1), gap.Value.Start);
            Assert.AreEqual(yearFromToday.AddDays(-1), gap.Value.End);
        }

        [Test]
        public void GetGapBetweenOverlappingRangesIsNull() {
            DateRange? gap = parentRange.GetGap(DateRange.StartingOn(DateTime.Today));
            Assert.AreEqual(null, gap);
        }

        [Test]
        public void IncludesChildDateRange() {
            DateRange childRange = new DateRange(new DateTime(2005, 1, 1), new DateTime(2005, 2, 28));
            Assert.IsTrue(parentRange.Includes(childRange));
        }

        [Test]
        public void IncludesDateTime() {
            DateRange range = new DateRange(new DateTime(2005, 1, 1), DateTime.Today);
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
            DateRange overlappingRange = new DateRange(new DateTime(2003, 1, 1), new DateTime(2005, 1, 1));
            Assert.IsFalse(parentRange.Includes(overlappingRange));
        }

        [Test]
        public void Overlaps() {
            DateRange overlappingRange = new DateRange(new DateTime(2003, 1, 1), new DateTime(2005, 1, 1));
            Assert.IsTrue(parentRange.Overlaps(overlappingRange));
        }

        [Test]
        public void OverlapsEternity() {
            Assert.IsTrue(parentRange.Overlaps(DateRange.Eternity));
        }

        [Test]
        public void OverlapsStartingOn() {
            DateRange startingOn = DateRange.StartingOn(new DateTime(2003, 1, 1));
            Assert.IsTrue(parentRange.Overlaps(startingOn));
        }

        [Test]
        public void StartingOnHasANullEndDate() {
            DateRange range = DateRange.StartingOn(new DateTime(2004, 1, 1));
            Assert.AreEqual(new DateTime(2004, 1, 1), range.Start);
            Assert.AreEqual(DateTime.MaxValue.Date, range.End);
        }

        [Test]
        public void StartingOnIncludesStartingOn() {
            DateRange earlyStart = DateRange.StartingOn(new DateTime(2004, 1, 1));
            DateRange lateStart = DateRange.StartingOn(new DateTime(2005, 1, 1));
            Assert.IsTrue(earlyStart.Includes(lateStart));
            Assert.IsFalse(lateStart.Includes(earlyStart));
        }

        [Test]
        public void StartingOnOverlapsEndingOn() {
            DateRange ending = DateRange.EndingOn(new DateTime(2004, 1, 1));
            DateRange starting = DateRange.StartingOn(new DateTime(2003, 1, 1));
            Assert.IsTrue(starting.Overlaps(ending));
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowsExceptionWhenEndDatePrecedesStartDate() {
            new DateRange(DateTime.Today.AddDays(4), DateTime.Today);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ValidatesThatEndDateHasNoTimeUnits() {
            DateRange.EndingOn(DateTime.Today.AddMilliseconds(1));
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ValidatesThatStartDateHasNoTimeUnits() {
            DateRange.StartingOn(DateTime.Today.AddMilliseconds(1));
        }

        //iscoontiguous
        //tostring
        //combine
    }
}
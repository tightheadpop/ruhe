using System;
using NUnit.Framework;
using Ruhe.Common;

namespace Ruhe.Tests.Common {
	[TestFixture]
	public class DateRangeTests {
		private readonly DateRange parentRange = new DateRange(new DateTime(2004, 1, 1), DateTime.Today);

		[Test]
		public void ThrowsExceptionWhenEndDatePrecedesStartDate() {
		    DateRange range = new DateRange(DateTime.Today.AddDays(4), DateTime.Today);
            Assert.IsTrue(range.IsNull);
		}

	    [Test]
		public void IsNullIsTrueIfBothEndsOfRangeAreNull() {
			DateRange empty = DateRange.Null;
			Assert.AreEqual(true, empty.IsNull, "IsNull");
			Assert.AreEqual(false, empty.IsNotNull, "IsNotNull");
			Assert.AreEqual(false, empty.Start.HasValue, "Start.IsNull");
			Assert.AreEqual(false, empty.End.HasValue, "End.IsNull");
		}

		[Test]
		public void StartingOn() {
			DateRange range = DateRange.StartingOn(new DateTime(2004, 1, 1));
			Assert.AreEqual(new DateTime(2004, 1, 1), range.Start.Value);
			Assert.AreEqual(null, range.End);
		}

		[Test]
		public void EndingOn() {
			DateRange range = DateRange.EndingOn(new DateTime(2009, 12, 1));
			Assert.AreEqual(new DateTime(2009, 12, 1), range.End.Value);
            Assert.AreEqual(null, range.Start);
		}

		[Test]
		public void IncludesDateTime() {
			DateRange range = new DateRange(new DateTime(2005, 1, 1), DateTime.Today);
			Assert.IsTrue(range.Includes(DateTime.Today), "boundary end");
			Assert.IsTrue(range.Includes(new DateTime(2005, 1, 1)), "boundary begin");
			Assert.IsFalse(range.Includes(new DateTime(2004, 1, 1)), "boundary prior");
			Assert.IsFalse(range.Includes(DateTime.Today.AddDays(1)), "boundary after");
            Assert.IsFalse(range.Includes(null), "includes Null");
		}

		[Test]
		public void IncludesChildDateRange() {
			DateRange childRange = new DateRange(new DateTime(2005, 1, 1), new DateTime(2005, 2, 28));
			Assert.IsTrue(parentRange.Includes(childRange));
		}

		[Test]
		public void IncludesOverlappingRange() {
			DateRange overlappingRange = new DateRange(new DateTime(2003, 1, 1), new DateTime(2005, 1, 1));
			Assert.IsFalse(parentRange.Includes(overlappingRange));
		}

		[Test]
		public void IncludesNull() {
			Assert.IsFalse(parentRange.Includes(DateRange.Null));
		}

		[Test]
		public void IncludesEternity() {
			Assert.IsFalse(parentRange.Includes(DateRange.Eternity));
		}

		[Test]
		public void StartingOnIncludesStartingOn() {
			DateRange earlyStart = DateRange.StartingOn(new DateTime(2004, 1, 1));
			DateRange lateStart = DateRange.StartingOn(new DateTime(2005, 1, 1));
			Assert.IsTrue(earlyStart.Includes(lateStart));
			Assert.IsFalse(lateStart.Includes(earlyStart));
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
		public void Overlaps() {
			DateRange overlappingRange = new DateRange(new DateTime(2003, 1, 1), new DateTime(2005, 1, 1));
			Assert.IsTrue(parentRange.Overlaps(overlappingRange));
		}

		[Test]
		public void OverlapsStartingOn() {
			DateRange startingOn = DateRange.StartingOn(new DateTime(2003, 1, 1));
			Assert.IsTrue(parentRange.Overlaps(startingOn));
		}

		[Test]
		public void OverlapsNull() {
			Assert.IsFalse(parentRange.Overlaps(DateRange.Null));
		}

		[Test]
		public void OverlapsEternity() {
			Assert.IsTrue(parentRange.Overlaps(DateRange.Eternity));
		}

		[Test]
		public void StartingOnOverlapsEndingOn() {
			DateRange ending = DateRange.EndingOn(new DateTime(2004, 1, 1));
			DateRange starting = DateRange.StartingOn(new DateTime(2003, 1, 1));
			Assert.IsTrue(starting.Overlaps(ending));
		}

		[Test]
		public void GetGapBetween() {
			DateRange other = DateRange.StartingOn(new DateTime(2009, 1, 1));
			DateRange gap = parentRange.GetGapBetween(other);
			Assert.AreEqual(DateTime.Today.AddDays(1), gap.Start.Value);
			Assert.AreEqual(new DateTime(2008, 12, 31), gap.End.Value);
		}

		[Test]
		public void GetGapBetweenOverlappingRanges() {
			DateRange gap = parentRange.GetGapBetween(DateRange.StartingOn(DateTime.Today));
			Assert.AreEqual(DateRange.Null, gap);
		}

		[Test]
		public void Abuts() {
			DateRange ending = DateRange.EndingOn(new DateTime(2004, 1, 1));
			DateRange starting = DateRange.StartingOn(new DateTime(2004, 1, 2));
			Assert.IsTrue(starting.Abuts(ending));
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
		public void CompareStartingToEnding() {
			DateRange high = DateRange.StartingOn(DateTime.Today);
			DateRange low = DateRange.EndingOn(DateTime.Today);
			Assert.AreEqual(1, high.CompareTo(low));
		}

		[Test]
		public void CompareToNulls() {
			Assert.AreEqual(1, DateRange.StartingOn(DateTime.Today).CompareTo(DateRange.Null));
			Assert.AreEqual(-1, DateRange.Null.CompareTo(DateRange.StartingOn(DateTime.Today)));
			Assert.AreEqual(0, DateRange.Null.CompareTo(DateRange.Null));
		}

		//iscoontiguous
		//tostring
		//combine
	}
}

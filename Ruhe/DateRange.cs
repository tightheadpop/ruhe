using System;

namespace Ruhe {
    /// <remarks>
    /// Assumes a date precision (without reference to time) for the DateTime end points.
    /// </remarks>
    public struct DateRange : IComparable, IEquatable<DateRange>, IComparable<DateRange> {
        public static readonly DateRange Eternity = new DateRange(DateTime.MinValue.Date, DateTime.MaxValue.Date);

        //TODO: don't accept nullables?
        public DateRange(DateTime start, DateTime end) : this() {
            if (start.TimeOfDay.TotalMilliseconds > 0)
                throw new ArgumentException("DateRange requires date precision, but the Start date has reference to time of day.");
            if (end.TimeOfDay.TotalMilliseconds > 0)
                throw new ArgumentException("DateRange requires date precision, but the End date has reference to time of day.");
            if (start > end)
                throw new ArgumentException("Start of date range must be on or before end.");

            Start = start;
            End = end;
        }

        public DateTime End { get; private set; }

        public DateTime Start { get; private set; }

        public bool Abuts(DateRange range) {
            return !Overlaps(range) && !GetGap(range).HasValue;
        }

        public int CompareTo(object obj) {
            if (!(obj is DateRange))
                throw new ArgumentException("Must be of type DateRange.", "obj");
            return CompareTo((DateRange) obj);
        }

        public int CompareTo(DateRange range) {
            if (Start != range.Start)
                return Start.CompareTo(range.Start);
            return End.CompareTo(range.End);
        }

        public bool Equals(DateRange dateRange) {
            return Equals(Start, dateRange.Start) && Equals(End, dateRange.End);
        }

        public override bool Equals(object obj) {
            if (!(obj is DateRange)) return false;
            return Equals((DateRange) obj);
        }

        public DateRange? GetGap(DateRange range) {
            if (Overlaps(range)) {
                return null;
            }
            DateRange lower, higher;
            if (CompareTo(range) < 0) {
                lower = this;
                higher = range;
            } else {
                lower = range;
                higher = this;
            }
            if (lower.End.AddDays(1) >= higher.Start.AddDays(-1))
                return null;
            return new DateRange(lower.End.AddDays(1), higher.Start.AddDays(-1));
        }

        public override int GetHashCode() {
            return Start.GetHashCode() + 29 * End.GetHashCode();
        }

        public bool Includes(DateTime date) {
            return date >= Start && date <= End;
        }

        public bool Includes(DateRange range) {
            return Includes(range.Start) && Includes(range.End);
        }

        /// <summary>
        /// Determines whether the combination of date ranges effectively 
        /// partitions the current date range.
        /// </summary>
        public bool IsPartitionedBy(params DateRange[] ranges) {
            if (!IsContiguous(ranges))
                return false;
            return Equals(Combine(ranges));
        }

        public bool Overlaps(DateRange range) {
            return range.Includes(Start) || range.Includes(End) || Includes(range);
        }

        public override string ToString() {
            return ToString(null);
        }

        public string ToString(string format) {
            if (string.IsNullOrEmpty(format)) {
                format = "d";
            }
            if (this == Eternity) {
                return "infinite";
            }
            if (Start == DateTime.MinValue.Date) {
                return "to " + End.ToString(format);
            }
            if (End == DateTime.MaxValue.Date) {
                return "from " + Start.ToString(format);
            }
            return string.Format("{0} to {1}", Start.ToString(format), End.ToString(format));
        }

        public static DateRange Combine(params DateRange[] ranges) {
            Array.Sort(ranges);
            if (!IsContiguous(ranges))
                throw new ArgumentException("Unable to combine ranges that are not contiguous.");
            return new DateRange(ranges[0].Start, ranges[ranges.Length - 1].End);
        }

        public static DateRange? Create(DateTime? start, DateTime? end) {
            if (start.HasValue && end.HasValue)
                return new DateRange(start.Value, end.Value);
            if (start.HasValue)
                return StartingOn(start.Value);
            if (end.HasValue)
                return EndingOn(end.Value);
            return null;
        }

        public static DateRange EndingOn(DateTime end) {
            return new DateRange(DateTime.MinValue.Date, end);
        }

        public static bool IsContiguous(params DateRange[] ranges) {
            Array.Sort(ranges);
            for (int i = 0; i < ranges.Length - 1; i++) {
                if (!ranges[i].Abuts(ranges[i + 1]))
                    return false;
            }
            return true;
        }

        public static DateRange StartingOn(DateTime start) {
            return new DateRange(start, DateTime.MaxValue.Date);
        }

        public static bool operator ==(DateRange a, DateRange b) {
            return a.Equals(b);
        }

        public static bool operator !=(DateRange a, DateRange b) {
            return !a.Equals(b);
        }
    }
}
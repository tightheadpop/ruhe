using System;
using Ruhe.Common.Utilities;

namespace Ruhe.Common {
    public struct DateRange : IComparable, IEquatable<DateRange>, IComparable<DateRange> {
        private DateTime? start;
        private DateTime? end;

        public static readonly DateRange Null = new DateRange(null, null);

        public static readonly DateRange Eternity = new DateRange(DateTime.MinValue, DateTime.MaxValue);

        public DateRange(DateTime? start, DateTime? end) {
            //return Null if start is after end
            if (!start.HasValue || !end.HasValue || start.Value <= end.Value) {
                this.start = start;
                this.end = end;
            } else {
                this.start = null;
                this.end = null;
            }
        }

        public DateTime? Start {
            get { return start; }
        }

        public DateTime? End {
            get { return end; }
        }

        public bool IsNull {
            get { return !Start.HasValue && !End.HasValue; }
        }

        public bool IsNotNull {
            get { return !IsNull; }
        }

        public bool Includes(DateTime? date) {
            if (!date.HasValue || IsNull) {
                return false;
            } else if (!Start.HasValue) {
                return date.Value <= End.Value;
            } else if (!End.HasValue) {
                return date.Value >= Start.Value;
            }
            return date.Value >= Start.Value && date.Value <= End.Value;
        }

        public bool Includes(DateRange range) {
            if (IsNull || range.IsNull) {
                return false;
            } else if (!range.Start.HasValue) {
                return !Start.HasValue && End.HasValue && range.End.Value <= End.Value;
            } else if (!range.End.HasValue) {
                return !End.HasValue && Start.HasValue && range.Start.Value >= Start.Value;
            }
            return Includes(range.Start) && Includes(range.End);
        }

        public bool Overlaps(DateRange range) {
            return range.Includes(Start) || range.Includes(End) || Includes(range);
        }

        public bool Abuts(DateRange range) {
            return !Overlaps(range) && GetGapBetween(range).IsNull;
        }

        /// <summary>
        /// Determines whether the combination of date ranges effectively 
        /// partitions the current date range.
        /// </summary>
        public bool IsPartitionedBy(params DateRange[] ranges) {
            if (!IsContiguous(ranges))
                return false;
            else
                return Equals(Combine(ranges));
        }

        public DateRange GetGapBetween(DateRange range) {
            if (Overlaps(range)) {
                return Null;
            }
            DateRange lower, higher;
            if (CompareTo(range) < 0) {
                lower = this;
                higher = range;
            } else {
                lower = range;
                higher = this;
            }
            return new DateRange(lower.End.Value.AddDays(1), higher.Start.Value.AddDays(-1));
        }

        public static bool operator == (DateRange a, DateRange b) {
            return a.Equals(b);
        }

        public static bool operator != (DateRange a, DateRange b) {
            return !a.Equals(b);
        }

        public bool Equals(DateRange dateRange) {
            return Equals(start, dateRange.start) && Equals(end, dateRange.end);
        }

        public override bool Equals(object obj) {
            if (!(obj is DateRange)) return false;
            return Equals((DateRange) obj);
        }

        public override int GetHashCode() {
            return start.GetHashCode() + 29 * end.GetHashCode();
        }

        public override string ToString() {
            return ToString(null);
        }

        public string ToString(string format) {
            if (StringUtilities.NullToEmpty(format) == string.Empty) {
                format = "d";
            }
            if (IsNull) {
                return String.Empty;
            } else if (this == Eternity) {
                return "infinite";
            } else if (!Start.HasValue) {
                return "to " + End.Value.ToString(format);
            } else if (!End.HasValue) {
                return "from " + Start.Value.ToString(format);
            } else {
                return String.Format("{0} to {1}", Start.Value.ToString(format), End.Value.ToString(format));
            }
        }

        public static DateRange StartingOn(DateTime? start) {
            return new DateRange(start, null);
        }

        public static DateRange EndingOn(DateTime? end) {
            return new DateRange(null, end);
        }

        public static bool IsContiguous(params DateRange[] ranges) {
            Array.Sort(ranges);
            for (int i = 0; i < ranges.Length - 1; i++) {
                if (!ranges[i].Abuts(ranges[i + 1]))
                    return false;
            }
            return true;
        }

        public static DateRange Combine(params DateRange[] ranges) {
            Array.Sort(ranges);
            if (!IsContiguous(ranges))
                throw new ArgumentException("Unable to combine ranges that are not contiguous.");
            return new DateRange(ranges[0].Start, ranges[ranges.Length - 1].End);
        }

        public int CompareTo(object obj) {
            if (!(obj is DateRange))
                throw new ArgumentException("Must be of type DateRange.", "obj");
            return CompareTo((DateRange) obj);
        }

        public int CompareTo(DateRange range) {
            if (IsNull && range.IsNull)
                return 0;
            if (IsNull && !range.IsNull)
                return -1;
            if (!IsNull && range.IsNull)
                return 1;

            DateTime thisStart, rangeStart, thisEnd, rangeEnd;
            thisStart = (!Start.HasValue) ? DateTime.MinValue : Start.Value;
            thisEnd = (!End.HasValue) ? DateTime.MaxValue : End.Value;
            rangeStart = (!range.Start.HasValue) ? DateTime.MinValue : range.Start.Value;
            rangeEnd = (!range.End.HasValue) ? DateTime.MaxValue : range.End.Value;

            if (thisStart != rangeStart)
                return thisStart.CompareTo(rangeStart);
            else
                return thisEnd.CompareTo(rangeEnd);
        }
    }
}
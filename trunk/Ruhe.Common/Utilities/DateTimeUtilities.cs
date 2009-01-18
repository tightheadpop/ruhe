using System;
using Microsoft.VisualBasic;

namespace Ruhe.Common.Utilities {
    public enum RoundingOption {
        Up,
        Down
    }

    /// <summary>
    /// Function bucket providing common DateTime utility methods
    /// </summary>
    public static class DateTimeUtilities {
        public static DateTime After(this TimeSpan span, DateTime start) {
            return start.Add(span);
        }

        public static DateTime Ago(this TimeSpan span) {
            return DateTime.Now.Add(-span);
        }

        public static DateTime Before(this TimeSpan span, DateTime start) {
            return start.Add(-span);
        }

        public static TimeSpan Days(this int days) {
            return new TimeSpan(days, 0, 0, 0);
        }

        public static DateTime FirstDayOfWeek(this DateTime dateTime) {
            return dateTime.AddDays((int) dateTime.DayOfWeek * -1);
        }

        public static DateTime FromNow(this TimeSpan span) {
            return span.After(DateTime.Now);
        }

        public static DateTime GetNthDayOfWeekInMonth(this int n, DayOfWeek dayOfWeek, Month month, int year) {
            if (n <= 0)
                throw new ArgumentOutOfRangeException("n", n, "n must be greater than zero");

            DateTime startingDate = new DateTime(year, (int) month, 1).AddDays(-1);
            DateTime result = startingDate;
            for (int i = 0; i < n; i++)
                result = result.Next(dayOfWeek);
            return result;
        }

        public static TimeSpan Hours(this int hours) {
            return new TimeSpan(0, hours, 0, 0);
        }

        public static bool IsDate(this string date) {
            DateTime result;
            return DateTime.TryParse(date, out result);
        }

        public static DateTime LastDayOfWeek(this DateTime dateTime) {
            return dateTime.FirstDayOfWeek().AddDays(6);
        }

        public static TimeSpan Minutes(this int minutes) {
            return new TimeSpan(0, 0, minutes, 0);
        }

        public static long MonthsBetween(this DateTime date1, DateTime date2) {
            return date1.MonthsBetween(date2, RoundingOption.Down);
        }

        public static long MonthsBetween(this DateTime date1, DateTime date2, RoundingOption roundingOption) {
            long differenceInMonths = DateAndTime.DateDiff(DateInterval.Month, date1, date2, Microsoft.VisualBasic.FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);

            if (roundingOption == RoundingOption.Up) {
                DateTime tempDate = date1.AddMonths((int) differenceInMonths);
                long differenceInDays = DateAndTime.DateDiff(DateInterval.Day, tempDate, date2, Microsoft.VisualBasic.FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
                if (differenceInDays > 0) {
                    differenceInMonths++;
                }
            }
            return differenceInMonths;
        }

        public static DateTime Next(this DateTime start, DayOfWeek dayOfWeek) {
            if (dayOfWeek > start.DayOfWeek)
                return start.AddDays(dayOfWeek - start.DayOfWeek);
            return start.AddDays(7).FirstDayOfWeek().AddDays((int) dayOfWeek);
        }

        public static DateTime Previous(this DateTime start, DayOfWeek dayOfWeek) {
            return start.AddDays(-8).Next(dayOfWeek);
        }

        public static TimeSpan Seconds(this int seconds) {
            return new TimeSpan(0, 0, 0, seconds);
        }
    }
}
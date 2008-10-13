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
        public static long DifferenceInMonths(this DateTime date1, DateTime date2) {
            return date1.DifferenceInMonths(date2, RoundingOption.Down);
        }

        public static long DifferenceInMonths(this DateTime date1, DateTime date2, RoundingOption roundingOption) {
            long differenceInMonths = DateAndTime.DateDiff(DateInterval.Month, date1, date2, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);

            if (roundingOption == RoundingOption.Up) {
                DateTime tempDate = date1.AddMonths((int) differenceInMonths);
                long differenceInDays = DateAndTime.DateDiff(DateInterval.Day, tempDate, date2, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
                if (differenceInDays > 0) {
                    differenceInMonths++;
                }
            }
            return differenceInMonths;
        }

        public static DateTime GetFirstDayOfWeek(this DateTime dateTime) {
            return dateTime.AddDays((int) dateTime.DayOfWeek * -1);
        }

        public static DateTime GetLastDayOfWeek(this DateTime dateTime) {
            return dateTime.GetFirstDayOfWeek().AddDays(6);
        }

        public static DateTime GetNext(this DateTime start, DayOfWeek dayOfWeek) {
            if (dayOfWeek > start.DayOfWeek)
                return start.AddDays(dayOfWeek - start.DayOfWeek);
            return start.AddDays(7).GetFirstDayOfWeek().AddDays((int) dayOfWeek);
        }

        public static DateTime GetNthDayOfWeekInMonth(this int n, DayOfWeek dayOfWeek, Month month, int year) {
            if (n <= 0)
                throw new ArgumentOutOfRangeException("n", n, "n must be greater than zero");

            DateTime startingDate = new DateTime(year, (int) month, 1).AddDays(-1);
            DateTime result = startingDate;
            for (int i = 0; i < n; i++)
                result = result.GetNext(dayOfWeek);
            return result;
        }

        public static DateTime GetPrevious(this DateTime start, DayOfWeek dayOfWeek) {
            return start.AddDays(-8).GetNext(dayOfWeek);
        }

        public static bool IsDate(this string date) {
            DateTime result;
            return DateTime.TryParse(date, out result);
        }
    }
}
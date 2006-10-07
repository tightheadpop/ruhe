using System;
using Microsoft.VisualBasic;

namespace Ruhe.Common {
	public enum RoundingOption {
		Up,
		Down
	}

	public abstract class DateTimeUtilities {
		public static DateTime GetFirstDayOfWeek(DateTime dateTime) {
			return dateTime.AddDays((int) dateTime.DayOfWeek * -1);
		}

		public static DateTime GetLastDayOfWeek(DateTime dateTime) {
			return GetFirstDayOfWeek(dateTime).AddDays(6);
		}

		//this is here so we don't have to set the system clock back
		//for testing purposes we can hard code a date.
		public static DateTime CurrentDateTime {
			get { return DateTime.Now; }
		}

		//TODO: use regex here
		public static bool IsDate(string date) {
			try {
				DateTime.Parse(date);
			}
			catch {
				return false;
			}
			return true;
		}

		public static long DifferenceInMonths(DateTime date1, DateTime date2) {
			return DifferenceInMonths(date1, date2, RoundingOption.Down);
		}

		public static long DifferenceInMonths(DateTime date1, DateTime date2, RoundingOption roundingOption) {
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

		public static DateTime GetNthDayOfWeekInMonth(int n, DayOfWeek dayOfWeek, Month month, int year) {
			if (n <= 0)
				throw new ArgumentOutOfRangeException("n", n, "n must be greater than zero");

			DateTime startingDate = new DateTime(year, (int) month, 1).AddDays(-1);
			DateTime result = startingDate;
			for (int i = 0; i < n; i++)
				result = GetNextDayOfWeek(result, dayOfWeek);
			return result;
		}

		public static DateTime GetNextDayOfWeek(DateTime start, DayOfWeek dayOfWeek) {
			if (dayOfWeek > start.DayOfWeek)
				return start.AddDays(dayOfWeek - start.DayOfWeek);
			else
				return GetFirstDayOfWeek(start.AddDays(7)).AddDays((int) dayOfWeek);
		}

		public static DateTime GetPreviousDayOfWeek(DateTime start, DayOfWeek dayOfWeek) {
			return GetNextDayOfWeek(start.AddDays(-8), dayOfWeek);
		}
	}
}
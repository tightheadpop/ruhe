using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Ruhe.Common.Utilities {
    /// <summary>
    /// Function bucket providing common string utility methods
    /// </summary>
    public class StringUtilities {
        private StringUtilities() {}

        public static string NullToEmpty(string value) {
            return value ?? string.Empty;
        }

        public static string NullToEmpty(DBNull notGonnaUseIt) {
            return string.Empty;
        }

        public static bool Contains(string searchIn, string subString) {
            return searchIn.ToLower().IndexOf(subString.ToLower(), 0) >= 0;
        }

        public static bool Compare(string string1, string string2) {
            return string.Compare(string1, string2, true) == 0;
        }

        public static bool IsNumeric(string value) {
            double number;
            return double.TryParse(value, NumberStyles.Float | NumberStyles.AllowThousands, NumberFormatInfo.CurrentInfo, out number);
        }

        public static string RemovePrefix(string stringToTrim, string prefixPattern) {
            return Regex.Replace(stringToTrim, "^" + prefixPattern, string.Empty, RegexOptions.IgnoreCase);
        }

        public static string RemoveSuffix(string stringToTrim, string suffixPattern) {
            return Regex.Replace(stringToTrim, suffixPattern + "$", string.Empty, RegexOptions.IgnoreCase);
        }

        public static string ForcePrefix(string prefix, string stringToAlter) {
            string result = stringToAlter;
            if (!result.StartsWith(prefix)) {
                result = prefix + result;
            }
            return result;
        }

        public static string ForceSuffix(string stringToAlter, string suffix) {
            string result = stringToAlter;
            if (!result.EndsWith(suffix)) {
                result += suffix;
            }
            return result;
        }

        public static string StringAfter(string masterString, string token) {
            if (Contains(masterString, token)) {
                return masterString.Substring(masterString.ToLower().LastIndexOf(token.ToLower()) + 1);
            }
            else {
                return masterString;
            }
        }

        public static string StringBefore(string masterString, string token) {
            if (Contains(masterString, token)) {
                return masterString.Substring(0, masterString.ToLower().LastIndexOf(token.ToLower()));
            }
            else {
                return string.Empty;
            }
        }

        public static string Repeat(string s, int count) {
            return string.Join(s, new string[count + 1]);
        }

        public static bool IsInList(string s, params string[] list) {
            for (int i = 0; i < list.Length; i++) {
                if (list[i] == s)
                    return true;
            }
            return false;
        }

        public static string TrimToEmpty(string s) {
            if (s == null) {
                return string.Empty;
            }
            return s.Trim();
        }

        public static string TrimToNull(string s) {
            if (s == null) {
                return null;
            }
            return s.Trim();
        }

        public static string CsvQuote(string s) {
            string workingCopy = TrimToEmpty(s).Replace("\"", "\"\"");
            if (workingCopy.IndexOf(",") > -1) {
                return "\"" + workingCopy + "\"";
            }
            return workingCopy;
        }

        public static string[] CsvQuote(string[] strings) {
            for (int i = 0; i < strings.Length; i++) {
                strings[i] = CsvQuote(strings[i]);
            }
            return strings;
        }

        public static bool AreNotEmpty(params string[] values) {
            foreach (string value in values) {
                if (TrimToEmpty(value) == string.Empty) {
                    return false;
                }
            }
            return true;
        }

        public static bool IsEmpty(string s) {
            return TrimToEmpty(s) == string.Empty;
        }
    }
}
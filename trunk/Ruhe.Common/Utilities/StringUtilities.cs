using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Ruhe.Common {
    public sealed class StringUtilities {
        private StringUtilities() {}

        public static string NullToEmpty(string value) {
            return value == null ? string.Empty : value;
        }

        public static string NullToEmpty(DBNull notGonnaUseIt) {
            return String.Empty;
        }

        public static bool Contains(string searchIn, string subString) {
            return searchIn.ToLower().IndexOf(subString.ToLower(), 0) >= 0;
        }

        public static bool Compare(string string1, string string2) {
            return String.Compare(string1, string2, true) == 0;
        }

        public static bool IsNumeric(string value) {
            double number;
            return Double.TryParse(value, NumberStyles.Float | NumberStyles.AllowThousands, NumberFormatInfo.CurrentInfo, out number);
        }

        public static string RemovePrefix(string stringToTrim, string prefixPattern) {
            return Regex.Replace(stringToTrim, "^" + prefixPattern, String.Empty, RegexOptions.IgnoreCase);
        }

        public static string RemoveSuffix(string stringToTrim, string suffixPattern) {
            return Regex.Replace(stringToTrim, suffixPattern + "$", String.Empty, RegexOptions.IgnoreCase);
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
                return String.Empty;
            }
        }

        public static string Repeat(string s, int count) {
            return String.Join(s, new string[count + 1]);
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
                return String.Empty;
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
                if (TrimToEmpty(value) == String.Empty) {
                    return false;
                }
            }
            return true;
        }
    }
}
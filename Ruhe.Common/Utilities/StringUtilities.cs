using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Ruhe.Common.Utilities {
    /// <summary>
    /// Function bucket providing common string utility methods
    /// </summary>
    public static class StringUtilities {
        public static bool AreNotEmpty(params string[] values) {
            foreach (string value in values) {
                if (value.TrimToEmpty() == string.Empty) {
                    return false;
                }
            }
            return true;
        }

        public static bool Compare(string string1, string string2) {
            return string.Compare(string1, string2, true) == 0;
        }

        public static bool Contains(this string searchIn, string subString) {
            return searchIn.ToLower().IndexOf(subString.ToLower(), 0) >= 0;
        }

        public static string CsvQuote(this string s) {
            string workingCopy = s.TrimToEmpty().Replace("\"", "\"\"");
            if (workingCopy.IndexOf(",") > -1) {
                return "\"" + workingCopy + "\"";
            }
            return workingCopy;
        }

        public static string[] CsvQuote(this string[] strings) {
            for (int i = 0; i < strings.Length; i++) {
                strings[i] = strings[i].CsvQuote();
            }
            return strings;
        }

        public static string WithPrefix(this string prefix, string stringToAlter) {
            string result = stringToAlter;
            if (!result.StartsWith(prefix)) {
                result = prefix + result;
            }
            return result;
        }

        public static string WithSuffix(this string stringToAlter, string suffix) {
            string result = stringToAlter;
            if (!result.EndsWith(suffix)) {
                result += suffix;
            }
            return result;
        }

        public static bool IsEmpty(this string s) {
            return s.TrimToEmpty() == string.Empty;
        }

        public static bool IsIn(this string s, params string[] list) {
            for (int i = 0; i < list.Length; i++) {
                if (list[i] == s)
                    return true;
            }
            return false;
        }

        public static string Quoted(this string s) {
            return string.Format("\"{0}\"", s);
        }

        public static bool IsNumeric(this string value) {
            double number;
            return double.TryParse(value, NumberStyles.Float | NumberStyles.AllowThousands, NumberFormatInfo.CurrentInfo, out number);
        }

        public static bool IsNullOrEmpty(this string s) {
            return string.IsNullOrEmpty(s);
        }

        public static string NullToEmpty(this string value) {
            return value ?? string.Empty;
        }

        public static string NullToEmpty(this DBNull notGonnaUseIt) {
            return string.Empty;
        }

        public static string WithoutPrefix(this string stringToTrim, string prefixPattern) {
            return Regex.Replace(stringToTrim, "^" + prefixPattern, string.Empty, RegexOptions.IgnoreCase);
        }

        public static string WithoutSuffix(this string stringToTrim, string suffixPattern) {
            return Regex.Replace(stringToTrim, suffixPattern + "$", string.Empty, RegexOptions.IgnoreCase);
        }

        public static string Repeat(this string s, int times) {
            return string.Join(s, new string[times + 1]);
        }

        public static string StringAfter(this string masterString, string token) {
            if (Contains(masterString, token)) {
                return masterString.Substring(masterString.ToLower().LastIndexOf(token.ToLower()) + 1);
            }
            return masterString;
        }

        public static string StringBefore(this string masterString, string token) {
            if (Contains(masterString, token)) {
                return masterString.Substring(0, masterString.ToLower().LastIndexOf(token.ToLower()));
            }
            return string.Empty;
        }

        public static string TrimToEmpty(this string s) {
            if (s == null) {
                return string.Empty;
            }
            return s.Trim();
        }

        public static string TrimToNull(this string s) {
            if (s == null) {
                return null;
            }
            string result = s.Trim();
            if (result == string.Empty)
                return null;
            return result;
        }
    }
}
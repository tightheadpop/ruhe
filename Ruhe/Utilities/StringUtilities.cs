using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Ruhe.Utilities {
    /// <summary>
    /// Function bucket providing common string utility methods
    /// </summary>
    public static class StringUtilities {
        public static bool AreNotEmpty(params string[] values) {
            foreach (var value in values) {
                if (value.TrimToEmpty() == string.Empty) {
                    return false;
                }
            }
            return true;
        }

        public static bool ContainsIgnoreCase(this string searchIn, string subString) {
            return searchIn.ToLower().IndexOf(subString.ToLower(), 0) >= 0;
        }

        public static string CsvQuote(this string s) {
            var workingCopy = s.TrimToEmpty().Replace("\"", "\"\"");
            if (workingCopy.IndexOf(",") > -1) {
                return "\"" + workingCopy + "\"";
            }
            return workingCopy;
        }

        public static string[] CsvQuote(this string[] strings) {
            for (var i = 0; i < strings.Length; i++) {
                strings[i] = strings[i].CsvQuote();
            }
            return strings;
        }

        public static bool EqualsIgnoreCase(this string string1, string string2) {
            return string.Compare(string1, string2, true) == 0;
        }

        public static bool IsEmpty(this string s) {
            return s.TrimToEmpty() == string.Empty;
        }

        public static bool IsIn(this string s, params string[] list) {
            for (var i = 0; i < list.Length; i++) {
                if (list[i] == s)
                    return true;
            }
            return false;
        }

        public static bool IsNullOrEmpty(this string s) {
            return string.IsNullOrEmpty(s);
        }

        public static bool IsNumeric(this string value) {
            double number;
            return double.TryParse(value, NumberStyles.Float | NumberStyles.AllowThousands, NumberFormatInfo.CurrentInfo, out number);
        }

        public static string NullToEmpty(this string value) {
            return value ?? string.Empty;
        }

        public static string NullToEmpty(this DBNull notGonnaUseIt) {
            return string.Empty;
        }

        public static string Quoted(this string s) {
            return string.Format("\"{0}\"", s);
        }

        public static string Repeat(this string s, int times) {
            return string.Join(s, new string[times + 1]);
        }

        public static string StringAfterFirst(this string s, string token) {
            if (s.Contains(token)) {
                return s.Substring(s.ToLower().IndexOf(token.ToLower()) + token.Length);
            }
            return s;
        }

        public static string StringAfterLast(this string masterString, string token) {
            if (masterString.Contains(token)) {
                return masterString.Substring(masterString.ToLower().LastIndexOf(token.ToLower()) + 1);
            }
            return masterString;
        }

        public static string StringBeforeFirst(this string s, string token) {
            if (s.Contains(token)) {
                return s.Substring(0, s.ToLower().IndexOf(token.ToLower()));
            }
            return s;
        }

        public static string StringBeforeLast(this string s, string token) {
            if (s.Contains(token)) {
                return s.Substring(0, s.ToLower().LastIndexOf(token.ToLower()));
            }
            return s;
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
            var result = s.Trim();
            if (result == string.Empty)
                return null;
            return result;
        }

        public static string WithoutPrefix(this string s, string prefix) {
            return s.IsNullOrEmpty() || !s.StartsWith(prefix) ? s : s.StringAfterFirst(prefix);
        }

        public static string WithoutPrefixPattern(this string stringToTrim, string prefixPattern) {
            return Regex.Replace(stringToTrim, "^" + prefixPattern, string.Empty, RegexOptions.IgnoreCase);
        }

        public static string WithoutSuffixPattern(this string stringToTrim, string suffixPattern) {
            return Regex.Replace(stringToTrim, suffixPattern + "$", string.Empty, RegexOptions.IgnoreCase);
        }

        public static string WithPrefix(this string prefix, string stringToAlter) {
            var result = stringToAlter;
            if (!result.StartsWith(prefix)) {
                result = prefix + result;
            }
            return result;
        }

        public static string WithSuffix(this string stringToAlter, string suffix) {
            var result = stringToAlter;
            if (!result.EndsWith(suffix)) {
                result += suffix;
            }
            return result;
        }
    }
}
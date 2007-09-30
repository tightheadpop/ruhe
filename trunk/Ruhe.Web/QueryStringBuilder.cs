using System;
using System.Collections.Specialized;
using System.Text;
using System.Web;
using Ruhe.Common;

namespace Ruhe.Web {
    public class QueryStringBuilder : NameValueCollection {
        public QueryStringBuilder(NameValueCollection collection) : base(collection) {}
        public QueryStringBuilder() : base() {}
        public QueryStringBuilder(string encodedInput) : this(Parse(encodedInput)) {}

        public static QueryStringBuilder Parse(string encodedInput) {
            QueryStringBuilder querystring = new QueryStringBuilder();
            string name;
            string value;
            string[] nameAndValue;

            foreach (string pair in encodedInput.Split("&".ToCharArray())) {
                nameAndValue = pair.Split("=".ToCharArray(), 2);
                name = HttpUtility.UrlDecode(nameAndValue[0]);
                value = HttpUtility.UrlDecode(StringUtilities.NullToEmpty(nameAndValue[1]));

                querystring.Add(name, value);
            }
            return querystring;
        }

        public override void Add(string name, string value) {
            if (name == null) {
                throw new ArgumentException("name cannot be null.", "name");
            }
            base.Add(name, StringUtilities.NullToEmpty(value));
        }

        public void Add(string name, int value) {
            Add(name, value.ToString());
        }

        public void Add(string name, long value) {
            Add(name, value.ToString());
        }

        public void Add(string name, DateTime value) {
            Add(name, value.ToString());
        }

        public override string ToString() {
            StringBuilder result = new StringBuilder(300);
            foreach (string key in AllKeys) {
                foreach (string value in GetValues(key)) {
                    result.AppendFormat("&{0}={1}", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(value));
                }
            }

            if (result.Length > 0) {
                result.Remove(0, 1);
            }

            return result.ToString();
        }
    }
}
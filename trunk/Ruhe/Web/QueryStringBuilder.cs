using System;
using System.Collections.Specialized;
using System.Text;
using System.Web;
using LiquidSyntax;

namespace Ruhe.Web {
    public class QueryStringBuilder : NameValueCollection {
        public QueryStringBuilder(NameValueCollection collection) : base(collection) {}
        public QueryStringBuilder() {}
        public QueryStringBuilder(string encodedInput) : this(Parse(encodedInput)) {}

        public override void Add(string name, string value) {
            if (name == null) {
                throw new ArgumentException("name cannot be null.", "name");
            }
            base.Add(name, value.NullToEmpty());
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
            var result = new StringBuilder(300);
            foreach (var key in AllKeys) {
                foreach (var value in GetValues(key)) {
                    result.AppendFormat("&{0}={1}", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(value));
                }
            }

            if (result.Length > 0) {
                result.Remove(0, 1);
            }

            return result.ToString();
        }

        public static QueryStringBuilder Parse(string encodedInput) {
            var querystring = new QueryStringBuilder();

            foreach (var pair in encodedInput.WithoutPrefix("?").Split("&".ToCharArray())) {
                var nameAndValue = pair.Split("=".ToCharArray(), 2);
                var name = HttpUtility.UrlDecode(nameAndValue[0]);
                var value = HttpUtility.UrlDecode(nameAndValue[1].NullToEmpty());

                querystring.Add(name, value);
            }
            return querystring;
        }
    }
}
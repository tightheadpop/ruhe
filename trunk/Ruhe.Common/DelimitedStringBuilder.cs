using System.Text;

namespace Ruhe.Common {
    /// <summary>
    /// Wraps a StringBuilder instance, providing a specified delimiter
    /// between appended values.
    /// </summary>
    public class DelimitedStringBuilder {
        private readonly StringBuilder builder;
        private readonly string delimiter;

        public DelimitedStringBuilder(string delimiter) {
            builder = new StringBuilder();
            this.delimiter = delimiter;
        }

        public DelimitedStringBuilder(string delimiter, int capacity) {
            builder = new StringBuilder(capacity);
            this.delimiter = delimiter;
        }

        public int Length {
            get { return builder.Length; }
            set { builder.Length = value; }
        }

        public void Append(string value) {
            if (builder.Length > 0) {
                builder.Append(delimiter);
            }
            builder.Append(value);
        }

        public void AppendFormat(string value, params object[] args) {
            if (builder.Length > 0) {
                builder.Append(delimiter);
            }
            builder.AppendFormat(value, args);
        }

        public override string ToString() {
            return builder.ToString();
        }
    }
}
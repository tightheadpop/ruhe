using System;

namespace Ruhe.Common {
    public abstract class StringValueType : IEquatable<StringValueType> {
        private string value;

        public StringValueType(string value) {
            Validate.IsNotNull(value, GetType().Name + " must have non-null underlying value");
            this.value = value;
        }

        public bool Equals(StringValueType other) {
            if (other == null) return false;
            if (!GetType().Equals(other.GetType()))
                return false;
            return Equals(value, other.value);
        }

        public override bool Equals(object other) {
            if (ReferenceEquals(this, other)) return true;
            return Equals(other as StringValueType);
        }

        public override int GetHashCode() {
            return value.GetHashCode();
        }

        public override string ToString() {
            return value;
        }

        public static bool operator !=(StringValueType stringValueType1, StringValueType stringValueType2) {
            return !Equals(stringValueType1, stringValueType2);
        }

        public static bool operator ==(StringValueType stringValueType1, StringValueType stringValueType2) {
            return Equals(stringValueType1, stringValueType2);
        }
    }
}
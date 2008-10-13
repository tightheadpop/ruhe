using System;

namespace Ruhe.Common {
    public abstract class ValueType<T> : IEquatable<ValueType<T>> {
        private T value;

        protected ValueType(T value) {
            value.MustNotBeNull(GetType().Name + " must have non-null underlying value");
            this.value = value;
        }

        public T Value {
            get { return value; }
        }

        public bool Equals(ValueType<T> other) {
            if (other == null)
                return false;
            return GetType().Equals(other.GetType()) && value.Equals(other.value);
        }

        public override bool Equals(object other) {
            return ReferenceEquals(this, other) || Equals(other as ValueType<T>);
        }

        public override int GetHashCode() {
            return value.GetHashCode();
        }

        public override string ToString() {
            return value.ToString();
        }

        public static bool operator !=(ValueType<T> valueType1, ValueType<T> valueType2) {
            return !Equals(valueType1, valueType2);
        }

        public static bool operator ==(ValueType<T> valueType1, ValueType<T> valueType2) {
            return Equals(valueType1, valueType2);
        }
    }
}
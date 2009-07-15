using System;

namespace Ruhe {
    public abstract class ValueType<T> : IEquatable<ValueType<T>> {
        protected ValueType(T value) {
            value.MustNotBeNull(GetType().Name + " must have non-null underlying value");
            Value = value;
        }

        public T Value { get; private set; }

        public bool Equals(ValueType<T> other) {
            if (other == null)
                return false;
            return GetType().Equals(other.GetType()) && Value.Equals(other.Value);
        }

        public override bool Equals(object other) {
            return ReferenceEquals(this, other) || Equals(other as ValueType<T>);
        }

        public override int GetHashCode() {
            return Value.GetHashCode();
        }

        public override string ToString() {
            return Value.ToString();
        }

        public static bool operator !=(ValueType<T> valueType1, ValueType<T> valueType2) {
            return !Equals(valueType1, valueType2);
        }

        public static bool operator ==(ValueType<T> valueType1, ValueType<T> valueType2) {
            return Equals(valueType1, valueType2);
        }
    }
}
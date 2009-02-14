using System;

namespace Ruhe.Common {
    public abstract class ValueType<T,V> : IEquatable<ValueType<T,V>> where V : ValueType<T, V>{
        private readonly T value;

        protected ValueType(T value) {
            value.MustNotBeNull(GetType().Name + " must have non-null underlying value");
            this.value = value;
        }

        public T Value {
            get { return value; }
        }

        public bool Equals(ValueType<T,V> other) {
            if (other == null)
                return false;
            return GetType().Equals(other.GetType()) && value.Equals(other.value);
        }

        public override bool Equals(object other) {
            return ReferenceEquals(this, other) || Equals(other as ValueType<T,V>);
        }

        public static V From(T value) {
// ReSharper disable CompareNonConstrainedGenericWithNull
            if (value == null)
// ReSharper restore CompareNonConstrainedGenericWithNull
                return null;
            return (V) Activator.CreateInstance(typeof(V), value);
        }

        public override int GetHashCode() {
            return value.GetHashCode();
        }

        public override string ToString() {
            return value.ToString();
        }

        public static bool operator !=(ValueType<T,V> valueType1, ValueType<T,V> valueType2) {
            return !Equals(valueType1, valueType2);
        }

        public static bool operator ==(ValueType<T,V> valueType1, ValueType<T,V> valueType2) {
            return Equals(valueType1, valueType2);
        }
    }
}
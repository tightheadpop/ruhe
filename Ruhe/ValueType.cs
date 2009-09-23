using System;
using System.Reflection;

namespace Ruhe {
    public abstract class ValueType<TValue, TValueType> : IEquatable<ValueType<TValue, TValueType>> where TValueType : ValueType<TValue, TValueType> {
        protected ValueType(TValue value) {
            value.MustNotBeNull(GetType().Name + " must have non-null underlying value");
            Value = value;
        }

        public TValue Value { get; private set; }

        public static TValueType From(TValue value) {
            if (Equals(value, null)) return null;
            try {
                return (TValueType) Activator.CreateInstance(typeof(TValueType), new object[] {value});
            }catch(TargetInvocationException e) {
                throw e.InnerException;
            }
        }

        public bool Equals(ValueType<TValue, TValueType> other) {
            if (other == null)
                return false;
            return GetType().Equals(other.GetType()) && Value.Equals(other.Value);
        }

        public override bool Equals(object other) {
            return ReferenceEquals(this, other) || Equals(other as ValueType<TValue, TValueType>);
        }

        public override int GetHashCode() {
            return Value.GetHashCode();
        }

        public override string ToString() {
            return Value.ToString();
        }

        public static bool operator !=(ValueType<TValue, TValueType> valueType1, ValueType<TValue, TValueType> valueType2) {
            return !Equals(valueType1, valueType2);
        }

        public static bool operator ==(ValueType<TValue, TValueType> valueType1, ValueType<TValue, TValueType> valueType2) {
            return Equals(valueType1, valueType2);
        }
    }
}
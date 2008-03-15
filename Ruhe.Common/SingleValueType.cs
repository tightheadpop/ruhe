using System;

namespace Ruhe.Common {
    public class SingleValueType : IEquatable<SingleValueType> {
        private float value;

        public SingleValueType(float value) {
            this.value = value;
        }

        public bool Equals(SingleValueType singleValueType) {
            if (singleValueType == null) return false;
            if (!GetType().Equals(singleValueType.GetType()))
                return false;
            return value == singleValueType.value;
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as SingleValueType);
        }

        public override int GetHashCode() {
            return value.GetHashCode();
        }

        public float ToSingle() {
            return value;
        }

        public override string ToString() {
            return value.ToString();
        }

        public static bool operator !=(SingleValueType singleValueType1, SingleValueType singleValueType2) {
            return !Equals(singleValueType1, singleValueType2);
        }

        public static bool operator ==(SingleValueType singleValueType1, SingleValueType singleValueType2) {
            return Equals(singleValueType1, singleValueType2);
        }
    }
}
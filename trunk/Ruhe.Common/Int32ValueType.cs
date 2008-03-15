using System;

namespace Ruhe.Common {
    public class Int32ValueType : IEquatable<Int32ValueType> {
        private readonly int value;

        public Int32ValueType(int value) {
            this.value = value;
        }

        public bool Equals(Int32ValueType int32ValueType) {
            if (int32ValueType == null) return false;
            if (!GetType().Equals(int32ValueType.GetType()))
                return false;
            return value == int32ValueType.value;
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as Int32ValueType);
        }

        public override int GetHashCode() {
            return value;
        }

        public int ToInt32() {
            return value;
        }

        public override string ToString() {
            return value.ToString();
        }

        public static bool operator !=(Int32ValueType int32ValueType1, Int32ValueType int32ValueType2) {
            return !Equals(int32ValueType1, int32ValueType2);
        }

        public static bool operator ==(Int32ValueType int32ValueType1, Int32ValueType int32ValueType2) {
            return Equals(int32ValueType1, int32ValueType2);
        }
    }
}
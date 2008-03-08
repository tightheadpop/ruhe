using System;
using System.Collections;

namespace Ruhe.Common {
    public class Validate : ValidateOrThrow<ArgumentException> {}

    public class ValidateOrThrow<T> where T : Exception {
        protected static Type exceptionType = typeof(T);

        public static void HasNoNullElements(IEnumerable list, string errorMessage) {
            foreach (object o in list) {
                IsNotNull(o, errorMessage);
            }
        }

        public static void IsFalse(bool expression, string errorMessage) {
            That(!expression, errorMessage);
        }

        public static void IsNotEmpty(IEnumerable list, string errorMessage) {
            IsNotNull(list, errorMessage);
#pragma warning disable 168
            foreach (object o in list) {
#pragma warning restore 168
                return;
            }
            ThrowNewException(errorMessage);
        }

        public static void IsNotNull(object obj, string errorMessage) {
            That(obj != null, errorMessage);
        }

        public static void IsNull(object obj, string errorMessage) {
            That(obj == null, errorMessage);
        }

        public static void IsTrue(bool expression, string errorMessage) {
            That(expression, errorMessage);
        }

        public static void That(bool expression, string errorMessage) {
            if (!expression)
                ThrowNewException(errorMessage);
        }

        private static void ThrowNewException(string errorMessage) {
            if (null != exceptionType.GetConstructor(new Type[] {typeof(string)}))
                throw (T) Activator.CreateInstance(exceptionType, errorMessage);
            throw (T) Activator.CreateInstance(exceptionType);
        }
    }
}
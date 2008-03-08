using System;
using System.Collections;

namespace Ruhe.Common {
    public class Validate : ValidateOrThrow<ArgumentException> {}

    public class ValidateOrThrow<T> where T : Exception {
        protected static Type exceptionType = typeof(T);

        public static void HasNoNullElements(IEnumerable list, string errorMessage) {
            IsNotNull(list, "list cannot be null");
            HasNoNullElements(list, errorMessage, new object[0]);
        }

        public static void HasNoNullElements(IEnumerable list, string errorMessageFormat, params object[] parameters) {
            foreach (object o in list) {
                IsNotNull(o, string.Format(errorMessageFormat, parameters));
            }
        }

        public static void IsFalse(bool expression, string errorMessage) {
            That(!expression, errorMessage);
        }

        public static void IsFalse(bool expression, string errorMessageFormat, params object[] parameters) {
            IsFalse(expression, string.Format(errorMessageFormat, parameters));
        }

        public static void IsNotEmpty(IEnumerable list, string errorMessage) {
            IsNotNull(list, errorMessage);
            if (list.GetEnumerator().MoveNext()) return;
            ThrowNewException(errorMessage);
        }

        public static void IsNotEmpty(IEnumerable list, string errorMessageFormat, params object[] parameters) {
            IsNotEmpty(list, string.Format(errorMessageFormat, parameters));
        }

        public static void IsNotNull(object obj, string errorMessage) {
            That(obj != null, errorMessage);
        }

        public static void IsNotNull(object obj, string errorMessageFormat, params object[] parameters) {
            IsNotNull(obj, string.Format(errorMessageFormat, parameters));
        }

        public static void IsTrue(bool expression, string errorMessage) {
            That(expression, errorMessage);
        }

        public static void IsTrue(bool expression, string errorMessageFormat, params object[] parameters) {
            IsTrue(expression, string.Format(errorMessageFormat, parameters));
        }

        public static void That(bool expression, string errorMessage) {
            if (!expression)
                ThrowNewException(errorMessage);
        }

        public static void That(bool expression, string errorMessageFormat, params object[] parameters) {
            That(expression, string.Format(errorMessageFormat, parameters));
        }

        private static void ThrowNewException(string errorMessage) {
            if (null != exceptionType.GetConstructor(new Type[] {typeof(string)}))
                throw (T) Activator.CreateInstance(exceptionType, errorMessage);
            throw (T) Activator.CreateInstance(exceptionType);
        }
    }
}
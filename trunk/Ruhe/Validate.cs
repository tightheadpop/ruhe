using System;
using System.Collections;

namespace Ruhe {
    public static class Validate {
        public static void MustBeFalse(this bool expression) {
            expression.MustBeFalse("Expression should be false.");
        }

        public static void MustBeFalse(this bool expression, string errorMessage) {
            That(!expression, errorMessage);
        }

        public static void MustBeFalse(this bool expression, string errorMessageFormat, params object[] parameters) {
            expression.MustBeFalse(string.Format(errorMessageFormat, parameters));
        }

        public static void MustBeTrue(this bool expression) {
            expression.MustBeTrue("Expression should be true.");
        }

        public static void MustBeTrue(this bool expression, string errorMessage) {
            That(expression, errorMessage);
        }

        public static void MustBeTrue(this bool expression, string errorMessageFormat, params object[] parameters) {
            expression.MustBeTrue(string.Format(errorMessageFormat, parameters));
        }

        public static void MustEqual(this object o, object other) {
            Equals(o, other).MustBeTrue();
        }

        public static void MustEqual(this object o, object other, string errorMessage) {
            Equals(o, other).MustBeTrue(errorMessage);
        }

        public static void MustHaveNoNullElements(this IEnumerable list) {
            list.MustHaveNoNullElements("List should not contain any null items.");
        }

        public static void MustHaveNoNullElements(this IEnumerable list, string errorMessage) {
            list.MustNotBeNull();
            list.MustHaveNoNullElements(errorMessage, new object[0]);
        }

        public static void MustHaveNoNullElements(this IEnumerable list, string errorMessageFormat, params object[] parameters) {
            foreach (var o in list) {
                MustNotBeNull(o, string.Format(errorMessageFormat, parameters));
            }
        }

        public static void MustNotBeEmpty(this IEnumerable list) {
            list.MustNotBeEmpty("List should not be empty.");
        }

        public static void MustNotBeEmpty(this IEnumerable list, string errorMessage) {
            list.MustNotBeNull(errorMessage);
            if (list.GetEnumerator().MoveNext()) return;
            Throw(errorMessage);
        }

        public static void MustNotBeEmpty(IEnumerable list, string errorMessageFormat, params object[] parameters) {
            list.MustNotBeEmpty(string.Format(errorMessageFormat, parameters));
        }

        public static void MustNotBeNull(this object obj) {
            obj.MustNotBeNull("object should not be null");
        }

        public static void MustNotBeNull(this object obj, string errorMessage) {
            That(obj != null, errorMessage);
        }

        public static void MustNotBeNull(this object obj, string errorMessageFormat, params object[] parameters) {
            obj.MustNotBeNull(string.Format(errorMessageFormat, parameters));
        }

        public static void That(bool expression, string errorMessage) {
            if (!expression)
                Throw(errorMessage);
        }

        public static void That(bool expression, string errorMessageFormat, params object[] parameters) {
            That(expression, string.Format(errorMessageFormat, parameters));
        }

        private static void Throw(string errorMessage) {
            throw new ArgumentException(errorMessage);
        }
    }
}
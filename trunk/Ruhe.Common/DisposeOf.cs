using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace Ruhe.Common {
    /// <summary>
    /// Utility for disposing cleanly of items
    /// </summary>
    public class DisposeOf {
        private static readonly string[] DisposingMethods = new string[] {"Flush", "Close", "Dispose"};
        private DisposeOf() {}

        private static IEnumerable<MethodInfo> GetDisposingMethods(object obj) {
            List<MethodInfo> methods = new List<MethodInfo>(DisposingMethods.Length);
            foreach (string methodName in DisposingMethods) {
                methods.Add(obj.GetType().GetMethod(methodName, new Type[] {}));
            }
            return methods;
        }

        private static void Invoke(object obj, IEnumerable<MethodInfo> methods, bool rethrowExceptions) {
            foreach (MethodInfo method in methods) {
                if (method != null) {
                    try {
                        method.Invoke(obj, null);
                    }
                    catch (Exception e) {
                        if (rethrowExceptions)
                            throw e.InnerException;
                    }
                }
            }
        }

        private static void InvokeDisposingMethods(object obj, bool rethrowExceptions) {
            Invoke(obj, GetDisposingMethods(obj), rethrowExceptions);
        }

        /// <summary>
        /// Handles common clean up tasks, squelching exceptions.
        /// </summary>
        /// <remarks>
        /// Flush, Close, Dispose, in that order.
        /// </remarks>
        public static void These(params object[] items) {
            These((IEnumerable) items);
        }

        public static void These(IEnumerable items) {
            if (items == null)
                return;
            foreach (object item in items) {
                if (item != null) {
                    InvokeDisposingMethods(item, true);
                }
            }
        }

        public static void TheseQuietly(params object[] items) {
            TheseQuietly((IEnumerable) items);
        }

        public static void TheseQuietly(IEnumerable items) {
            if (items == null)
                return;
            foreach (object item in items) {
                if (item != null) {
                    InvokeDisposingMethods(item, false);
                }
            }
        }
    }
}
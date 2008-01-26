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

        /// <summary>
        /// Handles common clean up tasks, squelching exceptions.
        /// </summary>
        /// <remarks>
        /// Flush, Close, Dispose, in that order.
        /// </remarks>
        public static void These(params object[] stuff) {
            if (stuff == null) {
                return;
            }
            foreach (object thing in stuff) {
                if (thing != null) {
                    InvokeDisposingMethods(thing);
                }
            }
        }

        private static void InvokeDisposingMethods(object obj) {
            Invoke(obj, GetDisposingMethods(obj));
        }

        private static MethodInfo[] GetDisposingMethods(object obj) {
            ArrayList methods = new ArrayList(DisposingMethods.Length);
            foreach (string methodName in DisposingMethods) {
                methods.Add(obj.GetType().GetMethod(methodName, new Type[] {}));
            }
            return (MethodInfo[]) methods.ToArray(typeof(MethodInfo));
        }

        private static void Invoke(object obj, IEnumerable<MethodInfo> methods) {
            foreach (MethodInfo method in methods) {
                if (method != null) {
                    try {
                        method.Invoke(obj, null);
                    }
                    catch {
                        //do nothing
                    }
                }
            }
        }
    }
}
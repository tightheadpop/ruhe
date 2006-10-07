using System;
using System.Collections;
using System.Reflection;

namespace Ruhe.Common {
	public class Disposer {
		private static readonly string[] DisposingMethods = new string[] {"Flush", "Close", "Dispose"};
		private Disposer() {}

		/// <summary>
		/// Handles common clean up tasks, squelching exceptions.
		/// </summary>
		public static void DisposeOf(object obj) {
			if (obj != null) {
				InvokeDisposingMethods(obj);
			}
		}

		/// <summary>
		/// Handles common clean up tasks, squelching exceptions.
		/// </summary>
		/// <remarks>
		/// Flush, Close, Dispose, in that order.
		/// </remarks>
		public static void DisposeOf(params object[] stuff) {
			if (stuff == null) {
				return;
			}
			foreach (object thing in stuff) {
				DisposeOf(thing);
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

		private static void Invoke(object obj, MethodInfo[] methods) {
			foreach (MethodInfo method in methods) {
				if (method != null) {
					try {
						method.Invoke(obj, null);
					}
					catch {}
				}
			}
		}
	}
}
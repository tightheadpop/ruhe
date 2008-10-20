using System;
using System.Collections.Generic;

namespace Ruhe.Common.Utilities {
    /// <summary>
    /// Utility for disposing cleanly of items
    /// </summary>
    public static class DisposeUtilities {
        /// <summary>
        /// Disposes all items in the list, throwing any exceptions encountered, and ignoring null items.
        /// </summary>
        public static void Dispose<I>(this IEnumerable<I> disposables) where I : IDisposable {
            if (disposables == null) return;
            foreach (IDisposable item in disposables) {
                if (item != null) {
                    item.Dispose();
                }
            }
        }

        public static void DisposeQuietly<I>(this IEnumerable<I> disposables) where I : IDisposable {
            if (disposables == null)
                return;
            foreach (IDisposable item in disposables) {
                if (item != null) {
                    item.DisposeQuietly();
                }
            }
        }

        public static void DisposeQuietly(this IDisposable disposable) {
            if (disposable == null) return;
            try {
                disposable.Dispose();
// ReSharper disable EmptyGeneralCatchClause
            }
            catch {}
// ReSharper restore EmptyGeneralCatchClause
        }
    }
}
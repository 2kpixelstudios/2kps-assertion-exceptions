using System.Diagnostics;

namespace CometPeak.AssertionExceptions {
    /// <summary>
    /// Contains assertions that may be used outside of unit tests, and are only included in Debug builds.
    /// </summary>
    public static class Assert {
        [Conditional("DEBUG")]
        public static void IsTrue(bool condition) {
            if (!condition)
                throw new AssertionException();
        }

        [Conditional("DEBUG")]
        public static void IsTrue(bool condition, string message) {
            if (!condition)
                throw new AssertionException(message);
        }

        [Conditional("DEBUG")]
        public static void IsFalse(bool condition) {
            if (condition)
                throw new AssertionException();
        }

        [Conditional("DEBUG")]
        public static void IsFalse(bool condition, string message) {
            if (condition)
                throw new AssertionException(message);
        }

        [Conditional("DEBUG")]
        public static void IsNull(object obj) {
            if (obj != null)
                throw new AssertionException();
        }

        [Conditional("DEBUG")]
        public static void IsNull(object obj, string message) {
            if (obj != null)
                throw new AssertionException(message);
        }

        [Conditional("DEBUG")]
        public static void IsNotNull(object obj) {
            if (obj == null)
                throw new AssertionException();
        }

        [Conditional("DEBUG")]
        public static void IsNotNull(object obj, string message) {
            if (obj == null)
                throw new AssertionException(message);
        }
    }
}

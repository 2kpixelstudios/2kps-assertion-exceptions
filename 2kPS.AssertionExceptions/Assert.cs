using System.Diagnostics;

namespace PS2k.AssertionExceptions {
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
    }
}

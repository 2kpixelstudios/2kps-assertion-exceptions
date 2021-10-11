using System;
using System.Collections.Generic;
using System.Text;

namespace CometPeak.AssertionExceptions {
    /// <summary>
    /// <para>An <see cref="Exception"/> that is thrown when an assertion is failed.</para>
    /// <para>This should signify that critical logic within your code was broken, and code changes will be required to fix the program logic to work as intended.</para>
    /// </summary>
    public class AssertionException : Exception {
        public AssertionException() { }
        public AssertionException(string message) : base(message) { }
    }
}

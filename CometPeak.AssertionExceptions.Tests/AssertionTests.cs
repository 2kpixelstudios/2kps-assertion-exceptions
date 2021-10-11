using System;
using NUnit.Framework;

using NUnitAssert = NUnit.Framework.Assert;
using CometPeakAssert = CometPeak.AssertionExceptions.Assert;

namespace CometPeak.AssertionExceptions.Tests {
    [Parallelizable]
    public class AssertionTests {
        private bool isDebugBuild = false;

        [OneTimeSetUp]
        public void OneTimeSetup() {
#if DEBUG
            isDebugBuild = true;
#endif
        }

        [Test]
        public void AssertThrowsInDebugBuilds() {
            if (!isDebugBuild)
                NUnitAssert.Ignore("This test is only for debug build mode.");

            NUnitAssert.Throws<AssertionException>(() => {
                CometPeakAssert.IsTrue(false, "This should be an assertion exception!");
            });
        }

        [Test]
        public void AssertDoesNotThrowInReleaseBuilds() {
            if (isDebugBuild)
                NUnitAssert.Ignore("This test is only for release build mode.");

            NUnitAssert.DoesNotThrow(() => {
                CometPeakAssert.IsTrue(false, "This should NOT be thrown in release builds!");
            });
        }
    }
}
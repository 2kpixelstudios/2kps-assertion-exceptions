using System;
using NUnit.Framework;

using NUnitAssert = NUnit.Framework.Assert;
using PS2kAssert = PS2k.AssertionExceptions.Assert;

namespace PS2k.AssertionExceptions.Tests {
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
                PS2kAssert.IsTrue(false, "This should be an assertion exception!");
            });
        }

        [Test]
        public void AssertDoesNotThrowInReleaseBuilds() {
            if (isDebugBuild)
                NUnitAssert.Ignore("This test is only for release build mode.");

            NUnitAssert.DoesNotThrow(() => {
                PS2kAssert.IsTrue(false, "This should NOT be thrown in release builds!");
            });
        }
    }
}
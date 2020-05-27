using System;

using NUnit.Framework;

namespace Tasks.Tests
{
    [TestFixture()]
    public class TestUVersion
    {
        [TestCase("1.2.3", "1.2.3", 0)]
        [TestCase("1.2.3", "4.5.6", -1)]
        [TestCase("1.2.3", "1.23.3", -1)]
        [TestCase("1.2.3", "1.2.333", -1)]
        public void TestWithEqualDotNum(string v1, string v2, int res)
        {
            AnyTest(v1, v2, res);
        }

        [TestCase("1", "1", 0)]
        [TestCase("1", "9", -1)]
        [TestCase("1", "0", 1)]
        public void TestSingleNum(string v1, string v2, int res)
        {
            AnyTest(v1, v2, res);
        }

        [TestCase("1.2", "1.2.0", 0)]
        [TestCase("1.2", "1.2.3", -1)]
        [TestCase("1.2.3", "1.2.3.4", -1)]
        public void TestWithDifferentDotNum(string v1, string v2, int res)
        {
            AnyTest(v1, v2, res);
        }

        //////////////////////////////////////////////////
        // Tests backend
        //////////////////////////////////////////////////

        private void AnyTest(string v1, string v2, int res)
        {
            Assert.AreEqual(
                UVersion.CompareVersions(v1, v2), res
            );

            if (res == 0) return;

            int opposite = res == 1 ? -1 : 1;
            Assert.AreEqual(
                UVersion.CompareVersions(v2, v1), opposite
            );
        }
    }
}

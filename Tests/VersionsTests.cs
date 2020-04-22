using NUnit.Framework;
using Functions;

namespace VersionsTests
{
    [TestFixture]
    class VersionsTests
    {
        [TestCase("1", "1.1", -1)]
        [TestCase("1.1.0", "1.0.1", 1)]
        [TestCase("1.0.0.0", "1.0", 0)]
        [TestCase("2.1.0.0.1", "2.1.0.1.1", -1)]
        [TestCase("1.2.0.0.0.0.0.0.0", "1.0.2.0.0", 1)]
        [TestCase("1.2.3", "4.5.6", -1)]

        public void CompareVersions(string v1, string v2, int res)
        {
            int funcRes = Versions.CompareVersions(v1, v2);
            Assert.AreEqual(funcRes, res);
        }
    }
}

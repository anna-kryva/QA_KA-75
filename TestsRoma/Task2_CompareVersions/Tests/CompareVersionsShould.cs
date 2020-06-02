using Utils;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class CompareVersionsShould
    {
        [TestCase("1.2.3", "4.5.6", -1)]
        [TestCase("1", "1.0", 0)]
        [TestCase("1.1.0", "1.0.1", 1)]
        public void CompareVersions_ReturnTrue(string v1, string v2, int expected)
        {
            Assert.AreEqual(expected, Functions.CompareVersions(v1, v2));
        }
    }
}
using NUnit.Framework;
using Task2_CompareVersions;

namespace Task2_Tests
{
    [TestFixture]
    public class VersionCompareShould
    {

        private VersionCompare _versionCompare;

        [SetUp]
        public void SetUp()
        {
            _versionCompare = new VersionCompare();
        }

        [TestCase("4.2", "1.1")]
        [TestCase("1.10", "1")]
        [TestCase("5.7.9.6", "5.7.9.0")]
        public void VersionCompare_FirstGreater_ReturnTrue(string version1, string version2)
        {
            int result = _versionCompare.versionCompare(version1, version2);

            Assert.AreEqual(1, result);
        }

        [TestCase("4.2", "4.2")]
        [TestCase("1.0", "1")]
        [TestCase("5.7.9.6", "5.7.9.6")]
        public void VersionCompare_Equal_ReturnTrue(string version1, string version2)
        {
            int result = _versionCompare.versionCompare(version1, version2);

            Assert.AreEqual(0, result);
        }

        [TestCase("4.2", "4.2.3")]
        [TestCase("1.0", "1.10")]
        [TestCase("5.7.9.0", "5.7.9.6")]
        public void VersionCompare_SecondGreater_ReturnTrue(string version1, string version2)
        {
            int result = _versionCompare.versionCompare(version1, version2);

            Assert.AreEqual(-1, result);
        }
    }
}

using NUnit.Framework;
using QueueNamespace;

namespace QueueAndCompareTests
{
    [TestFixture]
    public class StringsCompareTests
    {
        [TestCase("1.2.3", "4.5.6", -1)]
        [TestCase("1", "1.0.1", -1)]
        [TestCase("1.1.3", "1.1.0", 1)]
        [TestCase("1", "1.0", 0)]
        [TestCase("1.2.3", "0", 1)]
        public void StringCompare_ForValidCredentials(string str1, string str2, int result)
        {
            Assert.AreEqual(Methods.CompareVersions(str1, str2), result);
        }
        [Test]
        public void StringCompare_ForNonValidCredentials()
        {
            string str1 = "asd";
            string str2 = "fdv.";
            try
            {
                Methods.CompareVersions(str1, str2);
            }
            catch (System.ArgumentException e)
            {
                StringAssert.Contains("has incorrect format", e.Message);
            }
        }
    }
}

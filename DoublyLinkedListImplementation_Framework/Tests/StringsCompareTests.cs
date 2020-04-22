using NUnit.Framework;
using DoublyLinkedList;

namespace ListAndCompareTests
{
    [TestFixture]
    public class StringsCompareTests
    {
        [TestCase("1.2.3", "4.5.6", -1)]
        [TestCase("1.1.3", "1.1.0", 1)]
        [TestCase("1.2.3", "0.2.1", 1)]
        public void StringCompare_ForValidCredentials(string str1, string str2, int result)
        {
            Assert.AreEqual(Methods.CompareVersions(str1, str2), result);
        }
        [TestCase("14.11.2", "asdafa")]
        [TestCase("11.21.2", "12.s.5")]
        public void StringCompare_ForNonValidCredentials(string valid, string invalid)
        {
            try
            {
                Methods.CompareVersions(valid, invalid);
            }
            catch (System.ArgumentException e)
            {
                StringAssert.Contains("Invalid version format: " + invalid, e.Message);
            }
        }
    }
}

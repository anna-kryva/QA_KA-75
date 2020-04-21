using NUnit.Framework;


namespace TRPZ.Compare
{
    [TestFixture]
    public class CompareTests
    {
        

        [SetUp]
        public void Setup()
        {
        }

        [TestCase("1.2.3", "4.5.6", ExpectedResult = -1)]
        [TestCase("1.2.3", "1.23", ExpectedResult = -1)]
        [TestCase("1", "1.0", ExpectedResult = 0)]
        [TestCase("1.1.0", "1.0.1", ExpectedResult = 1)]
        [TestCase("1.0.0.0.0.0.0.0.0.0", "1.0.0.0.0.0.0.0.0.0.0.0.0", ExpectedResult = 0)]
        [TestCase("1.0.0.0.0.0.0.0.0.0.0.0.0", "1.0.0.0.0.0.0.0.0.0", ExpectedResult = 0)]
        [TestCase("1.0.0.0.0.0.0.0.0.1", "1.0.0.0.0.0.0.0.0.0.0.0.1", ExpectedResult = 1)]
        [TestCase("1.0.0.0.0.0.0.0.0.0.0.0.1", "1.0.0.0.0.0.0.0.0.1", ExpectedResult = -1)]
        public int CompareVersionsTests(string v1, string v2)
        {
            return Compare.CompareVersions(v1,v2);
        }


    }
}
using NUnit.Framework;

namespace QA1
{
    public class ComparerTests
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void minusOneTest()
        {
            Comparer c = new Comparer();
            Assert.AreEqual(-1, c.CompareVersions("1.2.3", "4.5.6"));
        }
        [Test]
        public void plusOneTest()
        {
            Comparer c = new Comparer();
            Assert.AreEqual(1, c.CompareVersions("4.5.6.3", "4.5.6"));
        }
        [Test]
        public void ZeroTest()
        {
            Comparer c = new Comparer();
            Assert.AreEqual(0, c.CompareVersions("4.5.6", "4.5.6.0"));
        }
        [Test]
        public void PlusOneTest2()
        {
            Comparer c = new Comparer();
            Assert.AreEqual(1, c.CompareVersions("4.7.6", "4.5.6.0"));
        }

    }
}
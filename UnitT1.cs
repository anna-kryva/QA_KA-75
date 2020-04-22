using System;
using NUnit.Framework;

namespace Lab1
{
    [TestFixture]
    class ListTests
    {
        [Test]
        public void AddFiguresAndCountTest()
        {
            Mock.AddRectangles();
            Assert.AreEqual(5, Mock.figures.Count);
        }

        [Test]
        public void TestGetCurrent()
        {
            Assert.That(Mock.figures.GetCurrent(0).width, Is.EqualTo(1));
            Assert.That(Mock.figures.GetCurrent(3).length, Is.EqualTo(2));
            Assert.That(Mock.figures.GetCurrent(2).width, Is.EqualTo(5));
            Assert.That(() => Mock.figures.GetCurrent(-1), Throws.ArgumentException);
        }

        [Test]
        public void TestGetNext()
        {
            Assert.That(Mock.figures.GetNext(0).width, Is.EqualTo(5));
            Assert.That(Mock.figures.GetNext(3).length, Is.EqualTo(5));
            Assert.That(Mock.figures.GetNext(2).width, Is.EqualTo(4));
            Assert.That(() => Mock.figures.GetNext(7), Throws.ArgumentException); 
        }
    }

    [TestFixture]
    class ComparatorTests
    {
        [TestCase("3.0", "1.0.0", 1)]
        [TestCase("2.0.0.0.0", "2", 0)]
        [TestCase("3.0.0.3", "3.3", -1)]
        [TestCase("3.0.0.0.1", "3", 1)]
        public static void ReturnComparatorValueTest(string version1, string version2, int expectedValue)
        {
            int currentValue = Comparator.CompareVersions(version1, version2);
            Assert.AreEqual(expectedValue, currentValue);
        }
    }
}
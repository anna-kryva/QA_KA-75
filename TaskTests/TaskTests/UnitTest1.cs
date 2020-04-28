using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;


namespace TaskTests
{

    [TestFixture]
    public class UnitTest1
    {

        Double_Linked_List<int> list;

        [SetUp]
        public void SetUp()
        {
            list = new Double_Linked_List<int>();
        }
        
        [Test]
        public void TestCurrent()
        {
            list.Add(5);
            list.Add(8);
            list.Add(4);
            list.Add(10);
            int expected = 10;
            int actual = list.GetCurrent().Data;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestPrevious()
        {
            list.Add(8);
            list.Add(4);
            list.Add(12);
            list.Add(0);
            int expected = 12;
            int actual = list.GetPrevious().Data;
            Assert.AreEqual(expected, actual);
        }

        
    }

    [TestFixture]
    public class UnitTest2
    {
         
        [TestCase("1.1.0", "1.0.1")]
        [TestCase("2.50", "2.5")]
        [TestCase("1.20.13.8.8.6", "1.20.13.8.8")]
        [TestCase("5.3", "5.2.3.20.11")]
        public void VersionCompare_FirstGreater(string version1, string version2)
        {
            int res = Task2.Ver_comp(version1, version2);

            Assert.AreEqual(1, res);
        }


        [TestCase("1.2.3", "4.5.6")]
        [TestCase("3.13", "12.5")]
        [TestCase("1.20.13", "1.20.13.8.8")]
        [TestCase("5.3", "5.3.3.20.11")]
        public void VersionCompare_SecondGreater(string version1, string version2)
        {
            int res = Task2.Ver_comp(version1, version2);


            Assert.AreEqual(-1, res);
        }


        [TestCase("1", "1.0")]
        [TestCase("3.13", "3.13")]
        [TestCase("1.20.13.0.0.0", "1.20.13.0000")]
        [TestCase("5.3", "05.3")]
        public void VersionCompare_Equal(string version1, string version2)
        {
            int res = Task2.Ver_comp(version1, version2);


            Assert.AreEqual(0, res);
        }

    }
}

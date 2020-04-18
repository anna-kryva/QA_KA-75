using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VersionComparerSpace.Tests
{
    [TestClass]
    public class VersionComparerTests
    {
        [TestMethod]
        public void Compare1vs1_0()
        {
            // arrange 
            string str1 = "1";
            string str2 = "1.0";
            int expected = 0;

            // act  

            VersionComparer v = new VersionComparer();
            int actual = v.CompareVersion(str1, str2);

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Compare1_2_3vs1_2_4()
        {
            // arrange 
            string str1 = "1.2.3";
            string str2 = "1.2.4";
            int expected = -1;

            // act  

            VersionComparer v = new VersionComparer();
            int actual = v.CompareVersion(str1, str2);

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Compare1vs1_0_1()
        {
            // arrange 
            string str1 = "1";
            string str2 = "1.0.1";
            int expected = -1;

            // act  

            VersionComparer v = new VersionComparer();
            int actual = v.CompareVersion(str1, str2);

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Compare4_5_6vs4_5()
        {
            // arrange 
            string str1 = "4.5.6";
            string str2 = "4.5";
            int expected = 1;

            // act  

            VersionComparer v = new VersionComparer();
            int actual = v.CompareVersion(str1, str2);

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}

using NUnit.Framework;
using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;

namespace TRPZ
{
    
    public class Tests
    {
        

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void DoublyLinkedListTest1()
        {
            Stack<int> list = new Stack<int>();
            var list2 = new System.Collections.Generic.List<int>();
            for(int i =0; i<10; i++)
            {
                list.Add(i);
                list2.Add(i);
            }

            if (list.GetCurrent() == 0)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
            
        }

        [TestCase("1.2.3", "4.5.6", ExpectedResult = -1)]
        [TestCase("1", "1.0", ExpectedResult = 0)]
        [TestCase("1.1.0", "1.0.1", ExpectedResult = 1)]
        [TestCase("1.0.0.0.0.0.0.0.0.0", "1.0.0.0.0.0.0.0.0.0.0.0.0", ExpectedResult = 0)]
        [TestCase("1.0.0.0.0.0.0.0.0.0.0.0.0", "1.0.0.0.0.0.0.0.0.0", ExpectedResult = 0)]
        [TestCase("1.0.0.0.0.0.0.0.0.1", "1.0.0.0.0.0.0.0.0.0.0.0.1", ExpectedResult = 1)]
        [TestCase("1.0.0.0.0.0.0.0.0.0.0.0.1", "1.0.0.0.0.0.0.0.0.1", ExpectedResult = -1)]
        public int CompareVersions(string ver1, string ver2)
        {
            ver1 = ver1.Replace(".", "");
            ver2 = ver2.Replace(".", "");
            int diff = ver1.Length - ver2.Length;

            ver2 = (diff > 0 ? ver2 + String.Concat(Enumerable.Repeat("0", diff)) : ver2);
            ver1 = (diff < 0 ? ver1 + String.Concat(Enumerable.Repeat("0", -diff)) : ver1);
            
            return String.Compare(ver1,ver2);
        }


    }
}
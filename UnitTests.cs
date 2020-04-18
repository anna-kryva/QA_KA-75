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

        [TestCase(1, 0, ExpectedResult = 0)]
        [TestCase(11, 0, ExpectedResult = 10)]
        [TestCase(10,5, ExpectedResult = 4)]
        [TestCase(5, 10, ExpectedResult = default(int))]
        [TestCase(0, 10, ExpectedResult = default(int))]
        [TestCase(0, 0, ExpectedResult = default(int))]
        public int StackTest1(int Max, int NumPop )
        {
            var stack = new Stack<int>();
            for(int i = 0; i < Max; i++)
            {
                stack.Push(i);
            }
            for(int i = 0; i < NumPop; i++)
            {
                stack.Pop();
            }

            return stack.Peek();
        }

        [TestCase(1, 0, ExpectedResult = "0")]
        [TestCase(11, 0, ExpectedResult = "10")]
        [TestCase(10, 5, ExpectedResult = "4")]
        [TestCase(5, 10, ExpectedResult = default(string))]
        [TestCase(0, 10, ExpectedResult = default(string))]
        [TestCase(0, 0, ExpectedResult = default(string))]
        public string StackTest2(int Max, int NumPop)
        {
            var stack = new Stack<string>();
            for (int i = 0; i < Max; i++)
            {
                stack.Push(i.ToString());
            }
            for (int i = 0; i < NumPop; i++)
            {
                stack.Pop();
            }

            return stack.Peek();
        }

        [TestCase(1, 0, ExpectedResult = 1)]
        [TestCase(11, 0, ExpectedResult = 11)]
        [TestCase(10, 5, ExpectedResult = 5)]
        [TestCase(5, 10, ExpectedResult = 0)]
        [TestCase(0, 10, ExpectedResult = 0)]
        [TestCase(0, 0, ExpectedResult = 0)]
        public int StackTest3(int Max, int NumPop)
        {
            var stack = new Stack<int>();
            for (int i = 0; i < Max; i++)
            {
                stack.Push(i);
            }
            for (int i = 0; i < NumPop; i++)
            {
                stack.Pop();
            }

            return stack.GetCount();
        }



        [TestCase("1.2.3", "4.5.6", ExpectedResult = -1)]
        [TestCase("1", "1.0", ExpectedResult = 0)]
        [TestCase("1.1.0", "1.0.1", ExpectedResult = 1)]
        [TestCase("1.0.0.0.0.0.0.0.0.0", "1.0.0.0.0.0.0.0.0.0.0.0.0", ExpectedResult = 0)]
        [TestCase("1.0.0.0.0.0.0.0.0.0.0.0.0", "1.0.0.0.0.0.0.0.0.0", ExpectedResult = 0)]
        [TestCase("1.0.0.0.0.0.0.0.0.1", "1.0.0.0.0.0.0.0.0.0.0.0.1", ExpectedResult = 1)]
        [TestCase("1.0.0.0.0.0.0.0.0.0.0.0.1", "1.0.0.0.0.0.0.0.0.1", ExpectedResult = -1)]
        public int CompareVersions(string v1, string v2)
        {
            v1 = v1.Replace(".", "");
            v2 = v2.Replace(".", "");
            int diff = v1.Length - v2.Length;

            v2 = (diff > 0 ? v2 + String.Concat(Enumerable.Repeat("0", diff)) : v2);
            v1 = (diff < 0 ? v1 + String.Concat(Enumerable.Repeat("0", -diff)) : v1);
            
            return String.Compare(v1,v2);
        }


    }
}
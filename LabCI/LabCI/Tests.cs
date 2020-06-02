using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace LabCI
{
    [TestFixture]
    public class Tests
    {
        //Task1
        [Test]
        public void TestMyStack1()
        {
            MyStack<int> stack = new MyStack<int>().Push(1).Push(2).Push(3);
            Assert.AreEqual(stack.Pop(), 3);
        }
        [Test]
        public void TestMyStack2()
        {
            MyStack<double> stack = new MyStack<double>().Push(1).Push(2.71).Push(3.14);
            Assert.AreEqual(stack.Peek(), 1);
        }
        [Test]
        public void TestMyStack3()
        {
            MyStack<string> stack = new MyStack<string>().Push("Gryffindor").Push("Hufflepuff").Push("Ravenclaw").Push("Slytherin");
            Assert.AreEqual(stack.Count, 4);
        }
        //Task2
        [Test]
        public void Task2Test1()
        {
            Assert.AreEqual(Task2.CompareVersions("4.5.3", "4.4.2"), 1);
        }
        [Test]
        public void Task2Test2()
        {
            Assert.AreEqual(Task2.CompareVersions("1.0", "1"), 0);
        }
        [Test]
        public void Task2Test3()
        {
            Assert.AreEqual(Task2.CompareVersions("1.0.1", "1.1.0"), -1);
        }
    }
}

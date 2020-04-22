using NUnit.Framework;
using System;
using Lab;

namespace Tests
{
    [TestFixture]
    public class Tests_List
    {
        [Test]
        public void Test1()
        {
            tasks a = new tasks();

            tasks.Doubly_Linked_List lst = new tasks.Doubly_Linked_List();
            lst.Add(10, 0);
            lst.Add(20, 1);
            lst.Add(30, 2);
            int expected_current = 30;
            int actual_current = lst.GetCurrent().Value;
            Assert.AreEqual(expected_current, actual_current);
        }
        [Test]
        public void Test2()
        {
            tasks a = new tasks();

            tasks.Doubly_Linked_List lst = new tasks.Doubly_Linked_List();
            lst.Add(10, 0);
            lst.Add(20, 1);
            lst.Add(30, 2);
            int expected_current = 20;
            int actual_current = lst.GetPrevious().Value;
            Assert.AreEqual(expected_current, actual_current);
        }


    }

    [TestFixture]
    public class Tests_Compare
    {
        [Test]
        public void Test1()
        {
            string test_strin_1 = "1.0.1";
            string test_strin_2 = "1.0.2";
            int expected = -1;

            tasks Instance = new tasks();
            int actual = Instance.Compare(test_strin_1, test_strin_2);


            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test2()
        {
            string test_strin_1 = "2";
            string test_strin_2 = "1.2";
            int expected = 1;

            tasks Instance = new tasks();
            int actual = Instance.Compare(test_strin_1, test_strin_2);


            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void Test3()
        {
            string test_strin_1 = "2.0.1";
            string test_strin_2 = "2.0.1";
            int expected = 0;

            tasks Instance = new tasks();
            int actual = Instance.Compare(test_strin_1, test_strin_2);


            Assert.AreEqual(expected, actual);
        }
    }
}

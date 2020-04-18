using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinkedListSpace.Tests
{
    [TestClass]
    public class LinkedListTests
    {
        [TestMethod]
        public void Get_Current_data___string_expected()
        {
            // arrange 
            string str = "wiwiw";

            // act  

            LinkedList l = new LinkedList();
            l.AddLast(str);                // current.data now equals to str, head = current
            var actual = l.GetCurrent().GetData();

            // assert
            Assert.AreEqual(str, actual);
        }
        [TestMethod]
        public void Get_Current_data___null_expected()
        {
            // arrange 
            string str = "mimim";

            // act
            LinkedList l = new LinkedList();
            l.AddFirst(str);               // current.data now equals to null, previous to it equals to str
            Node actual = l.GetCurrent();

            // assert
            Assert.AreEqual(null, actual);
        }
        [TestMethod]
        public void Add_3_Nodes_and_Get_Last___boolean_expected()
        {
            // arrange 
            bool b1 = false;
            string string2 = "second string";
            int third = 3;

            // act
            LinkedList l = new LinkedList();
            l.AddFirst(b1);              // head.data = b1
            l.AddFirst(string2);         // head.data = string2
            l.AddFirst(third);           // head.data = third
            var actual = l.GetHead().GetNext().GetNext().GetData();

            // assert
            Assert.AreEqual(b1, actual);
        }
        [TestMethod]
        public void Add_3_Nodes_and_GetNext___string_expected()
        {
            // arrange 
            bool b1 = false;
            string string2 = "second string";
            int third = 3;

            // act
            LinkedList l = new LinkedList();
            l.AddLast(b1);                  // current.data now equals to b1
            l.AddLast(string2);
            l.AddLast(third);
            var actual = l.GetCurrent().GetNext().GetData();  // data of next to current now equals to string2

            // assert
            Assert.AreEqual(string2, actual);
        }
        [TestMethod]
        public void Add_4_Nodes_and_GetNext_3_times___char_expected()
        {
            // arrange 
            bool b1 = false;
            string string2 = "second string";
            int third = 3;
            char fourth = '4';

            // act
            LinkedList l = new LinkedList();
            l.AddLast(b1);                  // current.data now equals to b1
            l.AddLast(string2);
            l.AddLast(third);
            l.AddLast(fourth);
            var actual = l.GetCurrent().GetNext().GetNext().GetNext().GetData();  // data of next to current now equals to string2

            // assert
            Assert.AreEqual(fourth, actual);
        }
    }
}

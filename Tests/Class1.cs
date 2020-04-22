using NUnit.Framework;
using System;
using ClassLibrary1;
using ClassLibrary2;


namespace ClassLibrary1.Tests1
{
    [TestFixture]
    public class LinkedListTests
    {
        [Test]
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
        [Test]
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
        [Test]
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
        [Test]
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
        [Test]
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



namespace ClassLibrary2.Tests1
{
    [TestFixture]
    public class VersionComparerTests
    {
        [Test]
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
        [Test]
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
        [Test]
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
        [Test]
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